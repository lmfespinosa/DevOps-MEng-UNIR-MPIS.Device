#region "Libraries"

using AzureFunctions.Extensions.Swashbuckle.Attribute;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using MPIS.Device.AplicationService.Abstract;
using MPIS.Device.AplicationService.DTOs.Hardware;
using MPIS.Device.FluentValidation;
using MPIS.Device.FluentValidation.Validation.Hardware;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

#endregion

namespace MPIS.Device.Function.Controllers
{
    public class HardwareController : FluentValidator
    {
        private readonly IHardwareService _hardwareService;

        public HardwareController(IHardwareService hardwareService)
        {
            _hardwareService = hardwareService;
        }

        [RequestHttpHeader("x-functions-key", isRequired: true)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Guid))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(Exception))]
        [FunctionName("v1-create-hardware")]
        public async Task<IActionResult> CreateHardwareAsync(
           [HttpTrigger(AuthorizationLevel.Function, "post", Route = "v1/create-hardware")]
            [RequestBodyType(typeof(CreateHardwareRequest), "Hardware create")]
            HttpRequest request,
           ILogger logger
           )
        {
            logger.LogInformation($"{System.Reflection.MethodBase.GetCurrentMethod().Name}");

            return await Validator(request, typeof(CreatePostHardwareRequestValidator), async (CreateHardwareRequest model) =>
            {
                var response = await _hardwareService.CreateHardwareAsync(model);

                return new OkObjectResult(response);
            });


        }

        [RequestHttpHeader("x-functions-key", isRequired: true)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(bool))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(Exception))]
        [FunctionName("v1-update-hardware")]
        public async Task<IActionResult> UpdateHardwareAsync(
            [HttpTrigger(AuthorizationLevel.Function, "put", Route = "v1/update-hardware")]
            [RequestBodyType(typeof(UpdateHardwareRequest), "Hardware update")]
            HttpRequest request,
            ILogger logger
            )
        {
            logger.LogInformation($"{System.Reflection.MethodBase.GetCurrentMethod().Name}");

            return await Validator(request, typeof(CreateUpdateHardwareRequestValidator), async (UpdateHardwareRequest model) =>
            {
                var response = await _hardwareService.UpdateHardwareAsync(model);

                return new OkObjectResult(response);
            });
        }

        [RequestHttpHeader("x-functions-key", isRequired: true)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(bool))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(Exception))]
        [FunctionName("v1-delete-hardware")]
        public async Task<IActionResult> DeleteHardwareAsync(
            [HttpTrigger(AuthorizationLevel.Function, "delete", Route = "v1/delete-hardware")]
            [RequestBodyType(typeof(DeleteHardwareByIdRequest), "Hardware delete")]
            HttpRequest request,
            ILogger logger
            )
        {
            logger.LogInformation($"{System.Reflection.MethodBase.GetCurrentMethod().Name}");

            return await Validator(request, typeof(CreateDeleteHardwareByIdRequestValidator), async (DeleteHardwareByIdRequest model) =>
            {
                var response = await _hardwareService.DeleteHardwareByIdAsync(model);

                return new OkObjectResult(response);
            });
        }

        [RequestHttpHeader("x-functions-key", isRequired: true)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(HardwareResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(Exception))]
        [QueryStringParameter("Id", "Hardware Id", DataType = typeof(GetHardwareByIdRequest))]
        [FunctionName("v1-get-hardware-by-id")]
        public async Task<IActionResult> GetHardwareByIdAsync(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "v1/get-hardware-by-id")]
            HttpRequest request,
            ILogger logger)

        {
            logger.LogInformation($"{System.Reflection.MethodBase.GetCurrentMethod().Name}");
            return await Validator(request, typeof(CreateGetHardwareByIdRequestValidator), async (GetHardwareByIdRequest model) =>
            {
                var response = await _hardwareService.GetHardwareByIdAsync(model);

                return new OkObjectResult(response);
            });
        }

        [RequestHttpHeader("x-functions-key", isRequired: true)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<HardwareResponse>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(Exception))]
        [QueryStringParameter("MACDevice", "Hardware Id", DataType = typeof(GetHardwareByMACDeviceRequest))]
        [FunctionName("v1-get-hardware-by-mac-device")]
        public async Task<IActionResult> GetAllHardwareByMACDeviceAsync(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "v1/get-hardware-by-mac-device")]
            HttpRequest request,
            ILogger logger)

        {
            logger.LogInformation($"{System.Reflection.MethodBase.GetCurrentMethod().Name}");
            return await Validator(request, typeof(CreateGetHardwareByMACDeviceRequestValidator), async (GetHardwareByMACDeviceRequest model) =>
            {
                var response = await _hardwareService.GetAllHardwareByMACDeviceAsync(model);

                return new OkObjectResult(response);
            });
        }
    }
}
