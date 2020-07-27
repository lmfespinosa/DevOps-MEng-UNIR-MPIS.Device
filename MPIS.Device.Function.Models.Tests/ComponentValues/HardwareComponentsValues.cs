#region "Libraries"

using MPIS.Device.AplicationService.DTOs.Hardware;
using System;

#endregion

namespace MPIS.Device.Function.Models.Tests.ComponentValues
{
    public class HardwareComponentsValues
    {
        public static Guid GuidAvailable { get; set; }
        static Guid GuidDefault { get; set; }
        public static Guid GetHardwareGuidAvailable() => GuidAvailable;
        public static Guid GetHardwareDefault() => default;
        public static Guid GetHardwareNewGuid() => Guid.NewGuid();
        public static Guid GetHardwareAviability() => HardwareComponentsValues.GuidAvailable;

        #region "Create"

        public static CreateHardwareRequest CreateHardwareRequestBasic() => new CreateHardwareRequest()
        {
            MACDevice = "0000000",
            Path = "Pathhardware1",
            Device = "Gráfica 1",
            TypeHardware = TypeHardwareDTO.Multimedia,
            Description = "Descripción gráfica 1"

        };

        #endregion

        #region "Update"

        public static UpdateHardwareRequest UpdateHardwareRequestBasic() => new UpdateHardwareRequest()
        {
            Id = GuidAvailable,
            MACDevice = "0000000",
            Path = "Pathhardware1",
            Device = "Gráfica 1",
            TypeHardware = TypeHardwareDTO.Multimedia,
            Description = "Descripción gráfica 1"

        };

        #endregion

        #region "Get"

        public static GetHardwareByIdRequest GetHardwareByIdRequestAviability() => new GetHardwareByIdRequest()
        {
            Id = GuidAvailable
        };

        public static GetHardwareByIdRequest GetHardwareByIdRequestNewGuid() => new GetHardwareByIdRequest()
        {
            Id = GetHardwareNewGuid()
        };

        public static GetHardwareByIdRequest GetHardwareByIdRequestDefault() => new GetHardwareByIdRequest()
        {
            Id = GuidDefault
        };

        #endregion

        #region "Delete"

        public static DeleteHardwareByIdRequest DeleteHardwareRequestAviability() => new DeleteHardwareByIdRequest()
        {
            Id = GuidAvailable
        };

        public static DeleteHardwareByIdRequest DeleteHardwareRequestNewGuid() => new DeleteHardwareByIdRequest()
        {
            Id = GetHardwareNewGuid()
        };

        public static DeleteHardwareByIdRequest DeleteHardwareRequestDefault() => new DeleteHardwareByIdRequest()
        {
            Id = GuidDefault
        };

        #endregion
    }
}
