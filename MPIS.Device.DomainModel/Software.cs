﻿#region "Libraries"

using MPIS.Package.Base;

#endregion

namespace MPIS.Device.DomainModel
{
    public class Software : BaseDomainModel
    {
        public string MACDevice { get; set; }
        public string Name { get; set; }
        public virtual Device Device { get; set; }
    }
}
