using System.Text.Json.Serialization;

namespace Noxy.NET.Test.Domain.Models;

public class GenericUUID<T>(Guid? value)
{
    public Guid? Value { get; set; } = value;
    public string Name { get; set; } = typeof(T).Name;

    [JsonConstructor]
    public GenericUUID() : this(null)
    {
    }
}
