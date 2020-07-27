﻿#region "Libraries"

using Microsoft.AspNetCore.Mvc;
using MPIS.Device.AplicationService.DTOs.OperativeSystem;
using MPIS.Device.Function.Models.Tests.ComponentValues;
using NUnit.Framework;
using System;
using System.Collections.Generic;

#endregion

namespace MPIS.Device.Function.Models.Tests.TestCasesSources
{
    public partial class TestCaseSourcesOperativeSystem
    {
        public static IEnumerable<TestCaseData> CreateOperativeSystemTestCases
        {
            get
            {
                yield return new TestCaseData(OperativeSystemComponentsValues.CreateOperativeSystemRequestBasic(), new OkObjectResult(Guid.NewGuid())).SetName("{m}.Create Basic OperativeSystem should be a Guid diferent of 00000000-0000-0000-0000-000000000000");
                //yield return new TestCaseData(UserComponentsValues.CreateUserRequestWithoutOffice(), new OkObjectResult(Guid.NewGuid())).SetName("{m}.Create User without office should be a Guid diferent of 00000000-0000-0000-0000-000000000000");
                //yield return new TestCaseData(UserComponentsValues.CreateUserRequestEmptyOffice(), new OkObjectResult(Guid.NewGuid())).SetName("{m}.Create User with empty office should be a Guid diferent of 00000000-0000-0000-0000-000000000000");
                //yield return new TestCaseData(UserComponentsValues.CreateUserRequestWithoutAddress(), new OkObjectResult(Guid.NewGuid())).SetName("{m}.Create User without address should be a Guid diferent of 00000000-0000-0000-0000-000000000000");
                //yield return new TestCaseData(UserComponentsValues.CreateUserRequestEmptyAddress(), new OkObjectResult(Guid.NewGuid())).SetName("{m}.Create User with empty address should be a Guid diferent of 00000000-0000-0000-0000-000000000000");
                //yield return new TestCaseData(UserComponentsValues.CreateUserRequestEmpty(), new BadRequestObjectResult(new Exception(string.Empty))).SetName("{m}.Create empty User should be 400 response");
                //yield return new TestCaseData(UserComponentsValues.CreateUserRequestWithoutName(), new BadRequestObjectResult(new Exception(string.Empty))).SetName("{m}.Create user without Name should be 400 response");
                //yield return new TestCaseData(UserComponentsValues.CreateUserRequestEmptyName(), new BadRequestObjectResult(new Exception(string.Empty))).SetName("{m}.Create user with Empty Name should be 400 response");
                //yield return new TestCaseData(UserComponentsValues.CreateUserRequestWithoutSurame(), new BadRequestObjectResult(new Exception(string.Empty))).SetName("{m}.Create user without Surnmae should be 400 response");
                //yield return new TestCaseData(UserComponentsValues.CreateUserRequestEmptySurame(), new BadRequestObjectResult(new Exception(string.Empty))).SetName("{m}.Create user with Empty Surnmae should be 400 response");
                //yield return new TestCaseData(NotificationComponentsValues.CreateNotificationRequestWithOutReason(), new BadRequestObjectResult(new TemplateException(string.Empty))).SetName("{m}.Create Notification without reason should be 400 response");
                //yield return new TestCaseData(NotificationComponentsValues.CreateNotificationRequestWithOutText(), new BadRequestObjectResult(new TemplateException(string.Empty))).SetName("{m}.Create Notification without text should be 400 response");
                //yield return new TestCaseData(NotificationComponentsValues.CreateNotificationRequestWithTypeNotificationBigerThan1000(), new BadRequestObjectResult(new TemplateException(string.Empty))).SetName("{m}.Create Notification with TypeNotification bigger than 1000 should be 400 response");
                //yield return new TestCaseData(NotificationComponentsValues.CreateNotificationRequestWithTypeNotificationNegative(), new BadRequestObjectResult(new TemplateException(string.Empty))).SetName("{m}.Create Notification with TypeNotification negative should be 400 response");
            }
        }

