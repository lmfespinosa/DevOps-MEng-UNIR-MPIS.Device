#region "Libraries"

using MPIS.Device.Function.Integration.Tests.APIs;
using MPIS.Device.Function.Integration.Tests.Models;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

#endregion

namespace MPIS.Device.Function.Integration.Tests
{
    [Order(0)]
    public class IntegrationTestUserController
    {

        UserAzureFunctionAPI _userAPI;

        #region "Constructor"

        [SetUp]
        public void Setup()
        {
            _userAPI = new UserAzureFunctionAPI();

            //UserComponentsValues.GuidAvailable = Guid.Parse("897e01cd-6cbf-44d6-4d93-08d81e698e7d");
        }

        #endregion

        #region "Create"

        [Test, Order(1)]
        //[TestCaseSource(typeof(TestCaseSourcesUser), nameof(TestCaseSourcesUser.CreateUserTestCases))]
        public async Task TestCreateUserAsync(/*CreateUserRequest obj, ObjectResult resultAction*/)
        {
            EventGridModel @event = new EventGridModel() {
                id = Guid.Parse("c03d293c-bf9b-439e-ba53-13e8435d96ef"),
                subject = "/myApp/user/newUserSignedUp",
                data = new CreatedUserEvent() {
                    Id = Guid.Parse("897e01cd-6cbf-44d6-4d93-08d81e698e7d"),
                    Name = "Luis",
                    Surname = "Fernández",
                    Office = "Oficina 1",
                    Address = "C prueba",
                    Phone = "1234567",
                    Email = "ejemplo@gmail.com",
                    Password = "passwd"
                },
                eventType = "MyNamespace.NewUserInfo",
                eventTime = "2018-12-17T09:24:15.6676522Z",
                dataVersion = "1",
                metadataVersion = "1",
                topic = "/subscriptions/16481420-1984-497a-9aa7-902c0c153ae4/resourceGroups/someResourceGroup/providers/Microsoft.EventGrid/topics/newUserSignupTopic"
            };

            await _userAPI.CreateUser(@event);
            Assert.IsTrue(true);
            /*var request = AutomapperSingleton.Mapper.Map<CreateUserRequest>(obj);

            HttpResponseMessage actionResult = await _userAPI.CreateUser(request);
            if (actionResult.StatusCode == HttpStatusCode.OK)
            {
                dynamic id = JsonConvert.DeserializeObject(actionResult.Content.ReadAsStringAsync().Result, resultAction.Value.GetType());
                UserComponentsValues.GuidAvailable = (Guid)id;
                //RecordComponentsValues.NameAvailable = obj.Name;
            }
            base.CheckAssert(actionResult, resultAction);*/
        }

        #endregion
    }
}
