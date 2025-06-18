using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Noxy.NET.UI.Components;

namespace Noxy.NET.UI.Abstractions;

public abstract class BaseInputTextualValue<TValue> : BaseInputValue<TValue>, IDisposable
{
    [Inject]
    protected IJSRuntime JS { get; set; } = null!;
    
    [Parameter]
    public bool? HasChangeEventOnInput { get; set; }
    protected bool HasChangeEventOnInputCurrent => HasChangeEventOnInput ?? false;

    protected DotNetObjectReference<BaseInputTextualValue<TValue>>? DotNetReference { get; set; }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);
        if (!firstRender) return;

        if (HasChangeEventOnInputCurrent)
        {
            await LoadInterop(JS);
            Module?.InvokeVoidAsync("NoxyNETUIWebForm.RegisterOnInput", UUIDString, Constants.OnInputDelay, DotNetReference = DotNetObjectReference.Create(this), nameof(OnValueInput));
        }
    }

    [JSInvokable]
    public abstract void OnValueInput(string value);
    protected abstract void OnValueChange(ChangeEventArgs args);
    
    public void Dispose()
    {
        Module?.InvokeVoidAsync("NoxyNETUIWebForm.DeregisterOnInput", UUIDString);
        DotNetReference?.Dispose();
    }
}
