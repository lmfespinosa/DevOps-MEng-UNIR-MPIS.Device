#region "Libraries"

using AzureFunctions.Extensions.Swashbuckle.Attribute;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using MPIS.Device.AplicationService.Abstract;
using MPIS.Device.AplicationService.DTOs.OperativeSystem;
using MPIS.Device.FluentValidation;
using MPIS.Device.FluentValidation.Validation.OperativeSystem;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

#endregion

namespace MPIS.Device.Function.Controllers
{
    public class OperativeSystemController : FluentValidator
    {
        private readonly IOperativeSystemService _operativeSystemService;

        public OperativeSystemController(IOperativeSystemService operativeSystemService)
        {
            _operativeSystemService = operativeSystemService;
        }

        [RequestHttpHeader("x-functions-key", isRequired: true)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Guid))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(Exception))]
        [FunctionName("v1-create-operative-system")]
        public async Task<IActionResult> CreateOperativeSystemAsync(
           [HttpTrigger(AuthorizationLevel.Function, "post", Route = "v1/create-operative-system")]
            [RequestBodyType(typeof(CreateOperativeSystemRequest), "OperativeSystem create")]
            HttpRequest request,
           ILogger logger
           )
        {
            logger.LogInformation($"{System.Reflection.MethodBase.GetCurrentMethod().Name}");

            return await Validator(request, typeof(CreatePostOperativeSystemRequestValidator), async (CreateOperativeSystemRequest model) =>
            {
                var response = await _operativeSystemService.CreateOperativeSystemAsync(model);

                return new OkObjectResult(response);
            });


        }

        [RequestHttpHeader("x-functions-key", isRequired: true)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(bool))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(Exception))]
        [FunctionName("v1-update-operative-system")]
        public async Task<IActionResult> UpdateOperativeSystemAsync(
            [HttpTrigger(AuthorizationLevel.Function, "put", Route = "v1/update-operative-system")]
            [RequestBodyType(typeof(UpdateOperativeSystemRequest), "OperativeSystem update")]
            HttpRequest request,
            ILogger logger
            )
        {
            logger.LogInformation($"{System.Reflection.MethodBase.GetCurrentMethod().Name}");

            return await Validator(request, typeof(CreateUpdateOperativeSystemRequestValidator), async (UpdateOperativeSystemRequest model) =>
            {
                var response = await _operativeSystemService.UpdateOperativeSystemAsync(model);

                return new OkObjectResult(response);
            });
        }

        [RequestHttpHeader("x-functions-key", isRequired: true)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(bool))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(Exception))]
        [FunctionName("v1-delete-operative-system")]
        public async Task<IActionResult> DeleteOperativeSystemAsync(
            [HttpTrigger(AuthorizationLevel.Function, "delete", Route = "v1/delete-operative-system")]
            [RequestBodyType(typeof(DeleteOperativeSystemByIdRequest), "OperativeSystem delete")]
            HttpRequest request,
            ILogger logger
            )
        {
            logger.LogInformation($"{System.Reflection.MethodBase.GetCurrentMethod().Name}");

            return await Validator(request, typeof(CreateDeleteOperativeSystemByIdRequestValidator), async (DeleteOperativeSystemByIdRequest model) =>
            {
                var response = await _operativeSystemService.DeleteOperativeSystemByIdAsync(model);

                return new OkObjectResult(response);
            });
        }

        [RequestHttpHeader("x-functions-key", isRequired: true)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(OperativeSystemResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(Exception))]
        [QueryStringParameter("Id", "OperativeSystem Id", DataType = typeof(GetOperativeSystemByIdRequest))]
        [FunctionName("v1-get-operative-system-by-id")]
        public async Task<IActionResult> GetOperativeSystemByIdAsync(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "v1/get-operative-system-by-id")]
            HttpRequest request,
            ILogger logger)

        {
            logger.LogInformation($"{System.Reflection.MethodBase.GetCurrentMethod().Name}");
            return await Validator(request, typeof(CreateGetOperativeSystemByIdRequestValidator), async (GetOperativeSystemByIdRequest model) =>
            {
                var response = await _operativeSystemService.GetOperativeSystemByIdAsync(model);

                return new OkObjectResult(response);
            });
        }

        [RequestHttpHeader("x-functions-key", isRequired: true)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<OperativeSystemResponse>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(Exception))]
        [QueryStringParameter("MACDevice", "Hardware Id", DataType = typeof(GetOperativeSystemByMACDeviceRequest))]
        [FunctionName("v1-get-operative-system-by-mac-device")]
        public async Task<IActionResult> GetAllOperativeSystemByMACDeviceAsync(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "v1/get-operative-system-by-mac-device")]
            HttpRequest request,
            ILogger logger)

        {
            logger.LogInformation($"{System.Reflection.MethodBase.GetCurrentMethod().Name}");
            return await Validator(request, typeof(CreateGetOperativeSystemByMACDeviceRequestValidator), async (GetOperativeSystemByMACDeviceRequest model) =>
            {
                var response = await _operativeSystemService.GetAllOperativeSystemByMACDeviceAsync(model);

                return new OkObjectResult(response);
            });
        }
    }
}
