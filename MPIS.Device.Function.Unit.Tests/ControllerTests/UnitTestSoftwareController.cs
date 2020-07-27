#region "Libraries"

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using MPIS.Device.AplicationService;
using MPIS.Device.AplicationService.DTOs.Software;
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
    public partial class UnitTestSoftwareController : TestServiceBase
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
        [TestCaseSource(typeof(TestCaseSourcesSoftware), nameof(TestCaseSourcesSoftware.CreateSoftwareTestCases))]
        public async Task TestCreateSoftware(CreateSoftwareRequest obj, IActionResult resultAction)
        {
            //var request = AutomapperSingleton.Mapper.Map<CreateCompanyRequest>(obj);

            IActionResult actionResult = await CreateSoftware(obj);

            var objectResult = actionResult as ObjectResult;
            if (objectResult.StatusCode == 200)
            {
                dynamic id = Guid.Parse(objectResult.Value.ToString());
                SoftwareComponentsValues.GuidAvailable = (Guid)id;
                //RecordComponentsValues.NameAvailable = obj.Name;
            }

            base.CheckAssert(actionResult, resultAction);
        }

        #endregion

        #region "Update"

        [Test]
        [TestCaseSource(typeof(TestCaseSourcesSoftware), nameof(TestCaseSourcesSoftware.UpdateSoftwareTestCases))]
        public async Task TestUpdateDevice(UpdateSoftwareRequest obj, ObjectResult resultAction, bool elementCreated = false)
        {
            SoftwareResponse defaultCompany = await this.CreatedDefaultSoftware();

            obj.Id = elementCreated == true ? defaultCompany.Id : obj.Id;

            IActionResult actionResult = await this.UpdateSoftware(obj);

            base.CheckAssert(actionResult, resultAction);
        }

        #endregion

        #region "Get"

        [TestCaseSource(typeof(TestCaseSourcesSoftware), nameof(TestCaseSourcesSoftware.GetSoftwareTestCases))]
        public async Task TestGetHardware(GetSoftwareByIdRequest getcom, ObjectResult resultAction, bool elementCreated = false)
        {
            SoftwareResponse defaultHardware = await this.CreatedDefaultSoftware();

            getcom.Id = elementCreated == true ? defaultHardware.Id : getcom.Id;

            IActionResult actionResult = await this.GetSoftwareById(getcom);

            base.CheckAssert(actionResult, resultAction);
        }

        #endregion


        #region "Delete"

        [TestCaseSource(typeof(TestCaseSourcesSoftware), nameof(TestCaseSourcesSoftware.DeleteSoftwareTestCases))]
        public async Task TestDeleteHardware(DeleteSoftwareByIdRequest delnot, ObjectResult resultAction, bool elementCreated = false)
        {
            SoftwareResponse defaultHardware = await this.CreatedDefaultSoftware();

            //Guid createdtransactionId = CompanyComponentsValues.GetCompanyAviability();

            delnot.Id = elementCreated == true ? defaultHardware.Id : delnot.Id;

            IActionResult actionResult = await this.DeleteSoftware(delnot);

            base.CheckAssert(actionResult, resultAction);
        }

        #endregion

        #region "Private Methods"

        private async Task<IActionResult> CreateSoftware(CreateSoftwareRequest createSoftwareRequest)
        {

            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "Software")
                .Options;


            // Run the test against one instance of the context
            using (var context = new Context(options))
            {

                var repository = new SoftwareRepository(context, AutomapperSingleton.Mapper);
                var service = new SoftwareService(repository, AutomapperSingleton.Mapper);
                var controller = new SoftwareController(service);

                Mock<HttpRequest> mockCreateRequest = MockHttpRequest.CreateMockRequest(createSoftwareRequest);
                return await controller.CreateSoftwareAsync(mockCreateRequest.Object, _logger); //as GridController;

            }
        }

        private async Task<IActionResult> UpdateSoftware(UpdateSoftwareRequest updateSoftwareRequest)
        {

            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "Software")
                .Options;



            // Run the test against one instance of the context
            using (var context = new Context(options))
            {
                var repository = new SoftwareRepository(context, AutomapperSingleton.Mapper);
                var service = new SoftwareService(repository, AutomapperSingleton.Mapper);
                var controller = new SoftwareController(service);

                Mock<HttpRequest> mockCreateRequest = MockHttpRequest.CreateMockRequest(updateSoftwareRequest);
                return await controller.UpdateSoftwareAsync(mockCreateRequest.Object, _logger); //as GridController;

            }
        }

        private async Task<IActionResult> DeleteSoftware(DeleteSoftwareByIdRequest deleteSoftwareRequest)
        {

            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "Software")
                .Options;


            // Run the test against one instance of the context
            using (var context = new Context(options))
            {

                var repository = new SoftwareRepository(context, AutomapperSingleton.Mapper);
                var service = new SoftwareService(repository, AutomapperSingleton.Mapper);
                var controller = new SoftwareController(service);

                Mock<HttpRequest> mockCreateRequest = MockHttpRequest.CreateMockQuery(deleteSoftwareRequest.Id);
                return await controller.DeleteSoftwareAsync(mockCreateRequest.Object, _logger); //as GridController;

            }
        }

        private async Task<IActionResult> GetSoftwareById(GetSoftwareByIdRequest getSoftwareRequest)
        {

            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "Software")
                .Options;


            // Run the test against one instance of the context
            using (var context = new Context(options))
            {
                var repository = new SoftwareRepository(context, AutomapperSingleton.Mapper);
                var service = new SoftwareService(repository, AutomapperSingleton.Mapper);
                var controller = new SoftwareController(service);

                Mock<HttpRequest> mockGetRequest = MockHttpRequest.CreateMockQuery(getSoftwareRequest.Id);
                return await controller.GetSoftwareByIdAsync(mockGetRequest.Object, _logger); //as GridController;

            }
        }

        private async Task<SoftwareResponse> CreatedDefaultSoftware()
        {
            CreateSoftwareRequest hardware = SoftwareComponentsValues.CreateSoftwareRequestBasic();
            var request = AutomapperSingleton.Mapper.Map<SoftwareResponse>(hardware);

            IActionResult actionResult = await CreateSoftware(hardware);

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
