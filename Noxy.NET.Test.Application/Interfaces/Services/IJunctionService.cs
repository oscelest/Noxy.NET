using Noxy.NET.Test.Domain.Entities.Schemas;
using Noxy.NET.Test.Domain.Forms.Schemas.JunctionForms;

namespace Noxy.NET.Test.Application.Interfaces.Services;

public interface IJunctionService
{
    Task<EntitySchemaAction> Relate(FormModelJunctionSchemaActionHasActionStep model);
    Task<EntitySchemaAction> Relate(FormModelJunctionSchemaActionHasDynamicValueCode model);
    Task<EntitySchemaActionStep> Relate(FormModelJunctionSchemaActionStepHasActionInput model);
    Task<EntitySchemaContext> Relate(FormModelJunctionSchemaContextHasAction model);
    Task<EntitySchemaContext> Relate(FormModelJunctionSchemaContextHasElement model);
    Task<EntitySchemaElement> Relate(FormModelJunctionSchemaElementHasProperty model);
}
