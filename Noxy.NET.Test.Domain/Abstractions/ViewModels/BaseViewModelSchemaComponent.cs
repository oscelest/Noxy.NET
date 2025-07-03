using Noxy.NET.Test.Domain.ViewModels;

namespace Noxy.NET.Test.Domain.Abstractions.ViewModels;

public abstract class BaseViewModelSchemaComponent : BaseViewModelSchema
{
    public required ViewModelSchemaDynamicValue? TitleDynamic { get; set; }
    public required ViewModelSchemaDynamicValue? DescriptionDynamic { get; set; }
    public required int Order { get; set; }
}
