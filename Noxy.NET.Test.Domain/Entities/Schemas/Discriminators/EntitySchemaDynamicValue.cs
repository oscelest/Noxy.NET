using System.Text.Json.Serialization;
using Noxy.NET.Test.Domain.Abstractions.Entities;
using Noxy.NET.Test.Domain.ViewModels;

namespace Noxy.NET.Test.Domain.Entities.Schemas.Discriminators;

public class EntitySchemaDynamicValue : BaseEntitySchema
{
    public class Discriminator : BaseEntity
    {
        public Guid SchemaID { get; init; }
        public string SchemaIdentifier { get; init; } = string.Empty;

        public EntitySchemaDynamicValueCode? Code { get; init; }
        public EntitySchemaDynamicValueSystemParameter? SystemParameter { get; init; }
        public EntitySchemaDynamicValueTextParameter? TextParameter { get; init; }

        [JsonConstructor]
        public Discriminator()
        {
        }

        public Discriminator(EntitySchemaDynamicValue? entity)
        {
            switch (entity)
            {
                case EntitySchemaDynamicValueCode code:
                    Code = code;
                    break;
                case EntitySchemaDynamicValueSystemParameter system:
                    SystemParameter = system;
                    break;
                case EntitySchemaDynamicValueTextParameter text:
                    TextParameter = text;
                    break;
                default:
                    throw new InvalidOperationException();
            }

            ID = entity.ID;
            SchemaID = entity.ID;
            SchemaIdentifier = entity.SchemaIdentifier;
        }

        public EntitySchemaDynamicValue GetValue()
        {
            if (Code != null) return Code;
            if (SystemParameter != null) return SystemParameter;
            if (TextParameter != null) return TextParameter;
            throw new();
        }

        public ViewModelSchemaDynamicValue ToViewModel()
        {
            return new()
            {
                ID = ID,
                SchemaIdentifier = SchemaIdentifier,
            };
        }
    }
}
