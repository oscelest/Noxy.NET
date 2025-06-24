using System.Text.Json.Serialization;
using Noxy.NET.Test.Domain.Abstractions.Entities;
using Noxy.NET.Test.Domain.Entities.Schemas.Junctions;

namespace Noxy.NET.Test.Domain.Entities.Schemas.Discriminators;

public class EntitySchemaProperty : BaseEntitySchemaComponent
{
    public required string DefaultValue { get; set; }

    [JsonIgnore]
    public ICollection<EntityJunctionSchemaElementHasProperty>? ElementList { get; set; }

    public class Discriminator : BaseEntity
    {
        public Guid SchemaID { get; init; }
        public string SchemaIdentifier { get; init; } = string.Empty;

        public EntitySchemaPropertyBoolean? Boolean { get; init; }
        public EntitySchemaPropertyDateTime? DateTime { get; init; }
        public EntitySchemaPropertyDecimal? Decimal { get; init; }
        public EntitySchemaPropertyInteger? Integer { get; init; }
        public EntitySchemaPropertyString? String { get; init; }

        [JsonConstructor]
        public Discriminator()
        {
        }

        public Discriminator(EntitySchemaProperty? entity)
        {
            switch (entity)
            {
                case EntitySchemaPropertyBoolean property:
                    Boolean = property;
                    break;
                case EntitySchemaPropertyDateTime property:
                    DateTime = property;
                    break;
                case EntitySchemaPropertyDecimal property:
                    Decimal = property;
                    break;
                case EntitySchemaPropertyInteger property:
                    Integer = property;
                    break;
                case EntitySchemaPropertyString property:
                    String = property;
                    break;
                default:
                    throw new InvalidOperationException();
            }

            ID = entity.ID;
            SchemaID = entity.ID;
            SchemaIdentifier = entity.SchemaIdentifier;
        }

        public EntitySchemaProperty GetValue()
        {
            if (Boolean != null) return Boolean;
            if (DateTime != null) return DateTime;
            if (Decimal != null) return Decimal;
            if (Integer != null) return Integer;
            if (String != null) return String;
            throw new();
        }
    }
}
