using System;
using System.IO;
using System.Net.Mail;
using System.Web;

using Tools = Appius.Core.Utility.Tools;

namespace Appuis.Core.Utility.Base
{
    /// <summary>
    /// base email class
    /// </summary>
    public abstract class BaseEmail
    {
        protected MailMessage _Message;
        protected SmtpClient _Smtp;

        public BaseEmail()
        {
            _Smtp = new SmtpClient(Tools.Configuration.SmtpServer);
            _Smtp.Port = Tools.Configuration.SmtpServerPort;
        }

        public void SendError(string strError, System.Web.HttpRequest refRequest, string Subject = "", string Data = "")
        {
            string strSiteName = Tools.Configuration.SiteName;

            _Message = new MailMessage();
            _Message.From = new MailAddress(Tools.Configuration.SiteEmailFromAddress);

            string[] Recipients = Tools.Configuration.ErrorEmailToAddress.Split(',');
            foreach (string Recipient in Recipients)
            {
                _Message.To.Add(new MailAddress(Recipient));
            }

            if (!string.IsNullOrEmpty(Subject))
            {
                _Message.Subject = Subject;
            }
            else
            {
                _Message.Subject = "Error in " + strSiteName;
            }

            _Message.IsBodyHtml = true;

            string strContent = string.Empty;
            string strTemplateFile = string.Format("{0}\\Error.htm", HttpContext.Current.Server.MapPath(Tools.Configuration.HtmlEmailDirectory));

            using (StreamReader rdr = File.OpenText(strTemplateFile))
            {
                strContent = rdr.ReadToEnd();
            }

            strContent = strContent.Replace("{SITEADDRESS}", Tools.Configuration.SiteUrl);
            strContent = strContent.Replace("{SITENAME}", strSiteName);
            strContent = strContent.Replace("{IPADDRESS}", refRequest.UserHostAddress);
            strContent = strContent.Replace("{USER_AGENT}", refRequest.ServerVariables["HTTP_USER_AGENT"]);
            strContent = strContent.Replace("{BROWSER}", refRequest.Browser.Browser);
            strContent = strContent.Replace("{BROWSERVERSION}", refRequest.Browser.Version);
            strContent = strContent.Replace("{ABSOLUTEPATH}", refRequest.Url.AbsolutePath);
            strContent = strContent.Replace("{RAWURL}", refRequest.RawUrl);
            strContent = strContent.Replace("{TIME}", DateTime.Now.ToString());
            strContent = strContent.Replace("{ERROR}", strError);
            strContent = strContent.Replace("{FURTHERINFORMATION}", Data);

            _Message.Body = strContent;

            try
            {
                _Smtp.Send(_Message);
            }
            catch { }
        }
    }
}
