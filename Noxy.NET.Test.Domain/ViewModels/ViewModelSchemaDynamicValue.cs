using Noxy.NET.Models;
using Noxy.NET.Test.Domain.Abstractions.ViewModels;

namespace Noxy.NET.Test.Domain.ViewModels;

public class ViewModelSchemaDynamicValue : BaseViewModelSchema
{
    public required JsonDiscriminator? Value { get; set; }
}
