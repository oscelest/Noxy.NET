using Noxy.NET.Models;
using Noxy.NET.Test.Domain.Abstractions.ViewModels;

namespace Noxy.NET.Test.Domain.ViewModels;

public class ViewModelDataProperty : BaseViewModelSchemaComponent
{
    public JsonDiscriminator? Value { get; set; }
}
