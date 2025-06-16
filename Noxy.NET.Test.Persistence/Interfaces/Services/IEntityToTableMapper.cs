using Noxy.NET.Test.Domain.Entities.Authentication;
using Noxy.NET.Test.Domain.Entities.Schemas;
using Noxy.NET.Test.Domain.Entities.Schemas.Discriminators;
using Noxy.NET.Test.Domain.Entities.Schemas.Junctions;
using Noxy.NET.Test.Persistence.Tables.Authentication;
using Noxy.NET.Test.Persistence.Tables.Schemas;
using Noxy.NET.Test.Persistence.Tables.Schemas.Discriminators;
using Noxy.NET.Test.Persistence.Tables.Schemas.Junctions;

namespace Noxy.NET.Test.Persistence.Interfaces.Services;

public interface IEntityToTableMapper
{
    #region -- Authentication --

    TableAuthentication Map(EntityAuthentication entity);
    TableIdentity Map(EntityIdentity entity);
    TableUser Map(EntityUser entity);

    #endregion -- Authentication --
    
    #region -- Junctions --

    TableJunctionSchemaActionHasActionStep Map(EntityJunctionSchemaActionHasActionStep entity);
    TableJunctionSchemaActionHasDynamicValueCode Map(EntityJunctionSchemaActionHasDynamicValueCode entity);
    TableJunctionSchemaActionStepHasActionInput Map(EntityJunctionSchemaActionStepHasActionInput entity);
    TableJunctionSchemaContextHasAction Map(EntityJunctionSchemaContextHasAction entity);
    TableJunctionSchemaContextHasElement Map(EntityJunctionSchemaContextHasElement entity);
    TableJunctionSchemaElementHasProperty Map(EntityJunctionSchemaElementHasProperty entity);
    TableJunctionSchemaInputHasAttribute Map(EntityJunctionSchemaInputHasAttribute entity);
    
    #endregion -- Junctions --
    
    #region -- Schemas --

    TableSchemaAction Map(EntitySchemaAction entity);
    TableSchemaActionInput Map(EntitySchemaActionInput entity);
    TableSchemaActionStep Map(EntitySchemaActionStep entity);
    TableSchemaAttribute Map(EntitySchemaAttribute entity);
    TableSchemaContext Map(EntitySchemaContext entity);
    TableSchemaDynamicValue Map(EntitySchemaDynamicValue entity);
    TableSchemaDynamicValueCode Map(EntitySchemaDynamicValueCode entity);
    TableSchemaDynamicValueSystemParameter Map(EntitySchemaDynamicValueSystemParameter entity);
    TableSchemaDynamicValueTextParameter Map(EntitySchemaDynamicValueTextParameter entity);
    TableSchemaElement Map(EntitySchemaElement entity);
    TableSchemaGroupElement Map(EntitySchemaGroupElement entity);
    TableSchemaInput Map(EntitySchemaInput entity);
    TableSchemaProperty Map(EntitySchemaProperty baseEntity);
    TableSchemaPropertyBoolean Map(EntitySchemaPropertyBoolean entity);
    TableSchemaPropertyDateTime Map(EntitySchemaPropertyDateTime entity);
    TableSchemaPropertyString Map(EntitySchemaPropertyString entity);

    #endregion -- Schemas --
    
    #region -- Templates --
    
    TableSchema Map(EntitySchema entity);
    
    #endregion -- Templates --

}
