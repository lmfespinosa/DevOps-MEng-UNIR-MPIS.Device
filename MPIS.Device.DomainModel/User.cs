#region "Libraries"

using MPIS.Package.Base;
using System.Collections.Generic;

#endregion

namespace MPIS.Device.DomainModel
{
    public class User : BaseDomainModel
    {
        public string Email { get; set; }
        public ICollection<Device> Devices { get; set; }
    }
}
