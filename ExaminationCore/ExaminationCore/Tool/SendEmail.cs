using ExaminationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ExaminationCore
{
    public class SendEmail
    {
        /// <summary>
        /// 向用户发送邮件
        /// </summary>
        /// <param name="ReceiveUser">接收人，邮箱地址</param>
        /// <param name="MailTitle">邮件标题</param>
        /// <param name="MailContent">邮件内容</param>
        internal static string SendMail(string ReceiveUser,string MailTitle, string MailContent)
        {
            var SendUser = ManagerJson.GetSectionValue("userEmailAddress");
            var DisplayName = ManagerJson.GetSectionValue("DisplayName");
            var UserPassword = ManagerJson.GetSectionValue("emailPassword");

            MailAddress toMail = new MailAddress(ReceiveUser);//接收者邮箱
            MailAddress fromMail = new MailAddress(SendUser, DisplayName);//发送者邮箱
            MailMessage mail = new MailMessage(fromMail, toMail);
            mail.Subject = MailTitle;
            mail.IsBodyHtml = true;//是否支持HTML
            mail.Body = MailContent;
            SmtpClient client = new SmtpClient();
            client.EnableSsl = true;
            client.Host = "smtp.exmail.qq.com";//设置发送者邮箱对应的smtpserver
            client.Port = 587;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(SendUser, UserPassword);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            try
            {
                client.Send(mail);
                return "已发送邮件。";
            }
            catch (Exception e)
            {
                return "发送失败:" + e.Message;
            }
           
        }

    }
}
