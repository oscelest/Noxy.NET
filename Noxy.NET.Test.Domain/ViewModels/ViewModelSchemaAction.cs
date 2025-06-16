using Noxy.NET.Test.Domain.Abstractions.ViewModels;

namespace Noxy.NET.Test.Domain.ViewModels;

public class ViewModelSchemaAction : BaseViewModelSchemaComponent
{
    public required ViewModelSchemaDynamicValue? TitleDynamic { get; set; }
    public ViewModelSchemaActionStep[]? ActionStepList { get; set; }
}
