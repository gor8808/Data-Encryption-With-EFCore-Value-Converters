using Data_Encryption_With_EFCore_Value_Converters.DataAccess;
using Data_Encryption_With_EFCore_Value_Converters.Helpers;
using Data_Encryption_With_EFCore_Value_Converters.Models;

namespace Data_Encryption_With_EFCore_Value_Converters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Set up
            EncryptionExtension.SetEncryptionKey("M!kSyJWnoj4j7V*8");

            var entity = new Entity("Hello World");

            var context = new AppDbContext();

            context.Entities.Add(entity);
        }
    }
}