#region "Libraries"

using MPIS.Package.Base;
using System.Collections.Generic;

#endregion

namespace MPIS.Device.DomainModel
{
    public class Device : BaseDomainModel
    {
        public string MAC { get; set; }
        public string ComputerName { get; set; }
        public TypeSO TypeSO { get; set; }
        public string EmailUser { get; set; }
        public virtual User User { get; set; }
        public ICollection<Hardware> Hardwares { get; set; }
        public ICollection<OperativeSystem> OperativeSystems { get; set; }
        public ICollection<Software> Softwares { get; set; }

    }
}
