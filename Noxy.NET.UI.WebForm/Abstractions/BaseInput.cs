using Microsoft.AspNetCore.Components;
using Noxy.NET.UI.Interfaces;
using System.Linq.Expressions;
using Microsoft.JSInterop;

namespace Noxy.NET.UI.Abstractions;

public abstract class BaseInput : ElementComponent
{
    [CascadingParameter]
    public IWebFormInputContext? Context { get; set; }

    [Parameter]
    public string? ID { get; set; }
    protected string IDCurrent => ID ?? UUIDCode;

    internal IJSObjectReference? Module { get; set; }

    internal async Task LoadInterop(IJSRuntime js)
    {
        Module ??= await js.InvokeAsync<IJSObjectReference>("import", $"./_content/{Constants.AssemblyNameUIWebForm}/Interop.js");
    }

    protected IWebFormFieldContext? GetField(string name)
    {
        return Context?.GetField(name);
    }

    protected IWebFormFieldContext? GetField<T>(Expression<Func<T>>? expression)
    {
        return Context?.GetField(expression);
    }
}
