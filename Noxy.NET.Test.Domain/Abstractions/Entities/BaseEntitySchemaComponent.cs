using System.ComponentModel;
using Noxy.NET.Test.Domain.Constants;

namespace Noxy.NET.Test.Domain.Abstractions.Entities;

public class BaseEntitySchemaComponent : BaseEntitySchema
{
    [DisplayName(TextConstants.LabelFormTitle)]
    [Description(TextConstants.HelpFormTitle)]
    public required string Title { get; set; }
    
    [DisplayName(TextConstants.LabelFormDescription)]
    [Description(TextConstants.HelpFormDescription)]
    public required string Description { get; set; }
}
