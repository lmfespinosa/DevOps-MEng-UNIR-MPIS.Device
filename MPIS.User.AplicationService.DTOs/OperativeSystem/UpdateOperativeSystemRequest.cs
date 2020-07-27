#region "Libraries"

using System;

#endregion

namespace MPIS.Device.AplicationService.DTOs.OperativeSystem
{
    public class UpdateOperativeSystemRequest
    {
        public Guid Id { get; set; }
        public string MACDevice { get; set; }
        public string Name { get; set; }
    }
}
