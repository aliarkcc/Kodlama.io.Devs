using Core.Security.Entities;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Persistence.Context
{
    public class DatabaseContext : DbContext
    {
        IConfiguration  Configuration { get; set; }
        public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
        public DbSet<ProgrammingLanguageTechnology> ProgrammingLanguageTechnologies{ get; set; }
        public DbSet<User> Users{ get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims{ get; set; }
        public DbSet<OperationClaim> OperationClaims{ get; set; }
        public DbSet<GithubProfile> GithubProfiles{ get; set; }

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

            modelBuilder.Entity<ProgrammingLanguageTechnology>(
                x =>
                {
                    x.ToTable("ProgrammingLanguageTechnology").HasKey(k => k.Id);
                    x.Property(p => p.Id).HasColumnName("Id");
                    x.Property(p => p.ProgrammingLanguageId).HasColumnName("ProgrammingLanguageId");
                    x.Property(p => p.Name).HasColumnName("Name");
                });
            modelBuilder.Entity<User>(
                x =>
                {
                    x.ToTable("Users").HasKey(k => k.Id);
                    x.Property(p => p.Id).HasColumnName("Id");
                    x.Property(p => p.FirstName).HasColumnName("FirstName");
                    x.Property(p => p.LastName).HasColumnName("LastName");
                    x.Property(p => p.Email).HasColumnName("Email");
                    x.Property(p => p.PasswordSalt).HasColumnName("PasswordSalt");
                    x.Property(p => p.PasswordHash).HasColumnName("PasswordHash");
                    x.Property(p => p.Status).HasColumnName("Status");
                    x.Property(p => p.AuthenticatorType).HasColumnName("AuthenticatorType");
                    x.HasMany(p => p.UserOperationClaims);
                    x.HasMany(p => p.RefreshTokens);
                });
            modelBuilder.Entity<UserOperationClaim>(
                x =>
                {
                    x.ToTable("UserOperationClaims").HasKey(k => k.Id);
                    x.Property(p => p.Id).HasColumnName("Id");
                    x.Property(p => p.UserId).HasColumnName("UserId");
                    x.Property(p => p.OperationClaimId).HasColumnName("OperationClaimId");
                    x.HasOne(p => p.User);
                    x.HasOne(p => p.OperationClaim);
                });
            modelBuilder.Entity<OperationClaim>(
                x =>
                {
                    x.ToTable("OperationClaims").HasKey(k => k.Id);
                    x.Property(p => p.Id).HasColumnName("Id");
                    x.Property(p => p.Name).HasColumnName("Name");
                });

            modelBuilder.Entity<GithubProfile>(
                x =>
                {
                    x.ToTable("GithubProfiles").HasKey(k => k.Id);
                    x.Property(p => p.Id).HasColumnName("Id");
                    x.Property(p => p.ProfileUserName).HasColumnName("ProfileUserName");
                    x.HasOne(p => p.User);
                });

            ProgrammingLanguage[] programmingLanguageEntitySeeds = { new(1, "C#"), new(2, "Python") };
            modelBuilder.Entity<ProgrammingLanguage>().HasData(programmingLanguageEntitySeeds);

            ProgrammingLanguageTechnology[] programmingLanguageTechologyEntitySeeds = { new(1,"WPF",1)};
            modelBuilder.Entity<ProgrammingLanguageTechnology>().HasData(programmingLanguageTechologyEntitySeeds);
        }
    }
}
