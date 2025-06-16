using System.Text.Json.Serialization;

namespace Noxy.NET.Test.Domain.Abstractions.Forms;

public abstract class BaseFormModel
{
    [JsonIgnore]
    public abstract string APIEndpoint { get; }
}
