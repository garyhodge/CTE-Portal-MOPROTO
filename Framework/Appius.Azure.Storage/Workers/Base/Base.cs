using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.WindowsAzure.Storage.Table;
using Microsoft.WindowsAzure.Storage;

using Interfaces = Appius.Azure.Storage.Models.Base;
using Tools = Appius.Azure.Configuration;


namespace Appius.Azure.Storage.Workers.Base
{
    /// <summary>
    /// Bast table manager with constructor to configure the underlying azure connection
    /// </summary>
    public abstract class BaseTable
    {
        protected CloudTable Table;

        /// <summary>
        /// configure the storage account connection and client
        /// </summary>
        public BaseTable(string TableName)
        {
            var settings = new Tools.Settings();
            var connectionString = settings.StorageConnetion;

            try
            {
                var storageAccount = CloudStorageAccount.Parse(connectionString);

                CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

                Table = tableClient.GetTableReference(TableName);
                Table.CreateIfNotExists();
            }
            catch (Exception ex)
            {
            }
        }
    }
}
