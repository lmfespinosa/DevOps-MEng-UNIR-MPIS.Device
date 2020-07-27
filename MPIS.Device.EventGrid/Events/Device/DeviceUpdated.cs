#region "Libraries"

using MPIS.Package.EventPublisher.AzureEventGrid.Abstraction.Entities;
using System;

#endregion

namespace MPIS.Device.EventGrid.Events.Device
{
    public class DeviceUpdated : EventBase
    {
        public DeviceUpdated(Guid guid, DateTimeOffset dateTimeOffset, long timeElapsedMilliseconds) : base(guid, dateTimeOffset, timeElapsedMilliseconds)
        {
        }

        public DeviceUpdated() : this(Guid.NewGuid(), DateTimeOffset.UtcNow, 0)
        {
        }

        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime TimeStamp { get; set; }
        public DateTime Time { get; set; }
        public string Text { get; set; }
        public string Reason { get; set; }
    }
}
