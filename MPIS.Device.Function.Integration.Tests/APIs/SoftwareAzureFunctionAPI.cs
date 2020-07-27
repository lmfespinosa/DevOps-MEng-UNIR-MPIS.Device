#region "Libraries"

using MPIS.Device.AplicationService.DTOs.Software;
using MPIS.Device.Function.Integration.Tests.Settings;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

#endregion

namespace MPIS.Device.Function.Integration.Tests.APIs
{
    public class SoftwareAzureFunctionAPI
    {
        //private HttpServer Server;
        private string UrlBase = "";
        private string x_functions_key = "";
        private HttpClient client;

        public SoftwareAzureFunctionAPI()
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

        public async Task<HttpResponseMessage> CreateSoftware(CreateSoftwareRequest createSoftwareRequest)
        {
            var content = IntegrationHttpRequest.CreateContentRequest(createSoftwareRequest);
            HttpResponseMessage response = await client.PostAsync(UrlBase + "api/v1/create-software", content);

            return response;
        }


        public async Task<HttpResponseMessage> GetSoftwareById(GetSoftwareByIdRequest getSoftwareByIdRequest)
        {

            //getCompanyRequest.Id = Guid.Parse("6383ff38-92f9-4bda-e61a-08d783dd9ba7");

            var content = IntegrationHttpRequest.CreateQuery(getSoftwareByIdRequest);
            HttpResponseMessage response = await client.GetAsync(UrlBase + String.Format("api/v1/get-software-by-id?{0}", content));


            return response;
        }

        public async Task<HttpResponseMessage> UpdateSoftware(UpdateSoftwareRequest updateSoftwareRequest)
        {
            var content = IntegrationHttpRequest.CreateContentRequest(updateSoftwareRequest);
            HttpResponseMessage response = await client.PutAsync(UrlBase + "api/v1/update-software", content);

            return response;

        }

        public async Task<HttpResponseMessage> DeleteHardware(DeleteSoftwareByIdRequest deleteSoftwareRequest)
        {
            var content = IntegrationHttpRequest.CreateQuery(deleteSoftwareRequest);
            HttpResponseMessage response = await client.DeleteAsync(UrlBase + String.Format("api/v1/delete-software?{0}", content));

            return response;
        }


        #endregion
    }
}
