#region "Libraries"

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

#endregion

namespace MPIS.Device.RepositoryModel.Config
{
    public class OperativeSystemConfiguration
    {
        public OperativeSystemConfiguration(EntityTypeBuilder<DomainModel.OperativeSystem> modelBuilder, string schema)
        {
            modelBuilder.ToTable("OperativeSystems", schema);
            modelBuilder.HasIndex(x => x.MACDevice);

        }
    }
}
