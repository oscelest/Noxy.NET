using Noxy.NET.Test.Domain.Abstractions.Entities;
using Noxy.NET.Test.Domain.Entities.Data.Discriminators;
using Noxy.NET.Test.Domain.Entities.Schemas;
using Noxy.NET.Test.Domain.ViewModels;

namespace Noxy.NET.Test.Domain.Entities.Data;

public class EntityDataElement : BaseEntityData
{
    public List<EntityDataProperty.Discriminator>? PropertyList { get; set; }

    public ViewModelDataElement ToViewModel(EntitySchemaElement schema, IEnumerable<ViewModelDataProperty>? listProperty = null)
    {
        return new()
        {
            ID = ID,
            SchemaIdentifier = SchemaIdentifier,
            Title = schema.Title,
            Description = schema.Description,
            Order = schema.Order,
            PropertyList = listProperty
        };
    }
}
