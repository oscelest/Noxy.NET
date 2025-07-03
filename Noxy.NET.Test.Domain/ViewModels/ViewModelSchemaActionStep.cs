using Noxy.NET.Test.Domain.Abstractions.ViewModels;

namespace Noxy.NET.Test.Domain.ViewModels;

public class ViewModelSchemaActionStep : BaseViewModelSchemaComponent
{
    public ViewModelSchemaActionStepHasActionInput[]? ActionInputList { get; set; }
}
