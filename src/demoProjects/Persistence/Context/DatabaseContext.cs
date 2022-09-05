using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Persistence.Context
{
    public class DatabaseContext : DbContext
    {
        IConfiguration  Configuration { get; set; }
        public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }

        public DatabaseContext(DbContextOptions dbContextOptions, IConfiguration configuration):base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProgrammingLanguage>(
                x =>
                {
                    x.ToTable("ProgrammingLanguage").HasKey(k => k.Id);
                    x.Property(p => p.Id).HasColumnName("Id");
                    x.Property(p => p.ProgrammingLanguageName).HasColumnName("ProgrammingLanguageName");
                });

            ProgrammingLanguage[] programmingLanguageEntitySeeds = { new(1, "C#"), new(2, "Python") };
            modelBuilder.Entity<ProgrammingLanguage>().HasData(programmingLanguageEntitySeeds);
        }
    }
}
