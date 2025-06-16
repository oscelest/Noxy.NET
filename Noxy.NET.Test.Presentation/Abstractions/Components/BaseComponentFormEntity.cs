using Microsoft.AspNetCore.Components;
using Noxy.NET.Test.Domain.Abstractions.Entities;
using Noxy.NET.Test.Domain.Abstractions.Forms;
using Noxy.NET.Test.Domain.Constants;
using Noxy.NET.Test.Presentation.Services;

namespace Noxy.NET.Test.Presentation.Abstractions.Components;

public abstract class BaseComponentFormEntity<TForm, TEntity> : BaseComponentForm<TForm> where TForm : BaseFormModelEntity where TEntity : BaseEntity
{
    [Inject]
    public TextService TextService { get; set; } = null!;

    [Parameter]
    public TEntity? Value { get; set; }

    [Parameter]
    public EventCallback<TEntity> OnChange { get; set; }

    protected string SubmitText => TextService.Get(Context.Model.ID != Guid.Empty ? TextConstants.ButtonUpdate : TextConstants.ButtonCreate);

    protected async void FormSubmit(BaseFormModelEntity model)
    {
        try
        {
            if (!Context.Validate()) return;
            TEntity result = await HandleSubmission(model);
            await OnChange.InvokeAsync(result);
        }
        catch (Exception e)
        {
            Context.HandleException(e);
        }
    }

    protected virtual async Task<TEntity> HandleSubmission(BaseFormModelEntity model)
    {
        return model.ID == Guid.Empty
            ? await SchemaAPIService.PostForm<TEntity>(model)
            : await SchemaAPIService.PutForm<TEntity>(model);
    }
}
