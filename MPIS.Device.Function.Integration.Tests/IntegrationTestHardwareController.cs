#region "Libraries"

using Microsoft.AspNetCore.Mvc;
using MPIS.Device.AplicationService.DTOs.Hardware;
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
    [Order(2)]
    class IntegrationTestHardwareController : TestServiceBase
    {
        HardwareAzureFunctionAPI _hardwareAPI;


        #region "Constructor"

        [SetUp]
        public void Setup()
        {
            _hardwareAPI = new HardwareAzureFunctionAPI();

            //UserComponentsValues.GuidAvailable = Guid.Parse("897e01cd-6cbf-44d6-4d93-08d81e698e7d");
        }

        #endregion

        #region "Create"

        [Test, Order(1)]
        [TestCaseSource(typeof(TestCaseSourcesHardware), nameof(TestCaseSourcesHardware.CreateHardwareTestCases))]
        public async Task TestCreateHardwareAsync(CreateHardwareRequest obj, ObjectResult resultAction)
        {
            var request = AutomapperSingleton.Mapper.Map<CreateHardwareRequest>(obj);

            HttpResponseMessage actionResult = await _hardwareAPI.CreateHardware(request);
            if (actionResult.StatusCode == HttpStatusCode.OK)
            {
                dynamic id = JsonConvert.DeserializeObject(actionResult.Content.ReadAsStringAsync().Result, resultAction.Value.GetType());
                HardwareComponentsValues.GuidAvailable = (Guid)id;
                //RecordComponentsValues.NameAvailable = obj.Name;
            }
            base.CheckAssert(actionResult, resultAction);
        }

        #endregion

        #region "Update"

        [Test, Order(2)]
        [TestCaseSource(typeof(TestCaseSourcesHardware), nameof(TestCaseSourcesHardware.UpdateHardwareTestCases))]
        public async Task TestUpdateHardware(UpdateHardwareRequest obj, ObjectResult resultAction, bool elementCreated = false)
        {

            var createdcompanyId = HardwareComponentsValues.GetHardwareAviability();

            obj.Id = elementCreated == true ? createdcompanyId : obj.Id;

            HttpResponseMessage actionResult = await _hardwareAPI.UpdateHardware(obj);

            base.CheckAssert(actionResult, resultAction);
        }

        #endregion

        #region "Get"

        [Test, Order(3)]
        [TestCaseSource(typeof(TestCaseSourcesHardware), nameof(TestCaseSourcesHardware.GetHardwareTestCases))]
        public async Task TestGetDevice(GetHardwareByIdRequest com, ObjectResult resultAction, bool elementCreated = false)
        {
            Guid createdcompanyId = HardwareComponentsValues.GetHardwareAviability();

            com.Id = elementCreated == true ? createdcompanyId : com.Id;

            HttpResponseMessage actionResult = await _hardwareAPI.GetHardwareById(com);

            base.CheckAssert(actionResult, resultAction);
        }

        #endregion

        #region "Delete"

        [Test, Order(4)]
        [TestCaseSource(typeof(TestCaseSourcesHardware), nameof(TestCaseSourcesHardware.DeleteHardwareTestCases))]
        public async Task TestDeleteDevice(DeleteHardwareByIdRequest delcom, ObjectResult resultAction, bool elementCreated = false)
        {

            Guid createdtransactionId = HardwareComponentsValues.GetHardwareAviability();

            delcom.Id = elementCreated == true ? createdtransactionId : delcom.Id;

            HttpResponseMessage actionResult = await _hardwareAPI.DeleteHardware(delcom);

            base.CheckAssert(actionResult, resultAction);
        }

        #endregion
    }
}
