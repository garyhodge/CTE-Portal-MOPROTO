using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

using Entities = Appius.MOCompute.Services.Services.Entities;

namespace Appius.MOCompute.Services.Services.Interfaces
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract(ProtectionLevel = ProtectionLevel.None)]
        [WebGet(BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "Hello/")]
        string Noop();
    }
}
