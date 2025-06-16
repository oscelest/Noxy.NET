using Microsoft.AspNetCore.Components;

namespace Noxy.NET.UI.Abstractions;

public abstract class BaseInputTextualValue<TValue> : BaseInputValue<TValue>
{
    [Parameter]
    public int? Size { get; set; }
    protected int SizeCurrent => Size ?? 35;
}
