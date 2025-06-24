using Microsoft.AspNetCore.Components;
using Noxy.NET.Test.Domain.Abstractions.Forms;
using Noxy.NET.Test.Presentation.Services;
using Noxy.NET.UI.Abstractions;
using Noxy.NET.UI.Models;

namespace Noxy.NET.Test.Presentation.Abstractions.Components;

public abstract class BaseComponentForm<TForm> : ElementComponent where TForm : BaseFormModel
{
    [Inject]
    protected SchemaAPIService SchemaAPIService { get; set; } = null!;

    [Inject]
    protected TextService TextService { get; set; } = null!;

    protected WebFormContext<TForm> Context { get; set; } = null!;

    protected abstract WebFormContext<TForm> CreateContext();

    protected string? GetDisplayName(string property)
    {
        return TextService.Get(Context.GetField(property)?.GetDisplayName());
    }

    protected string? GetDescription(string property)
    {
        return TextService.Get(Context.GetField(property)?.GetDescription());
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();
        Context = CreateContext();
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);
        if (!firstRender) return;

        await WithLoader(TextService.Resolve);
    }
}
