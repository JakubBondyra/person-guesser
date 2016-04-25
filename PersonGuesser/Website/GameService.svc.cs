using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Web;
using System.Web.Providers.Entities;

namespace Website
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class GameService
    {
        private readonly HttpContext context;
        public GameService()
        {
            context = HttpContext.Current;
        }

        [OperationContract]
        [WebInvoke(Method = "GET",
        ResponseFormat = WebMessageFormat.Json)]
        public string GetData(int value)
        {
            var dupa = (int)context.Session["dupa"];
            dupa++;
            context.Session["dupa"] = dupa;
            return $"Wprowadziles: {dupa}";
        }
    }
}
