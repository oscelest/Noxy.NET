using Noxy.NET.Test.Domain.Entities.Authentication;
using Noxy.NET.Test.Domain.Entities.Data;
using Noxy.NET.Test.Domain.Entities.Data.Discriminators;
using Noxy.NET.Test.Domain.Entities.Schemas;
using Noxy.NET.Test.Domain.Entities.Schemas.Associations;
using Noxy.NET.Test.Domain.Entities.Schemas.Discriminators;
using Noxy.NET.Test.Domain.Entities.Schemas.Junctions;
using Noxy.NET.Test.Persistence.Tables.Authentication;
using Noxy.NET.Test.Persistence.Tables.Data;
using Noxy.NET.Test.Persistence.Tables.Data.Discriminators;
using Noxy.NET.Test.Persistence.Tables.Schemas;
using Noxy.NET.Test.Persistence.Tables.Schemas.Associations;
using Noxy.NET.Test.Persistence.Tables.Schemas.Discriminators;
using Noxy.NET.Test.Persistence.Tables.Schemas.Junctions;

namespace Noxy.NET.Test.Persistence.Interfaces.Services;

public interface ITableToEntityMapper
{
    #region -- Authentication --

    EntityIdentity Map(TableIdentity table);
    EntityAuthentication Map(TableAuthentication table);
    EntityUser Map(TableUser table);

    #endregion -- Authentication --

    #region -- Data --

    EntityDataElement Map(TableDataElement? table);
    EntityDataProperty Map(TableDataProperty? table);
    EntityDataPropertyBoolean Map(TableDataPropertyBoolean? table);
    EntityDataPropertyDateTime Map(TableDataPropertyDateTime? table);
    EntityDataPropertyString Map(TableDataPropertyString? table);
    EntityDataSystemParameter Map(TableDataSystemParameter? table);
    EntityDataTextParameter Map(TableDataTextParameter? table);

    #endregion -- Data --

    #region -- Many-To-Many --

    EntityAssociationSchemaActionInputHasAttribute.Discriminator Map(TableAssociationSchemaActionInputHasAttribute? table);
    EntityAssociationSchemaActionInputHasAttributeDynamicValue Map(TableAssociationSchemaActionInputHasAttributeDynamicValue? table);
    EntityAssociationSchemaActionInputHasAttributeInteger Map(TableAssociationSchemaActionInputHasAttributeInteger? table);
    EntityAssociationSchemaActionInputHasAttributeString Map(TableAssociationSchemaActionInputHasAttributeString? table);
    
    EntityJunctionSchemaActionHasDynamicValueCode Map(TableJunctionSchemaActionHasDynamicValueCode? table);
    EntityJunctionSchemaActionStepHasActionInput Map(TableJunctionSchemaActionStepHasActionInput? table);
    EntityJunctionSchemaActionHasActionStep Map(TableJunctionSchemaActionHasActionStep? table);
    EntityJunctionSchemaContextHasAction Map(TableJunctionSchemaContextHasAction? table);
    EntityJunctionSchemaContextHasElement Map(TableJunctionSchemaContextHasElement? table);
    EntityJunctionSchemaElementHasProperty Map(TableJunctionSchemaElementHasProperty? table);
    EntityJunctionSchemaInputHasAttribute Map(TableJunctionSchemaInputHasAttribute? table);

    #endregion -- Many-To-Many --

    #region -- Schemas --

    EntitySchemaAction Map(TableSchemaAction? table);
    EntitySchemaActionInput Map(TableSchemaActionInput? table);
    EntitySchemaActionStep Map(TableSchemaActionStep? table);
    EntitySchemaAttribute Map(TableSchemaAttribute? table);
    EntitySchemaContext Map(TableSchemaContext? table);
    EntitySchemaDynamicValue.Discriminator Map(TableSchemaDynamicValue? table);
    EntitySchemaDynamicValueCode Map(TableSchemaDynamicValueCode? table);
    EntitySchemaDynamicValueTextParameter Map(TableSchemaDynamicValueTextParameter? table);
     EntitySchemaDynamicValueSystemParameter Map(TableSchemaDynamicValueSystemParameter? table);
    EntitySchemaElement Map(TableSchemaElement? table);
    EntitySchemaGroupElement Map(TableSchemaGroupElement? table);
    EntitySchemaInput Map(TableSchemaInput? table);
    EntitySchemaProperty.Discriminator Map(TableSchemaProperty? table);
    EntitySchemaPropertyBoolean Map(TableSchemaPropertyBoolean? table);
    EntitySchemaPropertyDateTime Map(TableSchemaPropertyDateTime? table);
    EntitySchemaPropertyString Map(TableSchemaPropertyString? table);

    #endregion -- Schemas --

    #region -- Templates --

    EntitySchema Map(TableSchema? table);

    #endregion -- Templates --
}
