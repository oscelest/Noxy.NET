using Microsoft.AspNetCore.Components;
using Noxy.NET.Test.Domain.ViewModels;
using Noxy.NET.Test.Presentation.Models;
using Noxy.NET.Test.Presentation.Services;
using Noxy.NET.UI.Abstractions;

namespace Noxy.NET.Test.Presentation.Abstractions.Components;

public abstract class BaseComponentActionInput : ElementComponent
{
    [Inject]
    public required ActionHubService ActionHubService { get; set; }

    [Parameter, EditorRequired]
    public required string ID { get; set; }
    
    [Parameter, EditorRequired]
    public required Guid Reference { get; set; }

    [Parameter, EditorRequired]
    public required ViewModelSchemaAction Action { get; set; }

    [Parameter, EditorRequired]
    public required ViewModelSchemaActionInput ActionInput { get; set; }

    [Parameter, EditorRequired]
    public required ContextActionField Context { get; set; }

    protected async Task Commit()
    {
        await ActionHubService.CommitField(Reference, ActionInput.SchemaIdentifier);
        await InvokeAsync(StateHasChanged);
    }
    

}

