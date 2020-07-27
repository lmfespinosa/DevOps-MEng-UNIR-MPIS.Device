#region "Libraries"

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

#endregion

namespace MPIS.Device.RepositoryModel.Config
{
    public class SoftwareConfiguration
    {
        public SoftwareConfiguration(EntityTypeBuilder<DomainModel.Software> modelBuilder, string schema)
        {
            modelBuilder.ToTable("Softwares", schema);
            modelBuilder.HasIndex(x => x.MACDevice);

        }
    }
}
