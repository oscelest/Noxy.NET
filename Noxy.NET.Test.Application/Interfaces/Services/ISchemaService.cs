using Noxy.NET.Test.Domain.Entities.Schemas;
using Noxy.NET.Test.Domain.Entities.Schemas.Discriminators;
using Noxy.NET.Test.Domain.Forms.Schemas.Forms;

namespace Noxy.NET.Test.Application.Interfaces.Services;

public interface ISchemaService
{
    Task<EntitySchemaAction> CreateOrUpdate(FormModelSchemaAction model);
    Task<EntitySchemaActionInput> CreateOrUpdate(FormModelSchemaActionInput model);
    Task<EntitySchemaActionStep> CreateOrUpdate(FormModelSchemaActionStep model);
    Task<EntitySchemaAttribute> CreateOrUpdate(FormModelSchemaAttribute model);
    Task<EntitySchemaContext> CreateOrUpdate(FormModelSchemaContext model);
    Task<EntitySchemaDynamicValue.Discriminator> CreateOrUpdate(FormModelSchemaDynamicValueCode model);
    Task<EntitySchemaDynamicValue.Discriminator> CreateOrUpdate(FormModelSchemaDynamicValueSystemParameter model);
    Task<EntitySchemaDynamicValue.Discriminator> CreateOrUpdate(FormModelSchemaDynamicValueTextParameter model);
    Task<EntitySchemaElement> CreateOrUpdate(FormModelSchemaElement model);
    Task<EntitySchemaInput> CreateOrUpdate(FormModelSchemaInput model);
    Task<EntitySchemaProperty.Discriminator> CreateOrUpdate(FormModelSchemaPropertyBoolean model);
    Task<EntitySchemaProperty.Discriminator> CreateOrUpdate(FormModelSchemaPropertyDateTime model);
    Task<EntitySchemaProperty.Discriminator> CreateOrUpdate(FormModelSchemaPropertyString model);
}
