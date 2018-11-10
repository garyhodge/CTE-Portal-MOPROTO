using System;
using System.Configuration;
using System.Reflection;

namespace Appius.Azure.Configuration
{
    /// <summary>
    /// Wrapper for the lifeasearch specific application settings
    /// </summary>
    public class Settings
    {
        private AppSettingsSection _AppSettings;

        /// <summary>
        /// Load the dll-specific app configuration file
        /// </summary>
        public Settings()
        {
            var fileMap = new ExeConfigurationFileMap();
            fileMap.ExeConfigFilename = (Assembly.GetExecutingAssembly().CodeBase + ".config").Substring(8);
            System.Configuration.Configuration dllConfig = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            _AppSettings = (dllConfig.GetSection("appSettings") as AppSettingsSection);
        }

        /// <summary>
        /// flag to indicate that the applicaiton is in test mode
        /// </summary>
        public bool IsInTestMode
        {
            get
            {
                var isInTestMode = _AppSettings.Settings["IsInTestMode"];
                return isInTestMode != null ? Convert.ToBoolean(isInTestMode.Value) : true;
            }
        }

        /// <summary>
        /// Redis Cache connection string
        /// </summary>
        public string CacheConnection
        {
            get
            {
                var cacheConnection = _AppSettings.Settings["CacheConnection"];
                return cacheConnection != null ? cacheConnection.Value : null;
            }
        }

        /// <summary>
        ///  Use local session not azure cache
        /// </summary>
        public bool UseLocalCache
        {
            get
            {
                var seLocalCache = _AppSettings.Settings["UseLocalCache"];
                return seLocalCache != null ? Convert.ToBoolean(seLocalCache.Value) : true;
            }
        }

        /// <summary>
        ///  blob store connection string
        /// </summary>
        public string BlobConnection
        {
            get
            {
                var blobConnetion = _AppSettings.Settings["BlobConnection"];
                return blobConnetion != null ? blobConnetion.Value : null;
            }
        }

        /// <summary>
        ///  table store connection string
        /// </summary>
        public string StorageConnetion
        {
            get
            {
                var storageConnetion = _AppSettings.Settings["StorageConnetion"];
                return storageConnetion != null ? storageConnetion.Value : null;
            }
        }
    }
}