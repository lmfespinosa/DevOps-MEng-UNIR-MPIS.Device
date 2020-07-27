#region "Libraries"

using MPIS.Device.Function.Integration.Tests.Models;
using MPIS.Device.Function.Integration.Tests.Settings;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

#endregion

namespace MPIS.Device.Function.Integration.Tests.APIs
{
    public class UserAzureFunctionAPI
    {
        //private HttpServer Server;
        private string UrlBase = "";
        private string x_functions_key = "";
        private HttpClient client;

        public UserAzureFunctionAPI()
        {

            UrlBase = Settings.ConfigurationHelper.Settings.URLFunctionService;/// Environment.GetEnvironmentVariable("URLFunctionService");
            x_functions_key = Settings.ConfigurationHelper.Settings.X_Function_Key;//Environment.GetEnvironmentVariable("X_Function_Key");
            client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("x-functions-key", x_functions_key);
            client.DefaultRequestHeaders.Add("aeg-event-type", "Notification");
            //client.DefaultRequestHeaders.Add("Content-Type", "application/json");

            // GuidAvailable = Guid.Parse("6383ff38-92f9-4bda-e61a-08d783dd9ba7");
            
        }

        #region "Private Methods"

        public async Task<HttpResponseMessage> CreateUser(EventGridModel createUserRequest)
        {
            var content = IntegrationHttpRequest.CreateContentRequest(createUserRequest);
            HttpResponseMessage response = await client.PostAsync(UrlBase + "runtime/webhooks/EventGrid?functionName=v1-user-created", content);

            return response;
        }

        #endregion
    }
}
