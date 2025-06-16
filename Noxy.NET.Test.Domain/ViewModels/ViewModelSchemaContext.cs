using Noxy.NET.Test.Domain.Abstractions.ViewModels;

namespace Noxy.NET.Test.Domain.ViewModels;

public class ViewModelSchemaContext : BaseViewModelSchemaComponent
{

    public List<ViewModelSchemaAction>? ActionList { get; set; }

}
