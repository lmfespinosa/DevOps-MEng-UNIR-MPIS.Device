#region "Libraries"

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

#endregion

namespace MPIS.Device.RepositoryModel.Config
{
    public class HardwareConfiguration
    {
        public HardwareConfiguration(EntityTypeBuilder<DomainModel.Hardware> modelBuilder, string schema)
        {
            modelBuilder.ToTable("Hardwares", schema);
            modelBuilder.HasIndex(x => x.MACDevice);
            //modelBuilder.HasKey(x => x.MACDevice);

        }
    }
}
