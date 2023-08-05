using Data_Encryption_With_EFCore_Value_Converters.Attributes;

namespace Data_Encryption_With_EFCore_Value_Converters.Models
{
    public class Entity
    {
        public Guid Id { get; private set; }

        [EncryptProperty]
        public string SensitiveInformation { get; private set; }

        public Entity(string sensitiveInformation)
        {
            Id = Guid.NewGuid();

            SensitiveInformation = sensitiveInformation;
        }
    }
}