        public static IEnumerable<TestCaseData> UpdateOperativeSystemTestCases
        {
            get
            {
                yield return new TestCaseData(OperativeSystemComponentsValues.UpdateOperativeSystemRequestBasic(), new OkObjectResult(true), true).SetName("{m}.Update Basic OperativeSystem Type should be a Guid diferent of 00000000-0000-0000-0000-000000000000 should be OK");
                //yield return new TestCaseData(UserComponentsValues.UpdateUserRequestEmptyOffice(), new OkObjectResult(true), true).SetName("{m}.Update user with empty Office should be a Guid diferent of 00000000-0000-0000-0000-000000000000 should be OK");
                //yield return new TestCaseData(UserComponentsValues.UpdateUserRequestWithoutOffice(), new OkObjectResult(true), true).SetName("{m}.Update user without Office should be a Guid diferent of 00000000-0000-0000-0000-000000000000 should be OK");
                //yield return new TestCaseData(UserComponentsValues.UpdateUserRequestEmptyAddress(), new OkObjectResult(true), true).SetName("{m}.Update user with empty Address should be a Guid diferent of 00000000-0000-0000-0000-000000000000 should be OK");
                //yield return new TestCaseData(UserComponentsValues.UpdateUserRequestWithoutAddress(), new OkObjectResult(true), true).SetName("{m}.Update user without address should be a Guid diferent of 00000000-0000-0000-0000-000000000000 should be OK");
                //yield return new TestCaseData(UserComponentsValues.UpdateUserRequestWithoutName(), new BadRequestObjectResult(new Exception(string.Empty)), true).SetName("{m}.Update user without Name should be 400 response");
                //yield return new TestCaseData(UserComponentsValues.UpdateUserRequestEmptyName(), new BadRequestObjectResult(new Exception(string.Empty)), true).SetName("{m}.Update user with empty Name should be 400 response");
                //yield return new TestCaseData(UserComponentsValues.UpdateUserRequestWithoutSurame(), new BadRequestObjectResult(new Exception(string.Empty)), true).SetName("{m}.Update user without Surnmae should be 400 response");
                //yield return new TestCaseData(UserComponentsValues.UpdateUserRequestEmptySurame(), new BadRequestObjectResult(new Exception(string.Empty)), true).SetName("{m}.Update user with empty Surnmae should be 400 response");
                //yield return new TestCaseData(NotificationComponentsValues.UpdateNotificationRequestDefaultUserId(), new BadRequestObjectResult(new TemplateException(string.Empty)), true).SetName("{m}.Update Notification with default UserId should be 400 response");
                //yield return new TestCaseData(NotificationComponentsValues.UpdateNotificationRequestWithOutReason(), new BadRequestObjectResult(new TemplateException(string.Empty)), true).SetName("{m}.Update Notification without reason should be 400 response");
                //yield return new TestCaseData(NotificationComponentsValues.UpdateNotificationRequestWithOutText(), new BadRequestObjectResult(new TemplateException(string.Empty)), true).SetName("{m}.Update Notification without text should be 400 response");
                //yield return new TestCaseData(NotificationComponentsValues.UpdateNotificationRequestWithTypeNotificationBigerThan1000(), new BadRequestObjectResult(new TemplateException(string.Empty)), true).SetName("{m}.Update Notification with TypeNotification bigger than 1000 should be 400 response");
                //yield return new TestCaseData(NotificationComponentsValues.UpdateNotificationRequestWithTypeNotificationNegative(), new BadRequestObjectResult(new TemplateException(string.Empty)), true).SetName("{m}.Update Notification with TypeNotification negative should be 400 response");
            }
        }

        public static IEnumerable<TestCaseData> GetOperativeSystemTestCases
        {
            get
            {
                yield return new TestCaseData(OperativeSystemComponentsValues.GetOperativeSystemByIdRequestAviability(), new OkObjectResult(new OperativeSystemResponse()), true).SetName("{m}.Get OperativeSystem by id Aviability should be OK");
                yield return new TestCaseData(OperativeSystemComponentsValues.GetOperativeSystemByIdRequestNewGuid(), new ObjectResult(string.Empty) { StatusCode = 204 }, false).SetName("{m}.Get OperativeSystem diferent GUid should be 204 response");
                yield return new TestCaseData(OperativeSystemComponentsValues.GetOperativeSystemByIdRequestDefault(), new BadRequestObjectResult(new Exception(string.Empty)), false).SetName("{m}.Get OperativeSystem diferent GUid should be 400 response");
            }
        }


        public static IEnumerable<TestCaseData> DeleteOperativeSystemTestCases
        {
            get
            {
                yield return new TestCaseData(OperativeSystemComponentsValues.DeleteOperativeSystemRequestAviability(), new OkObjectResult(true), true).SetName("{m}.Delete OperativeSystem Aviability should be OK");
                yield return new TestCaseData(OperativeSystemComponentsValues.DeleteOperativeSystemRequestNewGuid(), new BadRequestObjectResult(new Exception(string.Empty)), false).SetName("{m}.Delete OperativeSystem New Guid should be 400 response");
                yield return new TestCaseData(OperativeSystemComponentsValues.DeleteOperativeSystemRequestDefault(), new BadRequestObjectResult(new Exception(string.Empty)), false).SetName("{m}.Delete OperativeSystem default Guid should be 400 response");
            }
        }
    }
}

