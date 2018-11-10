using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Appius.MOCompute.Services.Services.Entities
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class Location
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Name { get; set; }
    }
}