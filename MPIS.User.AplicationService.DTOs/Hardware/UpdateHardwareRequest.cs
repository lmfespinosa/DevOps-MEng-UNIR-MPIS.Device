using System;
using System.Collections.Generic;
using System.Text;

namespace MPIS.Device.AplicationService.DTOs.Hardware
{
    public class UpdateHardwareRequest
    {
        public Guid Id { get; set; }
        public string Path { get; set; }
        public string Device { get; set; }
        public TypeHardwareDTO TypeHardware { get; set; }
        public string Description { get; set; }
        public string MACDevice { get; set; }
    }
}
