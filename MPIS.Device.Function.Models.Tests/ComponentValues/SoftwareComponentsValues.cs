using MPIS.Device.AplicationService.DTOs.Software;
using System;
using System.Collections.Generic;
using System.Text;

namespace MPIS.Device.Function.Models.Tests.ComponentValues
{
    public class SoftwareComponentsValues
    {
        public static Guid GuidAvailable { get; set; }
        static Guid GuidDefault { get; set; }
        public static Guid GetSoftwareGuidAvailable() => GuidAvailable;
        public static Guid GetSoftwareDefault() => default;
        public static Guid GetSoftwareNewGuid() => Guid.NewGuid();
        public static Guid GetSoftwareAviability() => SoftwareComponentsValues.GuidAvailable;

        #region "Create"

        public static CreateSoftwareRequest CreateSoftwareRequestBasic() => new CreateSoftwareRequest()
        {
            MACDevice = "0000000",
            Name = "Software 1"

        };

        #endregion

        #region "Update"

        public static UpdateSoftwareRequest UpdateSoftwareRequestBasic() => new UpdateSoftwareRequest()
        {
            Id = GuidAvailable,
            MACDevice = "0000000",
            Name = "Software 1"

        };

        #endregion

        #region "Get"

        public static GetSoftwareByIdRequest GetSoftwareByIdRequestAviability() => new GetSoftwareByIdRequest()
        {
            Id = GuidAvailable
        };

        public static GetSoftwareByIdRequest GetSoftwareByIdRequestNewGuid() => new GetSoftwareByIdRequest()
        {
            Id = GetSoftwareNewGuid()
        };

        public static GetSoftwareByIdRequest GetSoftwareByIdRequestDefault() => new GetSoftwareByIdRequest()
        {
            Id = GuidDefault
        };

        #endregion

        #region "Delete"

        public static DeleteSoftwareByIdRequest DeleteSoftwareRequestAviability() => new DeleteSoftwareByIdRequest()
        {
            Id = GuidAvailable
        };

        public static DeleteSoftwareByIdRequest DeleteSoftwareRequestNewGuid() => new DeleteSoftwareByIdRequest()
        {
            Id = GetSoftwareNewGuid()
        };

        public static DeleteSoftwareByIdRequest DeleteSoftwareRequestDefault() => new DeleteSoftwareByIdRequest()
        {
            Id = GuidDefault
        };

        #endregion
    }
}
