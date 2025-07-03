using Noxy.NET.Test.Domain.Abstractions.ViewModels;

namespace Noxy.NET.Test.Domain.ViewModels;

public class ViewModelSchemaActionInput : BaseViewModelSchemaComponent
{
    public ViewModelSchemaInput? Input { get; set; } 
    
    public ViewModelSchemaActionInputHasAttribute[]? ActionInputAttributeList { get; set; }
}