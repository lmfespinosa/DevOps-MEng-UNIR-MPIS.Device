#region "Libraries"

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using MPIS.Device.AplicationService;
using MPIS.Device.AplicationService.DTOs.Device;
using MPIS.Device.Function.Controllers;
using MPIS.Device.Function.Models.Tests.ComponentValues;
using MPIS.Device.Function.Models.Tests.TestCasesSources;
using MPIS.Device.Function.Unit.Tests.MockServices;
using MPIS.Device.Function.Unit.Tests.Services;
using MPIS.Device.Function.Unit.Tests.Settings;
using MPIS.Device.Repository;
using MPIS.Device.RepositoryModel;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

#endregion

namespace MPIS.Device.Function.Unit.Tests.ControllerTests
{
    [TestFixture]
    public partial class UnitTestDeviceController : TestServiceBase
    {
        #region "Atributes"

        private ILogger _logger;

        #endregion

        #region "Constructor"

        [SetUp]
        public void Setup()
        {
            _logger = TestLogger.Create<ILogger>();

        }

        #endregion

        #region "Create"

        [Test]
        [TestCaseSource(typeof(TestCaseSourcesDevice), nameof(TestCaseSourcesDevice.CreateDeviceTestCases))]
        public async Task TestCreateDevice(CreateDeviceRequest obj, IActionResult resultAction)
        {
            //var request = AutomapperSingleton.Mapper.Map<CreateCompanyRequest>(obj);

            IActionResult actionResult = await CreateDevice(obj);

            var objectResult = actionResult as ObjectResult;
            if (objectResult.StatusCode == 200)
            {
                dynamic id = Guid.Parse(objectResult.Value.ToString());
                DeviceComponentsValues.GuidAvailable = (Guid)id;
                //RecordComponentsValues.NameAvailable = obj.Name;
            }

            base.CheckAssert(actionResult, resultAction);
        }

        #endregion

        #region "Update"

        [Test]
        [TestCaseSource(typeof(TestCaseSourcesDevice), nameof(TestCaseSourcesDevice.UpdateDeviceTestCases))]
        public async Task TestUpdateDevice(UpdateDeviceRequest obj, ObjectResult resultAction, bool elementCreated = false)
        {
            DeviceResponse defaultCompany = await this.CreatedDefaultDevice();

            obj.Id = elementCreated == true ? defaultCompany.Id : obj.Id;

            IActionResult actionResult = await this.UpdateDevice(obj);

            base.CheckAssert(actionResult, resultAction);
        }

        #endregion

        #region "Get"

        [TestCaseSource(typeof(TestCaseSourcesDevice), nameof(TestCaseSourcesDevice.GetDeviceTestCases))]
        public async Task TestGetDevice(GetDeviceByIdRequest getcom, ObjectResult resultAction, bool elementCreated = false)
        {
            DeviceResponse defaultNotification = await this.CreatedDefaultDevice();

            getcom.Id = elementCreated == true ? defaultNotification.Id : getcom.Id;

            IActionResult actionResult = await this.GetDeviceById(getcom);

            base.CheckAssert(actionResult, resultAction);
        }

        #endregion


        #region "Delete"

        [TestCaseSource(typeof(TestCaseSourcesDevice), nameof(TestCaseSourcesDevice.DeleteDeviceTestCases))]
        public async Task TestDeleteNotification(DeleteDeviceByIdRequest delnot, ObjectResult resultAction, bool elementCreated = false)
        {
            DeviceResponse defaultNotification = await this.CreatedDefaultDevice();

            //Guid createdtransactionId = CompanyComponentsValues.GetCompanyAviability();

            delnot.Id = elementCreated == true ? defaultNotification.Id : delnot.Id;

            IActionResult actionResult = await this.DeleteDevice(delnot);

            base.CheckAssert(actionResult, resultAction);
        }

        #endregion

        #region "Private Methods"

        private async Task<IActionResult> CreateDevice(CreateDeviceRequest createDeviceRequest)
        {

            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "Device")
                .Options;


            // Run the test against one instance of the context
            using (var context = new Context(options))
            {

                var repository = new DeviceRepository(context, AutomapperSingleton.Mapper);
                var service = new DeviceService(repository, AutomapperSingleton.Mapper);
                var controller = new DeviceController(service);

                Mock<HttpRequest> mockCreateRequest = MockHttpRequest.CreateMockRequest(createDeviceRequest);
                return await controller.CreateDeviceAsync(mockCreateRequest.Object, _logger); //as GridController;

            }
        }

        private async Task<IActionResult> UpdateDevice(UpdateDeviceRequest updateDeviceRequest)
        {

            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "Device")
                .Options;



            // Run the test against one instance of the context
            using (var context = new Context(options))
            {
                var repository = new DeviceRepository(context, AutomapperSingleton.Mapper);
                var service = new DeviceService(repository, AutomapperSingleton.Mapper);
                var controller = new DeviceController(service);

                Mock<HttpRequest> mockCreateRequest = MockHttpRequest.CreateMockRequest(updateDeviceRequest);
                return await controller.UpdateDeviceAsync(mockCreateRequest.Object, _logger); //as GridController;

            }
        }

        private async Task<IActionResult> DeleteDevice(DeleteDeviceByIdRequest deleteDeviceRequest)
        {

            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "Device")
                .Options;


            // Run the test against one instance of the context
            using (var context = new Context(options))
            {

                var repository = new DeviceRepository(context, AutomapperSingleton.Mapper);
                var service = new DeviceService(repository, AutomapperSingleton.Mapper);
                var controller = new DeviceController(service);

                Mock<HttpRequest> mockCreateRequest = MockHttpRequest.CreateMockQuery(deleteDeviceRequest.Id);
                return await controller.DeleteDeviceAsync(mockCreateRequest.Object, _logger); //as GridController;

            }
        }

        private async Task<IActionResult> GetDeviceById(GetDeviceByIdRequest getDeviceRequest)
        {

            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "Device")
                .Options;


            // Run the test against one instance of the context
            using (var context = new Context(options))
            {
                var repository = new DeviceRepository(context, AutomapperSingleton.Mapper);
                var service = new DeviceService(repository, AutomapperSingleton.Mapper);
                var controller = new DeviceController(service);

                Mock<HttpRequest> mockGetRequest = MockHttpRequest.CreateMockQuery(getDeviceRequest.Id);
                return await controller.GetDeviceByIdAsync(mockGetRequest.Object, _logger); //as GridController;

            }
        }

        private async Task<DeviceResponse> CreatedDefaultDevice()
        {
            CreateDeviceRequest device = DeviceComponentsValues.CreateDeviceRequestBasic();
            var request = AutomapperSingleton.Mapper.Map<DeviceResponse>(device);

            IActionResult actionResult = await CreateDevice(device);

            ObjectResult objectResult = actionResult is ObjectResult ? actionResult as ObjectResult : null;
            if (objectResult != null && objectResult.Value is Guid)
            {
                var identifier = objectResult.Value as Guid?;

                if (identifier.HasValue)
                {
                    request.Id = identifier.Value;
                }
                else
                {
                    Assert.Fail("Return value isn't a identifier valid");
                }
            }
            else
            {
                Assert.Fail("Imposible create default record");
            }

            return request;
        }
        #endregion
    }
}
