using System.Text.Json.Serialization;
using Noxy.NET.Test.Domain.Abstractions.Entities;
using Noxy.NET.Test.Domain.Entities.Schemas.Discriminators;
using Noxy.NET.Test.Domain.ViewModels;

namespace Noxy.NET.Test.Domain.Entities.Data.Discriminators;

public abstract class EntityDataProperty : BaseEntityData
{
    public class Discriminator
    {
        public Guid ID { get; init; }
        public string SchemaIdentifier { get; init; } = string.Empty;

        public EntityDataPropertyBoolean? Boolean { get; init; }
        public EntityDataPropertyDateTime? DateTime { get; init; }
        public EntityDataPropertyString? String { get; init; }

        [JsonConstructor]
        public Discriminator()
        {
        }

        public Discriminator(EntityDataProperty? entity)
        {
            switch (entity)
            {
                case EntityDataPropertyBoolean propertyBoolean:
                    Boolean = propertyBoolean;
                    break;
                case EntityDataPropertyString propertyString:
                    String = propertyString;
                    break;
                case EntityDataPropertyDateTime propertyDateTime:
                    DateTime = propertyDateTime;
                    break;
                default:
                    throw new InvalidOperationException();
            }
        }

        public EntityDataProperty GetValue()
        {
            if (Boolean != null) return Boolean;
            if (DateTime != null) return DateTime;
            if (String != null) return String;
            throw new();
        }

        public ViewModelDataProperty ToViewModel(EntitySchemaProperty schemaProperty)
        {
            return new()
            {
                ID = ID,
                SchemaIdentifier = SchemaIdentifier,
                Title = schemaProperty.Title,
                Description = schemaProperty.Description,
                Order = schemaProperty.Order,
                Value = GetValue() switch
                {
                    EntityDataPropertyBoolean entityBoolean => entityBoolean.Value,
                    EntityDataPropertyDateTime entityDateTime => entityDateTime.Value,
                    EntityDataPropertyString entityString => entityString.Value,
                    _ => throw new ArgumentOutOfRangeException()
                }
            };
        }
    }
}
