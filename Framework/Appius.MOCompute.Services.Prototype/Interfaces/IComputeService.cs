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
    /// <summary>
    /// 
    /// </summary>
    [ServiceContract]
    public interface IComputeService : IService
    {
        [OperationContract(ProtectionLevel = ProtectionLevel.None)]
        [WebGet(BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "GetResults/")]
        void GetResults();
    }
}
