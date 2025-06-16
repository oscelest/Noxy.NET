using Noxy.NET.Test.Domain.Abstractions.ViewModels;

namespace Noxy.NET.Test.Domain.ViewModels;

public class ViewModelDataElement : BaseViewModelSchemaComponent
{
    public required IEnumerable<ViewModelDataProperty>? PropertyList { get; set; }

}
