#region "Libraries"

using System;

#endregion

namespace MPIS.Device.AplicationService.DTOs.Device
{
    public class UpdateDeviceRequest
    {
        public Guid Id { get; set; }
        public string MAC { get; set; }
        public string ComputerName { get; set; }
        public TypeSODTO TypeSO { get; set; }
        public string EmailUser { get; set; }
    }
}
