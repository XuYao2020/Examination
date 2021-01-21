using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExaminationCore.Models
{
    public class EmailSend
    {
        /// <summary>
        /// 发件人地址
        /// </summary>
        public string userEmailAddress { get; set; }
        /// <summary>
        /// 发件人姓名
        /// </summary>
        public string userName { get; set; }
        /// <summary>
        /// 发件人密码
        /// </summary>
        public string password { get; set; }
        /// <summary>
        /// 服务器地址
        /// </summary>
        public string host { get; set; }
        /// <summary>
        /// 端口号
        /// </summary>
        public string port { get; set; }
        /// <summary>
        /// 收件人，多个收件人用逗号隔开
        /// </summary>
        public string[] sendToList { get; set; }
        /// <summary>
        /// 抄送人，多个抄送人用逗号隔开
        /// </summary>
        public string[] sendCCList { get; set; }
        /// <summary>
        /// 主题
        /// </summary>
        public string subject { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string body { get; set; }
        /// <summary>
        /// 附件路径
        /// </summary>
        public string[] attachmentsPath { get; set; }
        /// <summary>
        /// 错误消息
        /// </summary>
        public string errorMessage { get; set; }

        public EmailSend()
        {
            userEmailAddress = ManagerJson.GetSectionValue("userEmailAddress");
            userName = "Examination";
            password = ManagerJson.GetSectionValue("password");
            host = ManagerJson.GetSectionValue("host");
            port = ManagerJson.GetSectionValue("port");
            errorMessage = "邮件服务地址已更改，请联系讲师修改";
        }
    }
}
