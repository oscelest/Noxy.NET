using Noxy.NET.Test.Domain.Abstractions.ViewModels;

namespace Noxy.NET.Test.Domain.ViewModels;

public class ViewModelSchemaActionHasActionStep : BaseViewModel
{
    public required int Order { get; set; }
    public required ViewModelSchemaActionStep? ActionStep { get; set; }
}
