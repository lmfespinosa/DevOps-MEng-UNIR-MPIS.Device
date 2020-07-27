#region "Libraries"

using MPIS.Package.Base;

#endregion

namespace MPIS.Device.DomainModel
{
    public class Hardware : BaseDomainModel
    {
        
        public string Path { get; set; }
        public string Device { get; set; }
        public TypeHardware TypeHardware { get; set; }
        public string Description { get; set; }

        public string MACDevice { get; set; }
        public virtual Device DeviceUnit { get; set; }
    }
}
