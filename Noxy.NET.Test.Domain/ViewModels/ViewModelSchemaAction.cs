using Noxy.NET.Test.Domain.Abstractions.ViewModels;

namespace Noxy.NET.Test.Domain.ViewModels;

public class ViewModelSchemaAction : BaseViewModelSchemaComponent
{
    public ViewModelSchemaActionHasActionStep[]? ActionStepList { get; set; }
}
