using Microsoft.AspNetCore.Components;
using System.Linq.Expressions;

namespace Noxy.NET.UI.Abstractions;

public abstract class BaseInputValue<TValue> : BaseInput
{
    [Parameter, EditorRequired]
    public required TValue Value { get; set; }
    
    [Parameter]
    public EventCallback<TValue> ValueChanged { get; set; }

    [Parameter]
    public Expression<Func<TValue>>? ValueExpression { get; set; }
    
    protected void NotifyChange(TValue value)
    {
        GetField(ValueExpression)?.NotifyChange();
        ValueChanged.InvokeAsync(value);
    }
}
