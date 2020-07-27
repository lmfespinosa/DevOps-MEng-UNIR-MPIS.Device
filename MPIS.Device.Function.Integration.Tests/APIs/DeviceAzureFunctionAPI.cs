#region "Libraries"

using MPIS.Device.AplicationService.DTOs.Device;
using MPIS.Device.Function.Integration.Tests.Settings;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

#endregion

namespace MPIS.Device.Function.Integration.Tests.APIs
{
    public class DeviceAzureFunctionAPI
    {
        //private HttpServer Server;
        private string UrlBase = "";
        private string x_functions_key = "";
        private HttpClient client;

        public DeviceAzureFunctionAPI()
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

        public async Task<HttpResponseMessage> CreateDevice(CreateDeviceRequest createDeviceRequest)
        {
            var content = IntegrationHttpRequest.CreateContentRequest(createDeviceRequest);
            HttpResponseMessage response = await client.PostAsync(UrlBase + "api/v1/create-device", content);

            return response;
        }


        public async Task<HttpResponseMessage> GetDeviceById(GetDeviceByIdRequest getDeviceByIdRequest)
        {

            //getCompanyRequest.Id = Guid.Parse("6383ff38-92f9-4bda-e61a-08d783dd9ba7");

            var content = IntegrationHttpRequest.CreateQuery(getDeviceByIdRequest);
            HttpResponseMessage response = await client.GetAsync(UrlBase + String.Format("api/v1/get-device-by-id?{0}", content));


            return response;
        }

        public async Task<HttpResponseMessage> UpdateDevice(UpdateDeviceRequest updateDeviceRequest)
        {
            var content = IntegrationHttpRequest.CreateContentRequest(updateDeviceRequest);
            HttpResponseMessage response = await client.PutAsync(UrlBase + "api/v1/update-device", content);

            return response;

        }

        public async Task<HttpResponseMessage> DeleteDevice(DeleteDeviceByIdRequest deleteUserRequest)
        {
            var content = IntegrationHttpRequest.CreateQuery(deleteUserRequest);
            HttpResponseMessage response = await client.DeleteAsync(UrlBase + String.Format("api/v1/delete-device?{0}", content));

            return response;
        }


        #endregion
    }
}
