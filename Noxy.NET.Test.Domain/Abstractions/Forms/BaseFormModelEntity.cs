using System.Text.Json.Serialization;
using Noxy.NET.Test.Domain.Abstractions.Entities;

namespace Noxy.NET.Test.Domain.Abstractions.Forms;

public abstract class BaseFormModelEntity(BaseEntity? entity) : BaseFormModel
{
    public Guid ID { get; set; } = entity?.ID ?? Guid.Empty;
}
