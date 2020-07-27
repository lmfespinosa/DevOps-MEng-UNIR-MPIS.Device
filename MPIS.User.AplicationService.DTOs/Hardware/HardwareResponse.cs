#region "Libraries"

using Newtonsoft.Json;
using System;

#endregion

namespace MPIS.Device.AplicationService.DTOs.Hardware
{
    public class HardwareResponse
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("path")]
        public string Path { get; set; }
        [JsonProperty("device")]
        public string Device { get; set; }
        [JsonProperty("type_hardware")]
        public TypeHardwareDTO TypeHardware { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("mac_device")]
        public string MACDevice { get; set; }
    }
}
