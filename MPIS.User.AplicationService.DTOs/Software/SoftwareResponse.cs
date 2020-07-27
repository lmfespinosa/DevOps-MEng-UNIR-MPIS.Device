#region "Libraries"

using Newtonsoft.Json;
using System;

#endregion

namespace MPIS.Device.AplicationService.DTOs.Software
{
    public class SoftwareResponse
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("mac_device")]
        public string MACDevice { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
