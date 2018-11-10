using System;
using System.Configuration;

namespace Appius.Core.Utility.Tools
{
    public static class Configuration
    {
        /// <summary>
        /// 
        /// </summary>
        public static int DefaultPageSize
        {
            get
            {
                return int.Parse(ConfigurationManager.AppSettings["DefaultPageSize"]);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static string SiteEmailFromAddress
        {
            get
            {
                return (string)ConfigurationManager.AppSettings["SiteEmailFromAddress"];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static string SiteEmailToAddress
        {
            get
            {
                return (string)ConfigurationManager.AppSettings["SiteEmailToAddress"];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static string ErrorEmailToAddress
        {
            get
            {
                return (string)ConfigurationManager.AppSettings["ErrorEmailToAddress"];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static string SiteName
        {
            get
            {
                return (string)ConfigurationManager.AppSettings["SiteName"];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static string SiteUrl
        {
            get
            {
                return (string)ConfigurationManager.AppSettings["SiteUrl"];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static string HtmlEmailDirectory
        {
            get
            {
                return (string)ConfigurationManager.AppSettings["HtmlEmailDirectory"];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static string SmtpServer
        {
            get
            {
                return (string)ConfigurationManager.AppSettings["SmtpServer"];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static int SmtpServerPort
        {
            get
            {
                return int.Parse(ConfigurationManager.AppSettings["SmtpServerPort"]);
            }
        }

        public static int MaxUrlLength
        {
            get
            {
                return int.Parse(ConfigurationManager.AppSettings["MaxUrlLength"]);
            }
        }

        public static string GoogleAPIKey
        {
            get
            {
                return (string)ConfigurationManager.AppSettings["GoogleAPIKey"];
            }
        }
    }
}
