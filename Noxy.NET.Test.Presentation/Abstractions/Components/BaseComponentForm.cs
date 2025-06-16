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

    protected WebFormContext<TForm> Context { get; set; } = null!;

    protected abstract WebFormContext<TForm> CreateContext();
    
    protected override void OnInitialized()
    {
        base.OnInitialized();
        Context = CreateContext();
    }
}

