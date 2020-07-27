#region "Libraries"

using Microsoft.AspNetCore.Mvc;
using MPIS.Device.AplicationService.DTOs.Device;
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
    [Order(1)]
    public class IntegrationTestDeviceController : TestServiceBase
    {
        DeviceAzureFunctionAPI _deviceAPI;


        #region "Constructor"

        [SetUp]
        public void Setup()
        {
            _deviceAPI = new DeviceAzureFunctionAPI();

            //UserComponentsValues.GuidAvailable = Guid.Parse("897e01cd-6cbf-44d6-4d93-08d81e698e7d");
        }

        #endregion

        #region "Create"

        [Test, Order(1)]
        [TestCaseSource(typeof(TestCaseSourcesDevice), nameof(TestCaseSourcesDevice.CreateDeviceTestCases))]
        public async Task TestCreateDeviceAsync(CreateDeviceRequest obj, ObjectResult resultAction)
        {
            var request = AutomapperSingleton.Mapper.Map<CreateDeviceRequest>(obj);

            HttpResponseMessage actionResult = await _deviceAPI.CreateDevice(request);
            if (actionResult.StatusCode == HttpStatusCode.OK)
            {
                dynamic id = JsonConvert.DeserializeObject(actionResult.Content.ReadAsStringAsync().Result, resultAction.Value.GetType());
                DeviceComponentsValues.GuidAvailable = (Guid)id;
                //RecordComponentsValues.NameAvailable = obj.Name;
            }
            base.CheckAssert(actionResult, resultAction);
        }

        #endregion

        #region "Update"

        [Test, Order(2)]
        [TestCaseSource(typeof(TestCaseSourcesDevice), nameof(TestCaseSourcesDevice.UpdateDeviceTestCases))]
        public async Task TestUpdateDevice(UpdateDeviceRequest obj, ObjectResult resultAction, bool elementCreated = false)
        {

            var createdcompanyId = DeviceComponentsValues.GetDeviceAviability();

            obj.Id = elementCreated == true ? createdcompanyId : obj.Id;

            HttpResponseMessage actionResult = await _deviceAPI.UpdateDevice(obj);

            base.CheckAssert(actionResult, resultAction);
        }

        #endregion

        #region "Get"

        [Test, Order(3)]
        [TestCaseSource(typeof(TestCaseSourcesDevice), nameof(TestCaseSourcesDevice.GetDeviceTestCases))]
        public async Task TestGetDevice(GetDeviceByIdRequest com, ObjectResult resultAction, bool elementCreated = false)
        {
            Guid createdcompanyId = DeviceComponentsValues.GetDeviceAviability();

            com.Id = elementCreated == true ? createdcompanyId : com.Id;

            HttpResponseMessage actionResult = await _deviceAPI.GetDeviceById(com);

            base.CheckAssert(actionResult, resultAction);
        }

        #endregion

        #region "Delete"

        [Test, Order(4)]
        [TestCaseSource(typeof(TestCaseSourcesDevice), nameof(TestCaseSourcesDevice.DeleteDeviceTestCases))]
        public async Task TestDeleteDevice(DeleteDeviceByIdRequest delcom, ObjectResult resultAction, bool elementCreated = false)
        {

            Guid createdtransactionId = DeviceComponentsValues.GetDeviceAviability();

            delcom.Id = elementCreated == true ? createdtransactionId : delcom.Id;

            HttpResponseMessage actionResult = await _deviceAPI.DeleteDevice(delcom);

            base.CheckAssert(actionResult, resultAction);
        }

        #endregion
    }
}
