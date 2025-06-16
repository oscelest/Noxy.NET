using System.ComponentModel;
using Noxy.NET.Test.Domain.Constants;

namespace Noxy.NET.Test.Domain.Abstractions.Entities;

public class BaseEntitySchemaComponent : BaseEntitySchema
{
    [DisplayName(TextConstants.FormEntitySchemaLabelTitle)]
    public required string Title { get; set; }
    
    [DisplayName(TextConstants.FormEntitySchemaLabelDescription)]
    public required string Description { get; set; }
}
