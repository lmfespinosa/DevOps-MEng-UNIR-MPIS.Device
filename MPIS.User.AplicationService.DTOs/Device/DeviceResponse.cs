#region "Libraries"

using Newtonsoft.Json;
using System;

#endregion

namespace MPIS.Device.AplicationService.DTOs.Device
{
    public class DeviceResponse
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("mac")]
        public string MAC { get; set; }
        [JsonProperty("computer_name")]
        public string ComputerName { get; set; }
        [JsonProperty("type_so")]
        public TypeSODTO TypeSO { get; set; }
        [JsonProperty("name_user")]
        public string NameUser { get; set; }
    }
}
