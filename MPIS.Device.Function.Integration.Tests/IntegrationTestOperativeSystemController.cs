#region "Libraries"

using Microsoft.AspNetCore.Mvc;
using MPIS.Device.AplicationService.DTOs.OperativeSystem;
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
    [Order(4)]
    public class IntegrationTestOperativeSystemController : TestServiceBase
    {
        OperativeSystemAzureFunctionAPI _operativeSystemAPI;


        #region "Constructor"

        [SetUp]
        public void Setup()
        {
            _operativeSystemAPI = new OperativeSystemAzureFunctionAPI();

            //UserComponentsValues.GuidAvailable = Guid.Parse("897e01cd-6cbf-44d6-4d93-08d81e698e7d");
        }

        #endregion

        #region "Create"

        [Test, Order(1)]
        [TestCaseSource(typeof(TestCaseSourcesOperativeSystem), nameof(TestCaseSourcesOperativeSystem.CreateOperativeSystemTestCases))]
        public async Task TestCreateOperativeSystemAsync(CreateOperativeSystemRequest obj, ObjectResult resultAction)
        {
            var request = AutomapperSingleton.Mapper.Map<CreateOperativeSystemRequest>(obj);

            HttpResponseMessage actionResult = await _operativeSystemAPI.CreateOperativeSystem(request);
            if (actionResult.StatusCode == HttpStatusCode.OK)
            {
                dynamic id = JsonConvert.DeserializeObject(actionResult.Content.ReadAsStringAsync().Result, resultAction.Value.GetType());
                OperativeSystemComponentsValues.GuidAvailable = (Guid)id;
                //RecordComponentsValues.NameAvailable = obj.Name;
            }
            base.CheckAssert(actionResult, resultAction);
        }

        #endregion

        #region "Update"

        [Test, Order(2)]
        [TestCaseSource(typeof(TestCaseSourcesOperativeSystem), nameof(TestCaseSourcesOperativeSystem.UpdateOperativeSystemTestCases))]
        public async Task TestUpdateOperativeSystem(UpdateOperativeSystemRequest obj, ObjectResult resultAction, bool elementCreated = false)
        {

            var createdcompanyId = OperativeSystemComponentsValues.GetOperativeSystemAviability();

            obj.Id = elementCreated == true ? createdcompanyId : obj.Id;

            HttpResponseMessage actionResult = await _operativeSystemAPI.UpdateOperativeSystem(obj);

            base.CheckAssert(actionResult, resultAction);
        }

        #endregion

        #region "Get"

        [Test, Order(3)]
        [TestCaseSource(typeof(TestCaseSourcesOperativeSystem), nameof(TestCaseSourcesOperativeSystem.GetOperativeSystemTestCases))]
        public async Task TestGetOperativeSystem(GetOperativeSystemByIdRequest com, ObjectResult resultAction, bool elementCreated = false)
        {
            Guid createdcompanyId = OperativeSystemComponentsValues.GetOperativeSystemAviability();

            com.Id = elementCreated == true ? createdcompanyId : com.Id;

            HttpResponseMessage actionResult = await _operativeSystemAPI.GetOperativeSystemById(com);

            base.CheckAssert(actionResult, resultAction);
        }

        #endregion

        #region "Delete"

        [Test, Order(4)]
        [TestCaseSource(typeof(TestCaseSourcesOperativeSystem), nameof(TestCaseSourcesOperativeSystem.DeleteOperativeSystemTestCases))]
        public async Task TestDeleteOperativeSystem(DeleteOperativeSystemByIdRequest delcom, ObjectResult resultAction, bool elementCreated = false)
        {

            Guid createdtransactionId = OperativeSystemComponentsValues.GetOperativeSystemAviability();

            delcom.Id = elementCreated == true ? createdtransactionId : delcom.Id;

            HttpResponseMessage actionResult = await _operativeSystemAPI.DeleteOperativeSystem(delcom);

            base.CheckAssert(actionResult, resultAction);
        }

        #endregion
    }
}
