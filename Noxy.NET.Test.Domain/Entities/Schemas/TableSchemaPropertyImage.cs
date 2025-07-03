using Noxy.NET.Test.Domain.Entities.Schemas.Discriminators;

namespace Noxy.NET.Test.Domain.Entities.Schemas;

public class EntitySchemaPropertyImage : EntitySchemaProperty
{
    public EntitySchemaDynamicValue.Discriminator? Width { get; set; }
    public Guid? WidthID { get; set; }

    public EntitySchemaDynamicValue.Discriminator? Height { get; set; }
    public Guid? HeightID { get; set; }
    
    public required string AllowedExtensions { get; set; }
}