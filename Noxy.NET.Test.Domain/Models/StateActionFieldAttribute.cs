using Noxy.NET.Models;
using Noxy.NET.Test.Domain.Enums;

namespace Noxy.NET.Test.Domain.Models;

public class StateActionFieldAttribute
{
    public required bool IsList { get; set; }
    public required int Order { get; set; }
    public required AttributeTypeEnum Type { get; set; }
    public required JsonDiscriminator Value { get; set; }
}
