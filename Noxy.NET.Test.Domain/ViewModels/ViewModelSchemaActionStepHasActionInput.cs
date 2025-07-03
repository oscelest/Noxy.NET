using Noxy.NET.Test.Domain.Abstractions.ViewModels;

namespace Noxy.NET.Test.Domain.ViewModels;

public class ViewModelSchemaActionStepHasActionInput : BaseViewModel
{
    public required int Order { get; set; }
    public required ViewModelSchemaActionInput? ActionInput { get; set; }
}
