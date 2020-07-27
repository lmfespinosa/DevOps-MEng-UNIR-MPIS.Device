#region "Libraries"

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using MPIS.Device.AplicationService;
using MPIS.Device.AplicationService.DTOs.Hardware;
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
    public partial class UnitTestHardwareController : TestServiceBase
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
        [TestCaseSource(typeof(TestCaseSourcesHardware), nameof(TestCaseSourcesHardware.CreateHardwareTestCases))]
        public async Task TestCreateHardware(CreateHardwareRequest obj, IActionResult resultAction)
        {
            //var request = AutomapperSingleton.Mapper.Map<CreateCompanyRequest>(obj);

            IActionResult actionResult = await CreateHardware(obj);

            var objectResult = actionResult as ObjectResult;
            if (objectResult.StatusCode == 200)
            {
                dynamic id = Guid.Parse(objectResult.Value.ToString());
                HardwareComponentsValues.GuidAvailable = (Guid)id;
                //RecordComponentsValues.NameAvailable = obj.Name;
            }

            base.CheckAssert(actionResult, resultAction);
        }

        #endregion

        #region "Update"

        [Test]
        [TestCaseSource(typeof(TestCaseSourcesHardware), nameof(TestCaseSourcesHardware.UpdateHardwareTestCases))]
        public async Task TestUpdateDevice(UpdateHardwareRequest obj, ObjectResult resultAction, bool elementCreated = false)
        {
            HardwareResponse defaultCompany = await this.CreatedDefaultHardware();

            obj.Id = elementCreated == true ? defaultCompany.Id : obj.Id;

            IActionResult actionResult = await this.UpdateHardware(obj);

            base.CheckAssert(actionResult, resultAction);
        }

        #endregion

        #region "Get"

        [TestCaseSource(typeof(TestCaseSourcesHardware), nameof(TestCaseSourcesHardware.GetHardwareTestCases))]
        public async Task TestGetHardware(GetHardwareByIdRequest getcom, ObjectResult resultAction, bool elementCreated = false)
        {
            HardwareResponse defaultHardware = await this.CreatedDefaultHardware();

            getcom.Id = elementCreated == true ? defaultHardware.Id : getcom.Id;

            IActionResult actionResult = await this.GetHardwareById(getcom);

            base.CheckAssert(actionResult, resultAction);
        }

        #endregion


        #region "Delete"

        [TestCaseSource(typeof(TestCaseSourcesHardware), nameof(TestCaseSourcesHardware.DeleteHardwareTestCases))]
        public async Task TestDeleteHardware(DeleteHardwareByIdRequest delnot, ObjectResult resultAction, bool elementCreated = false)
        {
            HardwareResponse defaultHardware = await this.CreatedDefaultHardware();

            //Guid createdtransactionId = CompanyComponentsValues.GetCompanyAviability();

            delnot.Id = elementCreated == true ? defaultHardware.Id : delnot.Id;

            IActionResult actionResult = await this.DeleteHardware(delnot);

            base.CheckAssert(actionResult, resultAction);
        }

        #endregion

        #region "Private Methods"

        private async Task<IActionResult> CreateHardware(CreateHardwareRequest createHardwareRequest)
        {

            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "Hardware")
                .Options;


            // Run the test against one instance of the context
            using (var context = new Context(options))
            {

                var repository = new HardwareRepository(context, AutomapperSingleton.Mapper);
                var service = new HardwareService(repository, AutomapperSingleton.Mapper);
                var controller = new HardwareController(service);

                Mock<HttpRequest> mockCreateRequest = MockHttpRequest.CreateMockRequest(createHardwareRequest);
                return await controller.CreateHardwareAsync(mockCreateRequest.Object, _logger); //as GridController;

            }
        }

        private async Task<IActionResult> UpdateHardware(UpdateHardwareRequest updateHardwareRequest)
        {

            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "Hardware")
                .Options;



            // Run the test against one instance of the context
            using (var context = new Context(options))
            {
                var repository = new HardwareRepository(context, AutomapperSingleton.Mapper);
                var service = new HardwareService(repository, AutomapperSingleton.Mapper);
                var controller = new HardwareController(service);

                Mock<HttpRequest> mockCreateRequest = MockHttpRequest.CreateMockRequest(updateHardwareRequest);
                return await controller.UpdateHardwareAsync(mockCreateRequest.Object, _logger); //as GridController;

            }
        }

        private async Task<IActionResult> DeleteHardware(DeleteHardwareByIdRequest deleteHardwareRequest)
        {

            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "Hardware")
                .Options;


            // Run the test against one instance of the context
            using (var context = new Context(options))
            {

                var repository = new HardwareRepository(context, AutomapperSingleton.Mapper);
                var service = new HardwareService(repository, AutomapperSingleton.Mapper);
                var controller = new HardwareController(service);

                Mock<HttpRequest> mockCreateRequest = MockHttpRequest.CreateMockQuery(deleteHardwareRequest.Id);
                return await controller.DeleteHardwareAsync(mockCreateRequest.Object, _logger); //as GridController;

            }
        }

        private async Task<IActionResult> GetHardwareById(GetHardwareByIdRequest getHardwareRequest)
        {

            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "Hardware")
                .Options;


            // Run the test against one instance of the context
            using (var context = new Context(options))
            {
                var repository = new HardwareRepository(context, AutomapperSingleton.Mapper);
                var service = new HardwareService(repository, AutomapperSingleton.Mapper);
                var controller = new HardwareController(service);

                Mock<HttpRequest> mockGetRequest = MockHttpRequest.CreateMockQuery(getHardwareRequest.Id);
                return await controller.GetHardwareByIdAsync(mockGetRequest.Object, _logger); //as GridController;

            }
        }

        private async Task<HardwareResponse> CreatedDefaultHardware()
        {
            CreateHardwareRequest hardware = HardwareComponentsValues.CreateHardwareRequestBasic();
            var request = AutomapperSingleton.Mapper.Map<HardwareResponse>(hardware);

            IActionResult actionResult = await CreateHardware(hardware);

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
