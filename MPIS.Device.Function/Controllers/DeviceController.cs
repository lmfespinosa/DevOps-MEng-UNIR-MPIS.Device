#region "Libraries"

using AzureFunctions.Extensions.Swashbuckle.Attribute;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using MPIS.Device.AplicationService.Abstract;
using MPIS.Device.AplicationService.DTOs.Device;
using MPIS.Device.FluentValidation;
using MPIS.Device.FluentValidation.Validation.Device;
using System;
using System.Net;
using System.Threading.Tasks;

#endregion

namespace MPIS.Device.Function.Controllers
{
    public partial class DeviceController : FluentValidator
    {
        private readonly IDeviceService _deviceService;

        public DeviceController(IDeviceService deviceService)
        {
            _deviceService = deviceService;
        }

        [RequestHttpHeader("x-functions-key", isRequired: true)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Guid))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(Exception))]
        [FunctionName("v1-create-device")]
        public async Task<IActionResult> CreateDeviceAsync(
           [HttpTrigger(AuthorizationLevel.Function, "post", Route = "v1/create-device")]
            [RequestBodyType(typeof(CreateDeviceRequest), "User create")]
            HttpRequest request,
           ILogger logger
           )
        {
            logger.LogInformation($"{System.Reflection.MethodBase.GetCurrentMethod().Name}");

            return await Validator(request, typeof(CreatePostDeviceRequestValidator), async (CreateDeviceRequest model) =>
            {
                var response = await _deviceService.CreateDeviceAsync(model);

                return new OkObjectResult(response);
            });


        }

        [RequestHttpHeader("x-functions-key", isRequired: true)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(bool))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(Exception))]
        [FunctionName("v1-update-device")]
        public async Task<IActionResult> UpdateDeviceAsync(
            [HttpTrigger(AuthorizationLevel.Function, "put", Route = "v1/update-device")]
            [RequestBodyType(typeof(UpdateDeviceRequest), "Device update")]
            HttpRequest request,
            ILogger logger
            )
        {
            logger.LogInformation($"{System.Reflection.MethodBase.GetCurrentMethod().Name}");

            return await Validator(request, typeof(CreateUpdateDeviceRequestValidator), async (UpdateDeviceRequest model) =>
            {
                var response = await _deviceService.UpdateDeviceAsync(model);

                return new OkObjectResult(response);
            });
        }

        [RequestHttpHeader("x-functions-key", isRequired: true)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(bool))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(Exception))]
        [FunctionName("v1-delete-device")]
        public async Task<IActionResult> DeleteDeviceAsync(
            [HttpTrigger(AuthorizationLevel.Function, "delete", Route = "v1/delete-device")]
            [RequestBodyType(typeof(DeleteDeviceByIdRequest), "Device delete")]
            HttpRequest request,
            ILogger logger
            )
        {
            logger.LogInformation($"{System.Reflection.MethodBase.GetCurrentMethod().Name}");

            return await Validator(request, typeof(CreateDeleteDeviceByIdRequestValidator), async (DeleteDeviceByIdRequest model) =>
            {
                var response = await _deviceService.DeleteDeviceByIdAsync(model);

                return new OkObjectResult(response);
            });
        }

        [RequestHttpHeader("x-functions-key", isRequired: true)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(DeviceResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(Exception))]
        [QueryStringParameter("Id", "Device Id", DataType = typeof(GetDeviceByIdRequest))]
        [FunctionName("v1-get-device-by-id")]
        public async Task<IActionResult> GetDeviceByIdAsync(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "v1/get-device-by-id")]
            HttpRequest request,
            ILogger logger)

        {
            logger.LogInformation($"{System.Reflection.MethodBase.GetCurrentMethod().Name}");
            return await Validator(request, typeof(CreateGetDeviceByIdRequestValidator), async (GetDeviceByIdRequest model) =>
            {
                var response = await _deviceService.GetDeviceByIdAsync(model);

                return new OkObjectResult(response);
            });
        }

    }
}
