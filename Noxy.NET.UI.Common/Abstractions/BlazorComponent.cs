using Microsoft.AspNetCore.Components;

namespace Noxy.NET.UI.Abstractions;

public abstract class BlazorComponent : ComponentBase
{
    protected bool IsRendered { get; private set; }
    protected bool IsLoading { get; private set; }
    
    protected virtual string CssClass => GetComponentName();
    
    protected override void OnAfterRender(bool firstRender)
    {
        base.OnAfterRender(firstRender);
        if (!firstRender) return;
        IsRendered = true;
    }
    
    protected string GetComponentName()
    {
        return GetType().Name.Split('`').First();
    }

    protected async Task WithLoader(Func<Task> callback)
    {
        try
        {
            IsLoading = true;
            StateHasChanged();
            await callback();
        }
        catch (Exception)
        {
            // Do stuff
        }
        finally
        {
            IsLoading = false;
            StateHasChanged();
        }
    }

    protected static string CombineCssClass(params string?[] @params)
    {
        return string.Join(' ', @params.Where(x => !string.IsNullOrWhiteSpace(x)).OfType<string>().Select(@class => @class.Trim()));
    }
}
