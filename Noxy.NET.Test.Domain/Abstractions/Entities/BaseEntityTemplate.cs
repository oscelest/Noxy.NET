using System.ComponentModel;
using Noxy.NET.Test.Domain.Constants;

namespace Noxy.NET.Test.Domain.Abstractions.Entities;

public abstract class BaseEntityTemplate : BaseEntity
{
    [DisplayName(TextConstants.FormEntitySchemaLabelName)]
    public required string Name { get; set; }
    
    [DisplayName(TextConstants.FormEntitySchemaLabelNote)]
    public required string Note { get; set; }
    
    public required int Order { get; set; }
}
