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
    public class Location : Base.BaseWorker
    {
        private Webservices.LocationService.LocationServiceClient _Service;

        /// <summary>
        /// 
        /// </summary>
        public Location()
        {
            _Service = new Webservices.LocationService.LocationServiceClient("LocationServiceEndpoint");
        }
        /// <summary>
        /// 
        /// </summary>
        public string Noop()
        {
            var response = _Service.Noop();
            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<Entities.Location> ListAll()
        {
            var locations = new List<Entities.Location>();

            var response = _Service.ListAll();

            return locations;
        }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<Entities.Location> List(string AlphaCode)
        {
            var locations = new List<Entities.Location>();

            var response = _Service.List(AlphaCode);

            return locations;
        }
    }
}
