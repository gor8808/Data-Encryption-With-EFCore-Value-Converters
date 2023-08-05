using Data_Encryption_With_EFCore_Value_Converters.DataAccess.Extensions;
using Data_Encryption_With_EFCore_Value_Converters.DataAccess.ValueConvertors;
using Data_Encryption_With_EFCore_Value_Converters.Models;
using Microsoft.EntityFrameworkCore;

namespace Data_Encryption_With_EFCore_Value_Converters.DataAccess
{
    public class AppDbContext : DbContext
    {
        public DbSet<Entity> Entities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=EntitiesDataDB;Username=postgres;Password=fs86jj0b");

            optionsBuilder.LogTo(Console.WriteLine);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Second approach ->
            modelBuilder.UseEncryption();

            var entityBuilder = modelBuilder.Entity<Entity>();

            entityBuilder.HasKey(e => e.Id);

            //First approach ->
            //entityBuilder.Property(x => x.SensitiveInformation)
            //    .HasConversion<EncryptionConvertor>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
