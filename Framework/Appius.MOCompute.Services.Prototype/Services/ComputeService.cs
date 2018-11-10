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
    /// Service contract managing the compute endpoint
    /// </summary>
    [ServiceBehavior(Namespace = "http://www.appius.com", InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple, AddressFilterMode = AddressFilterMode.Any)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class ComputeService : Interfaces.IComputeService
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
        /// Query the service for the results
        /// </summary>
        [OperationBehavior]
        public void GetResults()
        {
        }
    }
}
