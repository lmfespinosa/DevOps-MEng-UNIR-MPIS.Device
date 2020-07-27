#region "Libraries"

using AzureFunctions.Extensions.Swashbuckle.Attribute;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using MPIS.Device.AplicationService.Abstract;
using MPIS.Device.AplicationService.DTOs.Software;
using MPIS.Device.FluentValidation;
using MPIS.Device.FluentValidation.Validation.Software;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

#endregion

namespace MPIS.Device.Function.Controllers
{
    public class SoftwareController : FluentValidator
    {
        private readonly ISoftwareService _softwareService;

        public SoftwareController(ISoftwareService softwareService)
        {
            _softwareService = softwareService;
        }

        [RequestHttpHeader("x-functions-key", isRequired: true)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Guid))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(Exception))]
        [FunctionName("v1-create-software")]
        public async Task<IActionResult> CreateSoftwareAsync(
           [HttpTrigger(AuthorizationLevel.Function, "post", Route = "v1/create-software")]
            [RequestBodyType(typeof(CreateSoftwareRequest), "Software create")]
            HttpRequest request,
           ILogger logger
           )
        {
            logger.LogInformation($"{System.Reflection.MethodBase.GetCurrentMethod().Name}");

            return await Validator(request, typeof(CreatePostSoftwareRequestValidator), async (CreateSoftwareRequest model) =>
            {
                var response = await _softwareService.CreateSoftwareAsync(model);

                return new OkObjectResult(response);
            });


        }

        [RequestHttpHeader("x-functions-key", isRequired: true)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(bool))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(Exception))]
        [FunctionName("v1-update-software")]
        public async Task<IActionResult> UpdateSoftwareAsync(
            [HttpTrigger(AuthorizationLevel.Function, "put", Route = "v1/update-software")]
            [RequestBodyType(typeof(UpdateSoftwareRequest), "Software update")]
            HttpRequest request,
            ILogger logger
            )
        {
            logger.LogInformation($"{System.Reflection.MethodBase.GetCurrentMethod().Name}");

            return await Validator(request, typeof(CreateUpdateSoftwareRequestValidator), async (UpdateSoftwareRequest model) =>
            {
                var response = await _softwareService.UpdateSoftwareAsync(model);

                return new OkObjectResult(response);
            });
        }

        [RequestHttpHeader("x-functions-key", isRequired: true)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(bool))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(Exception))]
        [FunctionName("v1-delete-software")]
        public async Task<IActionResult> DeleteSoftwareAsync(
            [HttpTrigger(AuthorizationLevel.Function, "delete", Route = "v1/delete-software")]
            [RequestBodyType(typeof(DeleteSoftwareByIdRequest), "Software delete")]
            HttpRequest request,
            ILogger logger
            )
        {
            logger.LogInformation($"{System.Reflection.MethodBase.GetCurrentMethod().Name}");

            return await Validator(request, typeof(CreateDeleteSoftwareByIdRequestValidator), async (DeleteSoftwareByIdRequest model) =>
            {
                var response = await _softwareService.DeleteSoftwareByIdAsync(model);

                return new OkObjectResult(response);
            });
        }

        [RequestHttpHeader("x-functions-key", isRequired: true)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(SoftwareResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(Exception))]
        [QueryStringParameter("Id", "Software Id", DataType = typeof(GetSoftwareByIdRequest))]
        [FunctionName("v1-get-software-by-id")]
        public async Task<IActionResult> GetSoftwareByIdAsync(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "v1/get-software-by-id")]
            HttpRequest request,
            ILogger logger)

        {
            logger.LogInformation($"{System.Reflection.MethodBase.GetCurrentMethod().Name}");
            return await Validator(request, typeof(CreateGetSoftwareByIdRequestValidator), async (GetSoftwareByIdRequest model) =>
            {
                var response = await _softwareService.GetSoftwareByIdAsync(model);

                return new OkObjectResult(response);
            });
        }

        [RequestHttpHeader("x-functions-key", isRequired: true)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<SoftwareResponse>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(Exception))]
        [QueryStringParameter("MACDevice", "Hardware Id", DataType = typeof(GetSoftwareByMACDeviceRequest))]
        [FunctionName("v1-get-software-by-mac-device")]
        public async Task<IActionResult> GetAllSoftwareByMACDeviceAsync(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "v1/get-software-by-mac-device")]
            HttpRequest request,
            ILogger logger)

        {
            logger.LogInformation($"{System.Reflection.MethodBase.GetCurrentMethod().Name}");
            return await Validator(request, typeof(CreateGetSoftwareByMACDeviceRequestValidator), async (GetSoftwareByMACDeviceRequest model) =>
            {
                var response = await _softwareService.GetAllSoftwareByMACDeviceAsync(model);

                return new OkObjectResult(response);
            });
        }
    }
}

