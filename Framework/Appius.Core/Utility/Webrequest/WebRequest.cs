using System;
using System.Net;
using System.Text;
using System.IO;
using System.Configuration;

namespace Appius.Core.Utility
{
    public static class WebRequesHelpers
    {
        public static bool CheckEndpoint(string Endpoint)
        {
                               
            var request = (HttpWebRequest)WebRequest.Create(Endpoint);

            try
            {
                var response = (HttpWebResponse)request.GetResponse();

                return response.StatusCode == HttpStatusCode.OK ? true:false;
               
            }
            catch (Exception ex)
            {
                return ex.Message.Contains("401") || ex.Message.Contains("403") ? true : false;
            }
            
             
        }
    }
}
