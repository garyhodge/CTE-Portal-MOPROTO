using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.WindowsAzure.Storage.Table;
using Microsoft.WindowsAzure.Storage;

using Interfaces = Appius.Azure.Storage.Models.Base;
using Tools = Appius.Azure.Configuration;

namespace Appius.Azure.Storage.Workers
{
    public class TableManager : Base.BaseTable
    {
        /// <summary>
        /// Configure the storage account connection and client
        /// </summary>
        public TableManager(string TableName) : base(TableName)
        {
        }

        /// <summary>
        /// Add an entity to the named table store
        /// </summary>
        public int? Add<TEntity>(TEntity Object, bool IsInsertNew = true) where TEntity : TableEntity, Interfaces.IEntity, new()
        {
            var result = new TableResult();

            try
            {
                if (IsInsertNew)
                {
                    var insert = TableOperation.Insert(Object);
                    result = Table.Execute(insert);
                }
                else
                {
                    var insert = TableOperation.InsertOrReplace(Object);
                    result = Table.Execute(insert);
                }

                return result.HttpStatusCode;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Get an entity from the named table store
        /// </summary>
        public List<TEntity> Get<TEntity>(string Query = null) where TEntity : TableEntity, Interfaces.IEntity, new()
        {
            var items = new List<TEntity>();

            try
            {
                var query = new TableQuery<TEntity>();

                if (!string.IsNullOrEmpty(Query))
                {
                    query = new TableQuery<TEntity>().Where(Query);
                }

                var result = Table.ExecuteQuery(query);

                foreach (var item in result)
                {
                    items.Add(item);
                }

                return items;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Delete an entity from the named table store
        /// </summary>
        public bool Delete<TEntity>(TEntity Object) where TEntity : TableEntity, Interfaces.IEntity, new()
        {
            try
            {
                var delete = TableOperation.Delete(Object);

                Table.Execute(delete);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
