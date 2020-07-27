using System;
using System.Collections.Generic;
using System.Text;

namespace MPIS.Device.Function.Integration.Tests.Models
{
    public class EventGridModel
    {
        public Guid id { get; set; }
        public string subject { get; set; }
        public object data { get; set; }
        public string eventType { get; set; }
        public string eventTime { get; set; }
        public string dataVersion { get; set; }
        public string metadataVersion { get; set; }
        public string topic { get; set; }
    }
}
