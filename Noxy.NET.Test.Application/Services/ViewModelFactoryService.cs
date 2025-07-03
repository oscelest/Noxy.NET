using Noxy.NET.Test.Application.Interfaces.Services;
using Noxy.NET.Test.Domain.Entities.Data;
using Noxy.NET.Test.Domain.Entities.Data.Discriminators;
using Noxy.NET.Test.Domain.Entities.Schemas;
using Noxy.NET.Test.Domain.Entities.Schemas.Discriminators;
using Noxy.NET.Test.Domain.ViewModels;

namespace Noxy.NET.Test.Application.Services;

public class ViewModelFactoryService(IDynamicValueService serviceDynamicValue, IApplicationService serviceApplication) : IViewModelFactoryService
{
    public ViewModelSchemaDynamicValue Create(EntitySchemaDynamicValue.Discriminator? entity)
    {
        return Create(entity?.GetValue());
    }

    public ViewModelSchemaDynamicValue Create(EntitySchemaDynamicValue? entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        return new()
        {
            ID = entity.ID,
            SchemaIdentifier = entity.SchemaIdentifier,
            Value = new(serviceDynamicValue.Resolve(entity))
        };
    }

    public ViewModelSchemaAction Create(EntitySchemaAction? entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        return new()
        {
            ID = entity.ID,
            SchemaIdentifier = entity.SchemaIdentifier,
            Order = entity.Order,
            TitleDynamic = entity.TitleDynamic != null ? Create(entity.TitleDynamic) : null,
            DescriptionDynamic = entity.DescriptionDynamic != null ? Create(entity.DescriptionDynamic) : null,
            ActionStepList = entity.ActionStepList?.Select(x => Create(x.Relation)).ToArray() ?? [],
        };
    }

    public ViewModelSchemaActionInput Create(EntitySchemaActionInput? entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        return new()
        {
            ID = entity.ID,
            SchemaIdentifier = entity.SchemaIdentifier,
            Order = entity.Order,
            TitleDynamic = entity.TitleDynamic != null ? Create(entity.TitleDynamic) : null,
            DescriptionDynamic = entity.DescriptionDynamic != null ? Create(entity.DescriptionDynamic) : null,
            ActionInputAttributeList = entity.AttributeList?.Select(x => Create(x.GetValue())).ToArray() ?? [],
        };
    }

    public ViewModelSchemaActionInputHasAttribute Create(EntityAssociationSchemaActionInputHasAttribute? entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        
        return new()
        {
            ID = entity.ID,
        };
    }

    public ViewModelSchemaActionStep Create(EntitySchemaActionStep? entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        
        return new()
        {
            ID = entity.ID,
            SchemaIdentifier = entity.SchemaIdentifier,
            Order = entity.Order,
            TitleDynamic = entity.TitleDynamic != null ? Create(entity.TitleDynamic) : null,
            DescriptionDynamic = entity.DescriptionDynamic != null ? Create(entity.DescriptionDynamic) : null,
        };
    }

    public ViewModelSchemaContext Create(EntitySchemaContext? entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        
        return new()
        {
            ID = entity.ID,
            SchemaIdentifier = entity.SchemaIdentifier,
            Order = entity.Order,
            TitleDynamic = entity.TitleDynamic != null ? Create(entity.TitleDynamic) : null,
            DescriptionDynamic = entity.DescriptionDynamic != null ? Create(entity.DescriptionDynamic) : null,
        };
    }

    public ViewModelSchemaInput Create(EntitySchemaInput? entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        
        return new()
        {
            ID = entity.ID,
            SchemaIdentifier = entity.SchemaIdentifier,
        };
    }

    public ViewModelDataElement Create(EntityDataElement? entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        EntitySchemaProperty schema = serviceApplication.GetSchemaProperty(entity.SchemaIdentifier).GetValue();

        return new()
        {
            ID = entity.ID,
            SchemaIdentifier = entity.SchemaIdentifier,
            Order = schema.Order,
            TitleDynamic = schema.TitleDynamic != null ? Create(schema.TitleDynamic) : null,
            DescriptionDynamic = schema.DescriptionDynamic != null ? Create(schema.DescriptionDynamic) : null,
            PropertyList = entity.PropertyList?.Select(x => Create(x)).ToList() ?? [],
        };
    }

    public ViewModelDataProperty Create(EntityDataProperty.Discriminator? entity)
    {
        return Create(entity?.GetValue());
    }

    public ViewModelDataProperty Create(EntityDataProperty? entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        EntitySchemaProperty schema = serviceApplication.GetSchemaProperty(entity.SchemaIdentifier).GetValue();

        return new()
        {
            ID = entity.ID,
            SchemaIdentifier = entity.SchemaIdentifier,
            Order = schema.Order,
            TitleDynamic = schema.TitleDynamic != null ? Create(schema.TitleDynamic) : null,
            DescriptionDynamic = schema.DescriptionDynamic != null ? Create(schema.DescriptionDynamic) : null,
            Value = new(entity switch
            {
                EntityDataPropertyBoolean parsed => parsed.Value,
                EntityDataPropertyDateTime parsed => parsed.Value,
                EntityDataPropertyString parsed => parsed.Value,
                _ => throw new ArgumentOutOfRangeException(nameof(entity))
            })
        };
    }
}