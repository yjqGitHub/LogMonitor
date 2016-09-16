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
        private readonly ILogger _logger;

        public Service1()
        {
            InitializeComponent();

            _logger = ObjectContainer.Current.Resolve<ILoggerFactory>().Create(SysContant.LoggerName_Default);
        }

        protected override void OnStart(string[] args)
        {
            Task.Factory.StartNew(() => { Start(); });
        }

        protected override void OnStop()
        {
            LogDetailInfo logDetailInfo = LogDetailInfo.CreateWarningLog("服务停止", belongModule: SysContant.Module_ReceiveService);
            _logger.Warn(logDetailInfo.ToJson());
        }

        private void Start()
        {
            string listenIpAddress = ConfigurationManager.AppSettings["IPAddress"].ToString();//监听Ip
            int listenIpPort = Convert.ToInt32(ConfigurationManager.AppSettings["IPAddressPort"].ToString());//监听端口
            int browseLogListenIpPort = Convert.ToInt32(ConfigurationManager.AppSettings["IPAddressBrowseLogPort"].ToString());//浏览记录监听端口
            Task.Factory.StartNew(() =>
            {
                MonitorLog(listenIpAddress, listenIpPort);
            });

            Task.Delay(2000);
            Task.Factory.StartNew(() =>
            {
                MonitorBrowseLog(listenIpAddress, browseLogListenIpPort);
            });

            LogDetailInfo logDetailInfo = LogDetailInfo.CreateDebugLog("服务开始", belongModule: SysContant.Module_ReceiveService);
            _logger.Debug(logDetailInfo.ToJson());
        }

        /// <summary>
        /// 监听错误、调试等日志
        /// </summary>
        /// <param name="ipAddress"></param>
        /// <param name="port"></param>
        private void MonitorLog(string ipAddress, int port)
        {
            IPAddress address = IPAddress.Parse(ipAddress);
            IPEndPoint remoteEndPoint = new IPEndPoint(address, 0);
            UdpClient udpClient;
            byte[] buffer;
            try
            {
                udpClient = new UdpClient(port);
                LogDetailInfo logDetailInfo = LogDetailInfo.CreateDebugLog("监听开始 MonitorLog", belongModule: SysContant.Module_ReceiveService);
                _logger.Debug(logDetailInfo.ToJson());
                while (true)
                {
                    buffer = udpClient.Receive(ref remoteEndPoint);
                    bool isSuccess = ExceptionHelper.IgnoreButLogException(() =>
                    {
                        string logDetail = buffer.GetString();

                        ILogRecordApplication _logRecordApplication = ObjectContainer.Current.Resolve<ILogRecordApplication>();
                        return _logRecordApplication.AddLogRecord(logDetail, defaultLoggerName: SysContant.LoggerName_Default);
                    }, defaultLoggerName: SysContant.LoggerName_Default);
                }
            }
            catch (Exception ex)
            {
                string errorMsg = ExceptionHelper.GetJsonErrorLog(ex, belongModule: SysContant.Module_ReceiveService);
                _logger.Error(errorMsg);
                LogDetailInfo logDetailInfo = LogDetailInfo.CreateFatalLog("MonitorLog UDP监听出异常了", belongModule: SysContant.Module_ReceiveService);
                _logger.Fatal(logDetailInfo.ToJson());
            }
        }

        /// <summary>
        /// 监听浏览记录
        /// </summary>
        /// <param name="ipAddress"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        private void MonitorBrowseLog(string ipAddress, int port)
        {
            IPAddress address = IPAddress.Parse(ipAddress);
            IPEndPoint remoteEndPoint = new IPEndPoint(address, 0);
            UdpClient udpClient;
            byte[] buffer;
            try
            {
                udpClient = new UdpClient(port);
                LogDetailInfo logDetailInfo = LogDetailInfo.CreateDebugLog("监听开始 MonitorBrowseLog", belongModule: SysContant.Module_ReceiveService);
                _logger.Debug(logDetailInfo.ToJson());
                while (true)
                {
                    buffer = udpClient.Receive(ref remoteEndPoint);
                    bool isSuccess = ExceptionHelper.IgnoreButLogException(() =>
                  {
                      string logDetail = buffer.GetString();
                      IBrowseLogRecordApplication _browseLogRecordApplication = ObjectContainer.Current.Resolve<IBrowseLogRecordApplication>();
                      return _browseLogRecordApplication.AddBrowseLog(logDetail, defaultLoggerName: SysContant.LoggerName_Default);
                  }, defaultLoggerName: SysContant.LoggerName_Default);
                }
            }
            catch (Exception ex)
            {
                string errorMsg = ExceptionHelper.GetJsonErrorLog(ex, belongModule: SysContant.Module_ReceiveService);
                _logger.Error(errorMsg);
                LogDetailInfo logDetailInfo = LogDetailInfo.CreateFatalLog("MonitorBrowseLog UDP监听出异常了", belongModule: SysContant.Module_ReceiveService);
                _logger.Fatal(logDetailInfo.ToJson());
            }
        }
    }
}