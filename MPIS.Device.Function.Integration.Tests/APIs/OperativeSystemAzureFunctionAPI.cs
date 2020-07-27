#region "Libraries"

using MPIS.Device.AplicationService.DTOs.OperativeSystem;
using MPIS.Device.Function.Integration.Tests.Settings;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

#endregion

namespace MPIS.Device.Function.Integration.Tests.APIs
{
    public class OperativeSystemAzureFunctionAPI
    {
        //private HttpServer Server;
        private string UrlBase = "";
        private string x_functions_key = "";
        private HttpClient client;

        public OperativeSystemAzureFunctionAPI()
        {

            UrlBase = Settings.ConfigurationHelper.Settings.URLFunctionService;/// Environment.GetEnvironmentVariable("URLFunctionService");
            x_functions_key = Settings.ConfigurationHelper.Settings.X_Function_Key;//Environment.GetEnvironmentVariable("X_Function_Key");
            client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("x-functions-key", x_functions_key);
            //client.DefaultRequestHeaders.Add("Content-Type", "application/json");

            // GuidAvailable = Guid.Parse("6383ff38-92f9-4bda-e61a-08d783dd9ba7");
        }

        #region "Private Methods"

        public async Task<HttpResponseMessage> CreateOperativeSystem(CreateOperativeSystemRequest createOperativeSystemRequest)
        {
            var content = IntegrationHttpRequest.CreateContentRequest(createOperativeSystemRequest);
            HttpResponseMessage response = await client.PostAsync(UrlBase + "api/v1/create-operative-system", content);

            return response;
        }


        public async Task<HttpResponseMessage> GetOperativeSystemById(GetOperativeSystemByIdRequest getOperativeSystemByIdRequest)
        {

            //getCompanyRequest.Id = Guid.Parse("6383ff38-92f9-4bda-e61a-08d783dd9ba7");

            var content = IntegrationHttpRequest.CreateQuery(getOperativeSystemByIdRequest);
            HttpResponseMessage response = await client.GetAsync(UrlBase + String.Format("api/v1/get-operative-system-by-id?{0}", content));


            return response;
        }

        public async Task<HttpResponseMessage> UpdateOperativeSystem(UpdateOperativeSystemRequest updateOperativeSystemRequest)
        {
            var content = IntegrationHttpRequest.CreateContentRequest(updateOperativeSystemRequest);
            HttpResponseMessage response = await client.PutAsync(UrlBase + "api/v1/update-operative-system", content);

            return response;

        }

        public async Task<HttpResponseMessage> DeleteOperativeSystem(DeleteOperativeSystemByIdRequest deleteOperativeSystemRequest)
        {
            var content = IntegrationHttpRequest.CreateQuery(deleteOperativeSystemRequest);
            HttpResponseMessage response = await client.DeleteAsync(UrlBase + String.Format("api/v1/delete-operative-system?{0}", content));

            return response;
        }


        #endregion
    }
}
