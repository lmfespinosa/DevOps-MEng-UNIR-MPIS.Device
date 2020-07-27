#region "Libraries"

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using MPIS.Device.AplicationService;
using MPIS.Device.AplicationService.DTOs.OperativeSystem;
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
    public partial class UnitTestOperativeSystemController : TestServiceBase
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
        [TestCaseSource(typeof(TestCaseSourcesOperativeSystem), nameof(TestCaseSourcesOperativeSystem.CreateOperativeSystemTestCases))]
        public async Task TestCreateOperativeSystem(CreateOperativeSystemRequest obj, IActionResult resultAction)
        {
            //var request = AutomapperSingleton.Mapper.Map<CreateCompanyRequest>(obj);

            IActionResult actionResult = await CreateOperativeSystem(obj);

            var objectResult = actionResult as ObjectResult;
            if (objectResult.StatusCode == 200)
            {
                dynamic id = Guid.Parse(objectResult.Value.ToString());
                OperativeSystemComponentsValues.GuidAvailable = (Guid)id;
                //RecordComponentsValues.NameAvailable = obj.Name;
            }

            base.CheckAssert(actionResult, resultAction);
        }

        #endregion

        #region "Update"

        [Test]
        [TestCaseSource(typeof(TestCaseSourcesOperativeSystem), nameof(TestCaseSourcesOperativeSystem.UpdateOperativeSystemTestCases))]
        public async Task TestUpdateOperativeSystem(UpdateOperativeSystemRequest obj, ObjectResult resultAction, bool elementCreated = false)
        {
            OperativeSystemResponse defaultCompany = await this.CreatedDefaultOperativeSystem();

            obj.Id = elementCreated == true ? defaultCompany.Id : obj.Id;

            IActionResult actionResult = await this.UpdateOperativeSystem(obj);

            base.CheckAssert(actionResult, resultAction);
        }

        #endregion

        #region "Get"

        [TestCaseSource(typeof(TestCaseSourcesOperativeSystem), nameof(TestCaseSourcesOperativeSystem.GetOperativeSystemTestCases))]
        public async Task TestGetOperativeSystem(GetOperativeSystemByIdRequest getcom, ObjectResult resultAction, bool elementCreated = false)
        {
            OperativeSystemResponse defaultHardware = await this.CreatedDefaultOperativeSystem();

            getcom.Id = elementCreated == true ? defaultHardware.Id : getcom.Id;

            IActionResult actionResult = await this.GetOperativeSystemById(getcom);

            base.CheckAssert(actionResult, resultAction);
        }

        #endregion


        #region "Delete"

        [TestCaseSource(typeof(TestCaseSourcesOperativeSystem), nameof(TestCaseSourcesOperativeSystem.DeleteOperativeSystemTestCases))]
        public async Task TestDeleteOperativeSystem(DeleteOperativeSystemByIdRequest delnot, ObjectResult resultAction, bool elementCreated = false)
        {
            OperativeSystemResponse defaultHardware = await this.CreatedDefaultOperativeSystem();

            //Guid createdtransactionId = CompanyComponentsValues.GetCompanyAviability();

            delnot.Id = elementCreated == true ? defaultHardware.Id : delnot.Id;

            IActionResult actionResult = await this.DeleteOperativeSystem(delnot);

            base.CheckAssert(actionResult, resultAction);
        }

        #endregion

        #region "Private Methods"

        private async Task<IActionResult> CreateOperativeSystem(CreateOperativeSystemRequest createOperativeSystemRequest)
        {

            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "OperativeSystem")
                .Options;


            // Run the test against one instance of the context
            using (var context = new Context(options))
            {

                var repository = new OperativeSystemRepository(context, AutomapperSingleton.Mapper);
                var service = new OperativeSystemService(repository, AutomapperSingleton.Mapper);
                var controller = new OperativeSystemController(service);

                Mock<HttpRequest> mockCreateRequest = MockHttpRequest.CreateMockRequest(createOperativeSystemRequest);
                return await controller.CreateOperativeSystemAsync(mockCreateRequest.Object, _logger); //as GridController;

            }
        }

        private async Task<IActionResult> UpdateOperativeSystem(UpdateOperativeSystemRequest updateOperativeSystemRequest)
        {

            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "OperativeSystem")
                .Options;



            // Run the test against one instance of the context
            using (var context = new Context(options))
            {
                var repository = new OperativeSystemRepository(context, AutomapperSingleton.Mapper);
                var service = new OperativeSystemService(repository, AutomapperSingleton.Mapper);
                var controller = new OperativeSystemController(service);

                Mock<HttpRequest> mockCreateRequest = MockHttpRequest.CreateMockRequest(updateOperativeSystemRequest);
                return await controller.UpdateOperativeSystemAsync(mockCreateRequest.Object, _logger); //as GridController;

            }
        }

        private async Task<IActionResult> DeleteOperativeSystem(DeleteOperativeSystemByIdRequest deleteOperativeSystemRequest)
        {

            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "OperativeSystem")
                .Options;


            // Run the test against one instance of the context
            using (var context = new Context(options))
            {

                var repository = new OperativeSystemRepository(context, AutomapperSingleton.Mapper);
                var service = new OperativeSystemService(repository, AutomapperSingleton.Mapper);
                var controller = new OperativeSystemController(service);

                Mock<HttpRequest> mockCreateRequest = MockHttpRequest.CreateMockQuery(deleteOperativeSystemRequest.Id);
                return await controller.DeleteOperativeSystemAsync(mockCreateRequest.Object, _logger); //as GridController;

            }
        }

        private async Task<IActionResult> GetOperativeSystemById(GetOperativeSystemByIdRequest getOperativeSystemRequest)
        {

            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "OperativeSystem")
                .Options;


            // Run the test against one instance of the context
            using (var context = new Context(options))
            {
                var repository = new OperativeSystemRepository(context, AutomapperSingleton.Mapper);
                var service = new OperativeSystemService(repository, AutomapperSingleton.Mapper);
                var controller = new OperativeSystemController(service);

                Mock<HttpRequest> mockGetRequest = MockHttpRequest.CreateMockQuery(getOperativeSystemRequest.Id);
                return await controller.GetOperativeSystemByIdAsync(mockGetRequest.Object, _logger); //as GridController;

            }
        }

        private async Task<OperativeSystemResponse> CreatedDefaultOperativeSystem()
        {
            CreateOperativeSystemRequest hardware = OperativeSystemComponentsValues.CreateOperativeSystemRequestBasic();
            var request = AutomapperSingleton.Mapper.Map<OperativeSystemResponse>(hardware);

            IActionResult actionResult = await CreateOperativeSystem(hardware);

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
