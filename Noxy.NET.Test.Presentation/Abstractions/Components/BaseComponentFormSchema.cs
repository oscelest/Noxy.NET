using Microsoft.AspNetCore.Components;
using Noxy.NET.Test.Domain.Abstractions.Entities;
using Noxy.NET.Test.Domain.Abstractions.Forms;
using Noxy.NET.Test.Domain.Entities.Schemas;

namespace Noxy.NET.Test.Presentation.Abstractions.Components;

public abstract class BaseComponentFormSchema<TForm, TEntity> : BaseComponentFormTemplate<TForm, TEntity> where TForm : BaseFormModelEntitySchema where TEntity : BaseEntitySchema
{
    [Parameter, EditorRequired]
    public required EntitySchema Schema { get; set; }
}
