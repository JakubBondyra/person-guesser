using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace PGServices
{
    [ServiceContract(Namespace = "PGService")]
    [AspNetCompatibilityRequirements(RequirementsMode =
            AspNetCompatibilityRequirementsMode.Allowed)]
    public class PGService
    {
        [OperationContract]
        [WebInvoke(Method = "GET",
     ResponseFormat = WebMessageFormat.Json)]
        public string GetData(int value)
        {
            return $"You entered: {value}";
        }
    }
}
