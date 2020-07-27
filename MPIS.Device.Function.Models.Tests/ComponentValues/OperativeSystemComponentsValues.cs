#region "Libraries"

using MPIS.Device.AplicationService.DTOs.OperativeSystem;
using System;

#endregion

namespace MPIS.Device.Function.Models.Tests.ComponentValues
{
    public class OperativeSystemComponentsValues
    {
        public static Guid GuidAvailable { get; set; }
        static Guid GuidDefault { get; set; }
        public static Guid GetOperativeSystemGuidAvailable() => GuidAvailable;
        public static Guid GetOperativeSystemDefault() => default;
        public static Guid GetOperativeSystemNewGuid() => Guid.NewGuid();
        public static Guid GetOperativeSystemAviability() => OperativeSystemComponentsValues.GuidAvailable;

        #region "Create"

        public static CreateOperativeSystemRequest CreateOperativeSystemRequestBasic() => new CreateOperativeSystemRequest()
        {
            MACDevice = "0000000",
            Name = "Widnows 10"
        };

        #endregion

        #region "Update"

        public static UpdateOperativeSystemRequest UpdateOperativeSystemRequestBasic() => new UpdateOperativeSystemRequest()
        {
            Id = GuidAvailable,
            MACDevice = "0000000",
            Name = "Widnows 10"
        };

        #endregion

        #region "Get"

        public static GetOperativeSystemByIdRequest GetOperativeSystemByIdRequestAviability() => new GetOperativeSystemByIdRequest()
        {
            Id = GuidAvailable
        };

        public static GetOperativeSystemByIdRequest GetOperativeSystemByIdRequestNewGuid() => new GetOperativeSystemByIdRequest()
        {
            Id = GetOperativeSystemNewGuid()
        };

        public static GetOperativeSystemByIdRequest GetOperativeSystemByIdRequestDefault() => new GetOperativeSystemByIdRequest()
        {
            Id = GuidDefault
        };

        #endregion

        #region "Delete"

        public static DeleteOperativeSystemByIdRequest DeleteOperativeSystemRequestAviability() => new DeleteOperativeSystemByIdRequest()
        {
            Id = GuidAvailable
        };

        public static DeleteOperativeSystemByIdRequest DeleteOperativeSystemRequestNewGuid() => new DeleteOperativeSystemByIdRequest()
        {
            Id = GetOperativeSystemNewGuid()
        };

        public static DeleteOperativeSystemByIdRequest DeleteOperativeSystemRequestDefault() => new DeleteOperativeSystemByIdRequest()
        {
            Id = GuidDefault
        };

        #endregion
    }
}
