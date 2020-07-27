#region "Libraries"

using MPIS.Device.AplicationService.DTOs.Hardware;
using MPIS.Device.Function.Integration.Tests.Settings;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

#endregion

namespace MPIS.Device.Function.Integration.Tests.APIs
{
    public class HardwareAzureFunctionAPI
    {
        //private HttpServer Server;
        private string UrlBase = "";
        private string x_functions_key = "";
        private HttpClient client;

        public HardwareAzureFunctionAPI()
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

        public async Task<HttpResponseMessage> CreateHardware(CreateHardwareRequest createHardwareRequest)
        {
            var content = IntegrationHttpRequest.CreateContentRequest(createHardwareRequest);
            HttpResponseMessage response = await client.PostAsync(UrlBase + "api/v1/create-hardware", content);

            return response;
        }


        public async Task<HttpResponseMessage> GetHardwareById(GetHardwareByIdRequest getDeviceByIdRequest)
        {

            //getCompanyRequest.Id = Guid.Parse("6383ff38-92f9-4bda-e61a-08d783dd9ba7");

            var content = IntegrationHttpRequest.CreateQuery(getDeviceByIdRequest);
            HttpResponseMessage response = await client.GetAsync(UrlBase + String.Format("api/v1/get-hardware-by-id?{0}", content));


            return response;
        }

        public async Task<HttpResponseMessage> UpdateHardware(UpdateHardwareRequest updateHardwareRequest)
        {
            var content = IntegrationHttpRequest.CreateContentRequest(updateHardwareRequest);
            HttpResponseMessage response = await client.PutAsync(UrlBase + "api/v1/update-hardware", content);

            return response;

        }

        public async Task<HttpResponseMessage> DeleteHardware(DeleteHardwareByIdRequest deleteHardwareRequest)
        {
            var content = IntegrationHttpRequest.CreateQuery(deleteHardwareRequest);
            HttpResponseMessage response = await client.DeleteAsync(UrlBase + String.Format("api/v1/delete-hardware?{0}", content));

            return response;
        }


        #endregion
    }
}
