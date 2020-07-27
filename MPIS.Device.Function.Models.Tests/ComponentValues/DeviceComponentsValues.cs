#region "Libraries"

using MPIS.Device.AplicationService.DTOs.Device;
using System;

#endregion 

namespace MPIS.Device.Function.Models.Tests.ComponentValues
{
    public class DeviceComponentsValues
    {
        public static Guid GuidAvailable { get; set; }
        static Guid GuidDefault { get; set; }
        public static Guid GetDeviceGuidAvailable() => GuidAvailable;
        public static Guid GetDeviceDefault() => default;
        public static Guid GetDeviceNewGuid() => Guid.NewGuid();
        public static Guid GetDeviceAviability() => DeviceComponentsValues.GuidAvailable;

        #region "Create"

        public static CreateDeviceRequest CreateDeviceRequestBasic() => new CreateDeviceRequest()
        {
           MAC = "0000000",
            ComputerName = "Test Computer",
            TypeSO = TypeSODTO.Windows,
            EmailUser = "email@test.com"

        };

        #endregion

        #region "Update"

        public static UpdateDeviceRequest UpdateDeviceRequestBasic() => new UpdateDeviceRequest()
        {
            Id = GuidAvailable,
            MAC = "0000000",
            ComputerName = "Test Computer",
            TypeSO = TypeSODTO.Windows,
            EmailUser = "email@test.com"

        };

        #endregion

        #region "Get"

        public static GetDeviceByIdRequest GetDeviceByIdRequestAviability() => new GetDeviceByIdRequest()
        {
            Id = GuidAvailable
        };

        public static GetDeviceByIdRequest GetDeviceByIdRequestNewGuid() => new GetDeviceByIdRequest()
        {
            Id = GetDeviceNewGuid()
        };

        public static GetDeviceByIdRequest GetDeviceByIdRequestDefault() => new GetDeviceByIdRequest()
        {
            Id = GuidDefault
        };

        #endregion

        #region "Delete"

        public static DeleteDeviceByIdRequest DeleteDeviceRequestAviability() => new DeleteDeviceByIdRequest()
        {
            Id = GuidAvailable
        };

        public static DeleteDeviceByIdRequest DeleteDeviceRequestNewGuid() => new DeleteDeviceByIdRequest()
        {
            Id = GetDeviceNewGuid()
        };

        public static DeleteDeviceByIdRequest DeleteDeviceRequestDefault() => new DeleteDeviceByIdRequest()
        {
            Id = GuidDefault
        };

        #endregion
    }
}
