#region "Libraries"

using Newtonsoft.Json;
using System;

#endregion

namespace MPIS.Device.AplicationService.DTOs.OperativeSystem
{
    public class OperativeSystemResponse
    {

        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("mac_device")]
        public string MACDevice { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
