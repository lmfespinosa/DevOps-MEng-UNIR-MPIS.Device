#region "Libraries"

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

#endregion

namespace MPIS.Device.RepositoryModel.Config
{
    public class UserConfiguration
    {
        public UserConfiguration(EntityTypeBuilder<DomainModel.User> modelBuilder, string schema)
        {
            modelBuilder.ToTable("Users", schema);
            modelBuilder.HasIndex(x => x.Email);

            /*modelBuilder
               .HasMany(x => x.Devices)
               .WithOne(x => x.User)
               .HasForeignKey(x => x.EmailUser)
               .OnDelete(DeleteBehavior.Restrict);*/

        }
    }
}
