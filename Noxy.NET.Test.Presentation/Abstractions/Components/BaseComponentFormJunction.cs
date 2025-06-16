using Microsoft.AspNetCore.Components;
using Noxy.NET.Test.Domain.Abstractions.Entities;
using Noxy.NET.Test.Domain.Abstractions.Forms;

namespace Noxy.NET.Test.Presentation.Abstractions.Components;

public abstract class BaseComponentFormJunction<TForm, TEntity, TRelation, TJunction> : BaseComponentFormEntity<TForm, TEntity> where TForm : BaseFormModelEntity where TEntity : BaseEntity where TRelation : BaseEntity where TJunction : BaseEntity
{
    [Parameter, EditorRequired]
    public required TEntity Entity { get; set; }
    private TEntity PreviousEntity { get; set; } = null!;

    [Parameter, EditorRequired]
    public IEnumerable<TRelation>? Available { get; set; }
    private IEnumerable<TRelation> AvailableCurrent => Available ?? [];

    protected Dictionary<Guid, TRelation> CollectionLookup = [];
    protected IEnumerable<Guid> ListAvailable = [];

    protected abstract List<TJunction> JunctionList { get; }
    
    protected override void OnInitialized()
    {
        base.OnInitialized();

        UpdateElement();
    }

    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        if (PreviousEntity != Entity)
        {
            UpdateElement();
        }
    }

    protected virtual void UpdateElement()
    {
        PreviousEntity = Entity;
        ListAvailable = AvailableCurrent.Select(x => x.ID);
        CollectionLookup = AvailableCurrent.ToDictionary(x => x.ID, x => x);
    }

    protected override async Task<TEntity> HandleSubmission(BaseFormModelEntity model)
    {
        return await SchemaAPIService.PostForm<TEntity>(model);
    }
}
