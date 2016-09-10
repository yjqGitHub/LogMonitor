using LogMonitor.Infrastructure.Extension;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

/*
* Author              :    yjq
* Email               :    425527169@qq.com
* Create Time         :    2016/9/9 18:54:10
* Class Version       :    v1.0.0.0
* Class Description   :
* Copyright @yjq 2016 . All rights reserved.
*/

namespace LogMonitor.Infrastructure
{
    /// <summary>
    /// 邮件帮助
    /// </summary>
    public sealed class EmailHelper
    {
        #region 发送邮件

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="to">接收人</param>
        /// <param name="subject">发送主题</param>
        /// <param name="content">发送内容</param>
        /// <returns></returns>
        public static async Task SendEmailAsync(string to, string subject, string content)
        {
            string serviceMailAddress = ConfigHelper.GetValue(SysContant.Key_ServiceMailAddress);
            string serviceMailPwd = ConfigHelper.GetValue(SysContant.Key_ServiceMailPwd);
            await SendEmailAsync(to, subject, content, serviceMailAddress, serviceMailPwd);
        }

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="toList">接收人列表</param>
        /// <param name="subject">发送主题</param>
        /// <param name="content">发送内容</param>
        /// <returns></returns>
        public static async Task SendEmailAsync(string[] toList, string subject, string content)
        {
            string serviceMailAddress = ConfigHelper.GetValue(SysContant.Key_ServiceMailAddress);
            string serviceMailPwd = ConfigHelper.GetValue(SysContant.Key_ServiceMailPwd);
            await SendEmailAsync(toList, subject, content, serviceMailAddress, serviceMailPwd);
        }

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="to">接收人</param>
        /// <param name="subject">发送主题</param>
        /// <param name="content">发送内容</param>
        /// <param name="serviceMailAddress">服务器邮箱账号</param>
        /// <param name="serviceMailPwd">服务器邮箱密码</param>
        /// <returns></returns>
        public static async Task SendEmailAsync(string to, string subject, string content, string serviceMailAddress, string serviceMailPwd)
        {
            await SendEmailAsync(new string[] { to }, subject, content, serviceMailAddress, serviceMailPwd);
        }

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="toList">接收人列表</param>
        /// <param name="subject">发送主题</param>
        /// <param name="content">发送内容</param>
        /// <param name="serviceMailAddress">服务器邮箱账号</param>
        /// <param name="serviceMailPwd">服务器邮箱密码</param>
        /// <returns></returns>
        public static async Task SendEmailAsync(string[] toList, string subject, string content, string serviceMailAddress, string serviceMailPwd)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(serviceMailAddress);
            toList.ForEach(to =>
            {
                mail.To.Add(new MailAddress(to));
            });
            mail.Subject = subject;
            mail.Body = content;
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            SmtpClient client = new SmtpClient("smtp.163.com", 25);
            client.Timeout = 9999;
            client.UseDefaultCredentials = true;
            client.Credentials = new NetworkCredential(serviceMailAddress, serviceMailPwd);
            await client.SendMailAsync(mail);
        }

        #endregion 发送邮件

        #region 发送邮件

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="to">接收人</param>
        /// <param name="subject">发送主题</param>
        /// <param name="content">发送内容</param>
        /// <returns></returns>
        public static void SendEmail(string to, string subject, string content)
        {
            string serviceMailAddress = ConfigHelper.GetValue(SysContant.Key_ServiceMailAddress);
            string serviceMailPwd = ConfigHelper.GetValue(SysContant.Key_ServiceMailPwd);
            SendEmail(to, subject, content, serviceMailAddress, serviceMailPwd);
        }

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="toList">接收人列表</param>
        /// <param name="subject">发送主题</param>
        /// <param name="content">发送内容</param>
        /// <returns></returns>
        public static void SendEmail(string[] toList, string subject, string content)
        {
            string serviceMailAddress = ConfigHelper.GetValue(SysContant.Key_ServiceMailAddress);
            string serviceMailPwd = ConfigHelper.GetValue(SysContant.Key_ServiceMailPwd);
            SendEmail(toList, subject, content, serviceMailAddress, serviceMailPwd);
        }

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="to">接收人</param>
        /// <param name="subject">发送主题</param>
        /// <param name="content">发送内容</param>
        /// <param name="serviceMailAddress">服务器邮箱账号</param>
        /// <param name="serviceMailPwd">服务器邮箱密码</param>
        /// <returns></returns>
        public static void SendEmail(string to, string subject, string content, string serviceMailAddress, string serviceMailPwd)
        {
            SendEmail(new string[] { to }, subject, content, serviceMailAddress, serviceMailPwd);
        }

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="toList">接收人列表</param>
        /// <param name="subject">发送主题</param>
        /// <param name="content">发送内容</param>
        /// <param name="serviceMailAddress">服务器邮箱账号</param>
        /// <param name="serviceMailPwd">服务器邮箱密码</param>
        public static void SendEmail(string[] toList, string subject, string content, string serviceMailAddress, string serviceMailPwd)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(serviceMailAddress);
            toList.ForEach(to =>
            {
                mail.To.Add(new MailAddress(to));
            });
            mail.Subject = subject;
            mail.Body = content;
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            SmtpClient client = new SmtpClient("smtp.163.com", 25);
            client.Timeout = 9999;
            client.UseDefaultCredentials = true;
            client.Credentials = new NetworkCredential(serviceMailAddress, serviceMailPwd);
            client.Send(mail);
        }

        #endregion 发送邮件
    }
}