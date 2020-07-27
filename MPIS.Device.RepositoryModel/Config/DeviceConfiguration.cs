#region "Libraries"

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

#endregion

namespace MPIS.Device.RepositoryModel.Config
{
    public class DeviceConfiguration
    {
        public DeviceConfiguration(EntityTypeBuilder<DomainModel.Device> modelBuilder, string schema)
        {
            modelBuilder.ToTable("Devices", schema);
            modelBuilder.HasIndex(x => x.MAC);

            /*modelBuilder
               .HasMany(x => x.Hardwares)
               .WithOne(x => x.DeviceUnit)
               .HasForeignKey(x => x.MACDevice)
               .OnDelete(DeleteBehavior.Restrict);*/

           /* modelBuilder
               .HasMany(x => x.Softwares)
               .WithOne(x => x.Device)
               .HasForeignKey(x => x.MACDevice)
               .OnDelete(DeleteBehavior.Restrict);*/

           /* modelBuilder
               .HasMany(x => x.OperativeSystems)
               .WithOne(x => x.Device)
               .HasForeignKey(x => x.MACDevice)
               .OnDelete(DeleteBehavior.Restrict);*/

        }
    }
}
