#region "Libraries"

using MPIS.Package.EventPublisher.AzureEventGrid.Abstraction.Entities;
using System;

#endregion

namespace MPIS.Device.EventGrid.Events.Device
{
    public class DeviceDeleted : EventBase
    {
        public DeviceDeleted(Guid guid, DateTimeOffset dateTimeOffset, long timeElapsedMilliseconds) : base(guid, dateTimeOffset, timeElapsedMilliseconds)
        {
        }

        public DeviceDeleted() : this(Guid.NewGuid(), DateTimeOffset.UtcNow, 0)
        {
        }

        public Guid Id { get; set; }
    }
}
