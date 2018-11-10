using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;

using Interfaces = Appius.MOCompute.Services.Services.Interfaces;
using Entities = Appius.MOCompute.Services.Services.Entities;
using StorageWorker = Appius.Azure.Storage.Client.Workers;

namespace Appius.MOCompute.Services.Services
{

    /// <summary>
    /// Service contract managing the location endpoint
    /// </summary>
    [ServiceBehavior(Namespace = "http://www.appius.com", InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple, AddressFilterMode = AddressFilterMode.Any)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class LocationService : Interfaces.ILocationService
    {
        /// <summary>
        /// List all locations
        /// </summary>
        [OperationBehavior]
        public string Noop()
        {
            return "200 OK";
        }

        /// <summary>
        /// List all locations
        /// </summary>
        [OperationBehavior]
        public IEnumerable<Entities.Location> ListAll()
        {
            var entities = new List<Entities.Location>();

            return entities;
        }

        /// <summary>
        /// Llist all locations associated with a company
        /// </summary>
        [OperationBehavior]
        public IEnumerable<Entities.Location> List(string AlphaCode)
        {
            var entities = new List<Entities.Location>();

            return entities;
        }
    }
}
