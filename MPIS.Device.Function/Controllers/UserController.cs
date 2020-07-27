#region "Libraries"

using Microsoft.Azure.EventGrid.Models;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.EventGrid;
using Microsoft.Extensions.Logging;
using MPIS.Device.AplicationService.Abstract;
using MPIS.Device.AplicationService.DTOs.User;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

#endregion

namespace MPIS.Device.Function.Controllers
{
    public partial class UserController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [FunctionName("v1-user-created")]
        public async Task CreateUserAsync([EventGridTrigger]EventGridEvent @event, ILogger logger)
        {
            try
            {
                logger.LogInformation($"{System.Reflection.MethodBase.GetCurrentMethod().Name}");
                string request = @event.Data.ToString();

                CreateUserRequest createUser = JsonConvert.DeserializeObject<CreateUserRequest>(request);

                await _userService.CreateUserAsync(createUser);
                logger.LogInformation($"{System.Reflection.MethodBase.GetCurrentMethod().Name}: Evento :{request}");
            }
            catch (Exception ex)
            {

            }
        }

        [FunctionName("v1-user-updated")]
        public async Task UpdateUserAsync([EventGridTrigger]EventGridEvent @event, ILogger logger)
        {
            logger.LogInformation($"{System.Reflection.MethodBase.GetCurrentMethod().Name}");
            string request = @event.Data.ToString();

            UpdateUserRequest updateUser = JsonConvert.DeserializeObject<UpdateUserRequest>(request);

            await _userService.UpdateUserAsync(updateUser);
            logger.LogInformation($"{System.Reflection.MethodBase.GetCurrentMethod().Name}: Evento :{request}");
        }

        [FunctionName("v1-user-deleted")]
        public async Task DeleteUserAsync([EventGridTrigger]EventGridEvent @event, ILogger logger)
        {
            logger.LogInformation($"{System.Reflection.MethodBase.GetCurrentMethod().Name}");
            string request = @event.Data.ToString();

            DeleteUserRequest deleteUser = JsonConvert.DeserializeObject<DeleteUserRequest>(request);

            await _userService.DeleteUserAsync(deleteUser);
            logger.LogInformation($"{System.Reflection.MethodBase.GetCurrentMethod().Name}: Evento :{request}");
        }
    }
}