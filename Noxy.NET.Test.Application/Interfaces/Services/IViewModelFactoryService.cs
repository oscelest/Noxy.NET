using Noxy.NET.Test.Domain.Entities.Data;
using Noxy.NET.Test.Domain.Entities.Data.Discriminators;
using Noxy.NET.Test.Domain.Entities.Schemas;
using Noxy.NET.Test.Domain.Entities.Schemas.Discriminators;
using Noxy.NET.Test.Domain.ViewModels;

namespace Noxy.NET.Test.Application.Interfaces.Services;

public interface IViewModelFactoryService
{
    ViewModelSchemaDynamicValue Create(EntitySchemaDynamicValue.Discriminator? entity);
    ViewModelSchemaDynamicValue Create(EntitySchemaDynamicValue? entity);
    ViewModelSchemaAction Create(EntitySchemaAction? entity);
    ViewModelSchemaActionInput Create(EntitySchemaActionInput? entity);
    ViewModelSchemaActionInputHasAttribute Create(EntityAssociationSchemaActionInputHasAttribute? entity);
    ViewModelSchemaActionStep Create(EntitySchemaActionStep? entity);
    ViewModelSchemaContext Create(EntitySchemaContext? entity);
    ViewModelSchemaInput Create(EntitySchemaInput? entity);
    ViewModelDataElement Create(EntityDataElement? entity);
    ViewModelDataProperty Create(EntityDataProperty.Discriminator? entity);
    ViewModelDataProperty Create(EntityDataProperty? entity);
}