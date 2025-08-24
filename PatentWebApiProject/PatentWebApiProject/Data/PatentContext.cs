using Microsoft.EntityFrameworkCore;
using PatentWebApiProject.Models;

namespace PatentWebApiProject.Data
{
    public class PatentContext : DbContext
    {
        public DbSet<Members> members { get; set; } = default!;
        public DbSet<Patent> patents { get; set; } = default!;
        public DbSet<InternationalPatent> inPatents { get; set; } = default!;
        public DbSet<PatentGrants> grants { get; set; } = default!;
        public PatentContext(DbContextOptions<PatentContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Many-to-Many: Members ↔ Patents
            modelBuilder.Entity<Members>()
                .HasMany(m => m.patents)
                .WithMany(p => p.members)
                .UsingEntity(j => j.ToTable("MembersPatent"));

            // Patent → InternationalPatent (Cascade)
            modelBuilder.Entity<InternationalPatent>()
                .HasOne(ip => ip.patent)
                .WithMany() // Patent doesn’t expose collection of IPs
                .HasForeignKey(ip => ip.patentId)
                .OnDelete(DeleteBehavior.Cascade);

            // Patent → PatentGrants (Restrict to break cycle)
            modelBuilder.Entity<PatentGrants>()
                .HasOne(pg => pg.patent)
                .WithMany(p => p.patentGrants)
                .HasForeignKey(pg => pg.patentId)
                .OnDelete(DeleteBehavior.Cascade);
                  

          

            // Seed Members
            modelBuilder.Entity<Members>().HasData(
                new Members { memId = 1, name = "Janu", email = "janu@gmail.com", createdAt = new DateTime(2024, 8, 21, 10, 0, 0) },
                new Members { memId = 2, name = "Laith", email = "lali@gmail.com", createdAt = new DateTime(2024, 8, 21, 10, 5, 0) }
            );

            // Seed Patents
            modelBuilder.Entity<Patent>().HasData(
                new Patent { patentId = 101, title = "Cancer Detection Patent", description = "AI-powered biomedical cancer detection system", appliedDate = new DateTime(2024, 9, 21, 9, 0, 0) },
                new Patent { patentId = 102, title = "Vaccine Delivery Patent", description = "Novel vaccine delivery method", appliedDate = new DateTime(2024, 9, 21, 9, 30, 0) }
            );

            // Seed InternationalPatent
            modelBuilder.Entity<InternationalPatent>().HasData(
                new InternationalPatent { ipId = 501, country = "US", patentId = 101, fieledDate = new DateTime(2025, 6, 21, 11, 0, 0) }
            );

            // Seed PatentGrants
            modelBuilder.Entity<PatentGrants>().HasData(
                new PatentGrants
                {
                    grantId = 1001,
                    patentId = 101,
                 
                    domain = "Biomedical",
                    grantDate = new DateTime(2025, 4, 21, 12, 0, 0),
                    score = 7
                }
            );
        }
    }
}
