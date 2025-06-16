using Noxy.NET.Test.Domain.Abstractions.Entities;
using Noxy.NET.Test.Domain.Entities.Schemas.Junctions;
using Noxy.NET.Test.Domain.ViewModels;

namespace Noxy.NET.Test.Domain.Entities.Schemas;

public class EntitySchemaContext : BaseEntitySchemaComponent
{
    public List<EntityJunctionSchemaContextHasAction>? ActionList { get; set; }
    public List<EntityJunctionSchemaContextHasElement>? ElementList { get; set; }

    public ViewModelSchemaContext ToViewModel()
    {
        return new()
        {
            ID = ID,
            SchemaIdentifier = SchemaIdentifier,
            Order = Order,
            Title = Title,
            Description = Description,
        };
    }
}
