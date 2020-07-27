

namespace MPIS.Device.AplicationService.DTOs.Hardware
{
    public class CreateHardwareRequest
    {
        public string Path { get; set; }
        public string Device { get; set; }
        public TypeHardwareDTO TypeHardware { get; set; }
        public string Description { get; set; }

        public string MACDevice { get; set; }
    }
}
