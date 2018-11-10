using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Webservices = Appius.MOCompute.Services.Client.Prototype;

namespace Appius.MOCompute.Services.Client.Workers
{
    /// <summary>
    /// 
    /// </summary>
    public class Compute : Base.BaseWorker
    {
        private Webservices.ComputeService.ComputeServiceClient _Service;

        /// <summary>
        /// 
        /// </summary>
        public Compute()
        {
            _Service = new Prototype.ComputeService.ComputeServiceClient("ComputeServiceEndpoint");
        }   

        /// <summary>
        /// 
        /// </summary>
        public string Noop()
        {
            var response = _Service.Noop();
            return response;
        }
    }
}
