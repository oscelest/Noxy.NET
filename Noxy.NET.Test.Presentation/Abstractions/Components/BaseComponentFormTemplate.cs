using Noxy.NET.Test.Domain.Abstractions.Entities;
using Noxy.NET.Test.Domain.Abstractions.Forms;

namespace Noxy.NET.Test.Presentation.Abstractions.Components;

public abstract class BaseComponentFormTemplate<TForm, TEntity> : BaseComponentFormEntity<TForm, TEntity> where TForm : BaseFormModelEntityTemplate where TEntity : BaseEntityTemplate;
