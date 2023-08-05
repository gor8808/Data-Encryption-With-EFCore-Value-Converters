using Data_Encryption_With_EFCore_Value_Converters.DataAccess;
using Data_Encryption_With_EFCore_Value_Converters.Helpers;
using Data_Encryption_With_EFCore_Value_Converters.Models;
using Microsoft.EntityFrameworkCore;

namespace Data_Encryption_With_EFCore_Value_Converters
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            //Set up
            EncryptionExtension.SetEncryptionKey("M!kSyJWnoj4j7V*8");

            using var context = new AppDbContext();

            //Migrate DB to latest version
            await context.Database.MigrateAsync();

            //Create test data
            for (int i = 0; i < 50; i++)
            {
                var entity = new Entity(sensitiveInformation: $"Sensitive data No {i}");

                context.Entities.Add(entity);
            }

            //save entities
            await context.SaveChangesAsync();


            //Get created data
            var entitiesFromDb = await context.Entities.ToListAsync();

            foreach (var entity in entitiesFromDb)
            {
                Console.WriteLine(entity.SensitiveInformation);
            }
        }
    }
}