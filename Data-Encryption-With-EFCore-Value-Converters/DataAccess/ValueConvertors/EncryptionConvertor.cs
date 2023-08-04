using Data_Encryption_With_EFCore_Value_Converters.Helpers;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data_Encryption_With_EFCore_Value_Converters.DataAccess.ValueConvertors
{
    public class EncryptionConvertor : ValueConverter<string, string>
    {
        public EncryptionConvertor(ConverterMappingHints mappingHints = null)
            : base(x => EncryptionExtension.Encrypt(x), x => EncryptionExtension.Decrypt(x), mappingHints)
        { }
    }
}
