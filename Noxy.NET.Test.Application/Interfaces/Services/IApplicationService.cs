using Noxy.NET.Test.Domain.Entities.Schemas;
using Noxy.NET.Test.Domain.Entities.Schemas.Discriminators;

namespace Noxy.NET.Test.Application.Interfaces.Services;

public interface IApplicationService
{
    void SetSchema(EntitySchema schema);
    
    EntitySchema GetSchema();
    
    EntitySchemaAction GetSchemaAction(string identifier);
    EntitySchemaActionInput GetSchemaActionInput(string identifier);
    
    List<EntitySchemaContext> GetSchemaContext();
    EntitySchemaContext GetSchemaContext(string identifier);
    
    EntitySchemaElement GetSchemaElement(string identifier);
    
    EntitySchemaProperty.Discriminator GetSchemaProperty(string identifier);
}
