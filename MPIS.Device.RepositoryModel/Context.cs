#region "Libraries"

using Microsoft.EntityFrameworkCore;
using MPIS.Device.RepositoryModel.Config;

#endregion

namespace MPIS.Device.RepositoryModel
{
    public class Context : DbContext
    {
        private const string SchemaCore = "Core";
        private const string SchemaExternal = "Extermal";

        //public DbSet<Notification> Notifications { get; set; }
        public DbSet<DomainModel.User> Users { get; set; }
        public DbSet<DomainModel.Device> Devices { get; set; }
        public DbSet<DomainModel.Hardware> Hardwares { get; set; }
        public DbSet<DomainModel.OperativeSystem> OperativeSystems { get; set; }
        public DbSet<DomainModel.Software> Softwares { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // --------------------------------------------------------------------------------------------
            // Core
            // --------------------------------------------------------------------------------------------
            new DeviceConfiguration(modelBuilder.Entity<DomainModel.Device>(), Context.SchemaCore);
            new HardwareConfiguration(modelBuilder.Entity<DomainModel.Hardware>(), Context.SchemaCore);
            new SoftwareConfiguration(modelBuilder.Entity<DomainModel.Software>(), Context.SchemaCore);
            new OperativeSystemConfiguration(modelBuilder.Entity<DomainModel.OperativeSystem>(), Context.SchemaCore);


            // --------------------------------------------------------------------------------------------
            // External
            // --------------------------------------------------------------------------------------------
            new UserConfiguration(modelBuilder.Entity<DomainModel.User>(), Context.SchemaExternal);

            // --------------------------------------------------------------------------------------------
            // Data default
            // --------------------------------------------------------------------------------------------

        }
    }
}
