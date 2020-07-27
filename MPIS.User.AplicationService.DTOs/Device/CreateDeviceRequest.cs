using System;
using System.Collections.Generic;
using System.Text;

namespace MPIS.Device.AplicationService.DTOs.Device
{
    public class CreateDeviceRequest
    {
        public string MAC { get; set; }
        public string ComputerName { get; set; }
        public TypeSODTO TypeSO { get; set; }
        public string EmailUser { get; set; }
    }
}
