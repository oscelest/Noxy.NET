using Noxy.NET.Abstractions;
using Noxy.NET.Test.Domain.Enums;
using Noxy.NET.Test.Domain.Models;

namespace Noxy.NET.Test.Presentation.Models;

public class ContextActionFieldAttribute(StateActionFieldAttribute state) : UniversalValue
{
    public bool IsList { get; private set; } = state.IsList;
    public int Order { get; private set; } = state.Order;
    public AttributeTypeEnum Type { get; private set; } = state.Type;
    public override object? Value { get; set; } = state.Value.GetValue();

    public ContextActionFieldAttribute Apply(StateActionFieldAttribute state)
    {
        IsList = state.IsList;
        Order = state.Order;
        Type = state.Type;
        Value = state.Value.GetValue();

        return this;
    }
}
