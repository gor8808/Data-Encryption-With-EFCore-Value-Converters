using Data_Encryption_With_EFCore_Value_Converters.Attributes;
using Data_Encryption_With_EFCore_Value_Converters.DataAccess.ValueConvertors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Data_Encryption_With_EFCore_Value_Converters.DataAccess.Extensions
{
    public static class ModelPropertyEncrypterExtension
    {
        public static void UseEncryption(this ModelBuilder modelBuilder)
        {
            var converter = new EncryptionConvertor();
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    if (property.ClrType == typeof(string) && !IsDiscriminator(property))
                    {
                        var attributes = property.PropertyInfo?.GetCustomAttributes(typeof(EncryptPropertyAttribute), false);
                        if (attributes != null && attributes.Any())
                        {
                            property.SetValueConverter(converter);
                        }
                    }
                }
            }
        }

        //Ignore EF core Discriminator
        private static bool IsDiscriminator(IMutableProperty property)
        {
            return property.Name == "Discriminator" || property.PropertyInfo == null;
        }
    }
}