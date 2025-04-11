using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MaintenanceApi.Models;

namespace MaintenanceApi.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Technician> Technicians { get; set; }
        public DbSet<Intervention> Interventions { get; set; }
        public DbSet<InterventionTechnician> InterventionTechnicians { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<InterventionTechnician>()
                .HasKey(it => new { it.InterventionId, it.TechnicianId });

            builder.Entity<InterventionTechnician>()
                .HasOne(it => it.Intervention)
                .WithMany(i => i.InterventionTechnicians)
                .HasForeignKey(it => it.InterventionId);

            builder.Entity<InterventionTechnician>()
                .HasOne(it => it.Technician)
                .WithMany()
                .HasForeignKey(it => it.TechnicianId);

        }


    }
}
