using System;
using System.IO;
using System.Net.Mail;
using System.Web;

using Appuis.Core.Utility.Base;
using Tools = Appius.Core.Utility.Tools;

namespace Appuis.Utility
{
	/// <summary>
	/// Email
	/// </summary>
    public class Email : BaseEmail
    {
        public void SendError(string strError, System.Web.HttpRequest refRequest)
        {
            string strSiteName = Tools.Configuration.SiteName;

            _Message = new MailMessage();
            _Message.From = new MailAddress(Tools.Configuration.SiteEmailFromAddress);
            _Message.To.Add(new MailAddress(Tools.Configuration.ErrorEmailToAddress));
            _Message.Subject = "Error in " + strSiteName;
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

            _Message.Body = strContent;

            try
            {
                _Smtp.Send(_Message);
            }
            catch { }
        }

        public void SendDocumentDownloadConfirmation(string FirstName)
        {
            string strSiteName = Tools.Configuration.SiteName;

            _Message = new MailMessage();
            _Message.From = new MailAddress(Tools.Configuration.SiteEmailFromAddress);
            _Message.To.Add(new MailAddress(Tools.Configuration.ErrorEmailToAddress));
            _Message.Subject = "Error in " + strSiteName;
            _Message.IsBodyHtml = true;

            string strContent = string.Empty;
            string strTemplateFile = string.Format("{0}\\DocumentDownloadConfirmation.htm", HttpContext.Current.Server.MapPath(Tools.Configuration.HtmlEmailDirectory));

            using (StreamReader rdr = File.OpenText(strTemplateFile))
            {
                strContent = rdr.ReadToEnd();
            }

            strContent = strContent.Replace("{SITEADDRESS}", Tools.Configuration.SiteUrl);
            strContent = strContent.Replace("{FIRSTNAME}", FirstName);

            _Message.Body = strContent;

            try
            {
                _Smtp.Send(_Message);
            }
            catch { }
        }
    }
}