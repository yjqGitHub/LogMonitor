using LogMonitor.Application;
using LogMonitor.Infrastructure;
using LogMonitor.Infrastructure.Extension;
using System;
using System.Configuration;
using System.Net;
using System.Net.Sockets;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace LogMonitor.ReceiveService
{
    public partial class Service1 : ServiceBase
    {
        private readonly ILogRecordApplication _logRecordApplication;
        private readonly ILogger _logger;

        public Service1()
        {
            InitializeComponent();
            _logRecordApplication = ObjectContainer.Current.Resolve<ILogRecordApplication>();
            _logger = ObjectContainer.Current.Resolve<ILoggerFactory>().Create(SysContant.LogerName_ReceiveService);
        }

        protected override void OnStart(string[] args)
        {

            string listenIpAddress = ConfigurationManager.AppSettings["IPAddress"].ToString();//监听Ip
            int listenIpPort = Convert.ToInt32(ConfigurationManager.AppSettings["IPAddressPort"].ToString());//监听端口
            Task.Factory.StartNew(() =>
            {
                MonitorLog(listenIpAddress, listenIpPort);
            });
            LogDetailInfo logDetailInfo = LogDetailInfo.CreateDebugLog("服务开始", belongModule: "LogMonitorReceiveService");
            _logger.Debug(logDetailInfo.ToJson());

        }

        protected override void OnStop()
        {
            LogDetailInfo logDetailInfo = LogDetailInfo.CreateWarningLog("服务停止", belongModule: "LogMonitorReceiveService");
            _logger.Warn(logDetailInfo.ToJson());
        }

        private void MonitorLog(string ipAddress, int port)
        {
            int i = 0;
            while (i < 20)
            {
                System.Threading.Thread.Sleep(1500);
                i++;
            }
            IPAddress address = IPAddress.Parse(ipAddress);
            IPEndPoint remoteEndPoint = new IPEndPoint(address, 0);
            UdpClient udpClient;
            byte[] buffer;
            try
            {
                udpClient = new UdpClient(port);
                LogDetailInfo logDetailInfo = LogDetailInfo.CreateDebugLog("监听开始", belongModule: "LogMonitorReceiveService");
                _logger.Debug(logDetailInfo.ToJson());
                while (true)
                {
                    buffer = udpClient.Receive(ref remoteEndPoint);
                    bool isSuccess = ExceptionHelper.IgnoreButLogException(() =>
                    {
                        string logDetail = buffer.GetString();
                        return _logRecordApplication.AddLogRecord(logDetail, defaultLoggerName: SysContant.LogerName_ReceiveService);
                    }, defaultLoggerName: SysContant.LogerName_ReceiveService);
                }
            }
            catch (Exception ex)
            {
                string errorMsg = ExceptionHelper.GetJsonErrorLog(ex, belongModule: "LogMonitorReceiveService");
                _logger.Error(errorMsg);
                LogDetailInfo logDetailInfo = LogDetailInfo.CreateFatalLog("UDP监听出异常了", belongModule: "LogMonitorReceiveService");
                _logger.Fatal(logDetailInfo.ToJson());
            }
        }
    }
}