#region "Libraries"

using System;

#endregion

namespace MPIS.Device.AplicationService.DTOs.Software
{
    public class UpdateSoftwareRequest
    {
        public Guid Id { get; set; }
        public string MACDevice { get; set; }
        public string Name { get; set; }
    }
}
