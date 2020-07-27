#region "Libraries"

using Microsoft.AspNetCore.Mvc;
using MPIS.Device.AplicationService.DTOs.Software;
using MPIS.Device.Function.Integration.Tests.APIs;
using MPIS.Device.Function.Integration.Tests.Services;
using MPIS.Device.Function.Integration.Tests.Settings;
using MPIS.Device.Function.Models.Tests.ComponentValues;
using MPIS.Device.Function.Models.Tests.TestCasesSources;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

#endregion

namespace MPIS.Device.Function.Integration.Tests
{
    [Order(3)]
    public class IntegrationTestSoftwareController : TestServiceBase
    {
        SoftwareAzureFunctionAPI _softwareAPI;


        #region "Constructor"

        [SetUp]
        public void Setup()
        {
            _softwareAPI = new SoftwareAzureFunctionAPI();

            //UserComponentsValues.GuidAvailable = Guid.Parse("897e01cd-6cbf-44d6-4d93-08d81e698e7d");
        }

        #endregion

        #region "Create"

        [Test, Order(1)]
        [TestCaseSource(typeof(TestCaseSourcesSoftware), nameof(TestCaseSourcesSoftware.CreateSoftwareTestCases))]
        public async Task TestCreateSoftwareAsync(CreateSoftwareRequest obj, ObjectResult resultAction)
        {
            var request = AutomapperSingleton.Mapper.Map<CreateSoftwareRequest>(obj);

            HttpResponseMessage actionResult = await _softwareAPI.CreateSoftware(request);
            if (actionResult.StatusCode == HttpStatusCode.OK)
            {
                dynamic id = JsonConvert.DeserializeObject(actionResult.Content.ReadAsStringAsync().Result, resultAction.Value.GetType());
                SoftwareComponentsValues.GuidAvailable = (Guid)id;
                //RecordComponentsValues.NameAvailable = obj.Name;
            }
            base.CheckAssert(actionResult, resultAction);
        }

        #endregion

        #region "Update"

        [Test, Order(2)]
        [TestCaseSource(typeof(TestCaseSourcesSoftware), nameof(TestCaseSourcesSoftware.UpdateSoftwareTestCases))]
        public async Task TestUpdateSoftware(UpdateSoftwareRequest obj, ObjectResult resultAction, bool elementCreated = false)
        {

            var createdcompanyId = SoftwareComponentsValues.GetSoftwareAviability();

            obj.Id = elementCreated == true ? createdcompanyId : obj.Id;

            HttpResponseMessage actionResult = await _softwareAPI.UpdateSoftware(obj);

            base.CheckAssert(actionResult, resultAction);
        }

        #endregion

        #region "Get"

        [Test, Order(3)]
        [TestCaseSource(typeof(TestCaseSourcesSoftware), nameof(TestCaseSourcesSoftware.GetSoftwareTestCases))]
        public async Task TestGetSoftware(GetSoftwareByIdRequest com, ObjectResult resultAction, bool elementCreated = false)
        {
            Guid createdcompanyId = SoftwareComponentsValues.GetSoftwareAviability();

            com.Id = elementCreated == true ? createdcompanyId : com.Id;

            HttpResponseMessage actionResult = await _softwareAPI.GetSoftwareById(com);

            base.CheckAssert(actionResult, resultAction);
        }

        #endregion

        #region "Delete"

        [Test, Order(4)]
        [TestCaseSource(typeof(TestCaseSourcesSoftware), nameof(TestCaseSourcesSoftware.DeleteSoftwareTestCases))]
        public async Task TestDeleteSoftware(DeleteSoftwareByIdRequest delcom, ObjectResult resultAction, bool elementCreated = false)
        {

            Guid createdtransactionId = SoftwareComponentsValues.GetSoftwareAviability();

            delcom.Id = elementCreated == true ? createdtransactionId : delcom.Id;

            HttpResponseMessage actionResult = await _softwareAPI.DeleteHardware(delcom);

            base.CheckAssert(actionResult, resultAction);
        }

        #endregion
    }
}
