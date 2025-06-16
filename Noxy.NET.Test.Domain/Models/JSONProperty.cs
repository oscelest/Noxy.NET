using System.Collections;
using System.Text.Json;
using System.Text.Json.Serialization;
using Noxy.NET.Test.Domain.Enums;

namespace Noxy.NET.Test.Domain.Models;

public class JSONProperty
{
    public JsonElement Value { get; set; }
    public JSONPropertyTypeEnum Type { get; set; }

    [JsonConstructor]
    public JSONProperty()
    {
    }

    public JSONProperty(object? value)
    {
        Value = ConvertToJsonElement(value);
        Type = value switch
        {
            null => JSONPropertyTypeEnum.Null,
            sbyte => JSONPropertyTypeEnum.SByte,
            byte => JSONPropertyTypeEnum.Byte,
            bool => JSONPropertyTypeEnum.Boolean,
            short => JSONPropertyTypeEnum.Short,
            int => JSONPropertyTypeEnum.Integer,
            long => JSONPropertyTypeEnum.Long,
            ushort => JSONPropertyTypeEnum.UShort,
            uint => JSONPropertyTypeEnum.UInteger,
            ulong => JSONPropertyTypeEnum.ULong,
            float => JSONPropertyTypeEnum.Single,
            decimal => JSONPropertyTypeEnum.Decimal,
            double => JSONPropertyTypeEnum.Double,
            string => JSONPropertyTypeEnum.String,
            Guid => JSONPropertyTypeEnum.Guid,
            DateTime => JSONPropertyTypeEnum.DateTime,
            DateTimeOffset => JSONPropertyTypeEnum.DateTimeOffset,
            IList => JSONPropertyTypeEnum.Array,
            IDictionary => JSONPropertyTypeEnum.Object,
            _ => JSONPropertyTypeEnum.Unknown,
        };
    }

    public object? GetValue()
    {
        return Type switch
        {
            JSONPropertyTypeEnum.Unknown => Value.GetRawText(),
            JSONPropertyTypeEnum.Null => null,
            JSONPropertyTypeEnum.SByte => AsSByte(),
            JSONPropertyTypeEnum.Byte => AsByte(),
            JSONPropertyTypeEnum.Boolean => AsBoolean(),
            JSONPropertyTypeEnum.Short => AsShort(),
            JSONPropertyTypeEnum.Integer => AsInteger(),
            JSONPropertyTypeEnum.Long => AsLong(),
            JSONPropertyTypeEnum.UShort => AsUShort(),
            JSONPropertyTypeEnum.UInteger => AsUInteger(),
            JSONPropertyTypeEnum.ULong => AsULong(),
            JSONPropertyTypeEnum.Single => AsSingle(),
            JSONPropertyTypeEnum.Decimal => AsDecimal(),
            JSONPropertyTypeEnum.Double => AsDouble(),
            JSONPropertyTypeEnum.String => AsString(),
            JSONPropertyTypeEnum.Guid => AsGUID(),
            JSONPropertyTypeEnum.DateTime => AsDateTime(),
            JSONPropertyTypeEnum.DateTimeOffset => AsDateTimeOffset(),
            JSONPropertyTypeEnum.Array => AsArray(),
            JSONPropertyTypeEnum.Object => AsDictionary(),
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    public sbyte? AsSByte()
    {
        return Value.ValueKind switch
        {
            JsonValueKind.True => 1,
            JsonValueKind.False => 0,
            JsonValueKind.Number => Value.TryGetInt32(out int value) && value is >= sbyte.MinValue and <= sbyte.MaxValue ? (sbyte)value : null,
            JsonValueKind.String => sbyte.TryParse(Value.GetString(), out sbyte value) ? value : null,
            JsonValueKind.Null or JsonValueKind.Undefined => null,
            JsonValueKind.Object or JsonValueKind.Array => throw new InvalidOperationException(),
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    public byte? AsByte()
    {
        return Value.ValueKind switch
        {
            JsonValueKind.True => 1,
            JsonValueKind.False => 0,
            JsonValueKind.Number => Value.TryGetInt32(out int value) && value is >= byte.MinValue and <= byte.MaxValue ? (byte)value : null,
            JsonValueKind.String => byte.TryParse(Value.GetString(), out byte value) ? value : null,
            JsonValueKind.Null or JsonValueKind.Undefined => null,
            JsonValueKind.Object or JsonValueKind.Array => throw new InvalidOperationException(),
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    public bool? AsBoolean()
    {
        return Value.ValueKind switch
        {
            JsonValueKind.True => true,
            JsonValueKind.False => false,
            JsonValueKind.Number => GetNumberAsBoolean(),
            JsonValueKind.String => bool.TryParse(Value.GetString(), out bool value) ? value : null,
            JsonValueKind.Null or JsonValueKind.Undefined => null,
            JsonValueKind.Object or JsonValueKind.Array => throw new InvalidOperationException(),
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    public short? AsShort()
    {
        return Value.ValueKind switch
        {
            JsonValueKind.True => 1,
            JsonValueKind.False => 0,
            JsonValueKind.Number => Value.TryGetInt16(out short value) ? value : null,
            JsonValueKind.String => short.TryParse(Value.GetString(), out short value) ? value : null,
            JsonValueKind.Null or JsonValueKind.Undefined => null,
            JsonValueKind.Object or JsonValueKind.Array => throw new InvalidOperationException(),
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    public int? AsInteger()
    {
        return Value.ValueKind switch
        {
            JsonValueKind.True => 1,
            JsonValueKind.False => 0,
            JsonValueKind.Number => Value.TryGetInt32(out int value) ? value : null,
            JsonValueKind.String => int.TryParse(Value.GetString(), out int value) ? value : null,
            JsonValueKind.Null or JsonValueKind.Undefined => null,
            JsonValueKind.Object or JsonValueKind.Array => throw new InvalidOperationException(),
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    public long? AsLong()
    {
        return Value.ValueKind switch
        {
            JsonValueKind.True => 1,
            JsonValueKind.False => 0,
            JsonValueKind.Number => Value.TryGetInt64(out long value) ? value : null,
            JsonValueKind.String => long.TryParse(Value.GetString(), out long value) ? value : null,
            JsonValueKind.Null or JsonValueKind.Undefined => null,
            JsonValueKind.Object or JsonValueKind.Array => throw new InvalidOperationException(),
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    public ushort? AsUShort()
    {
        return Value.ValueKind switch
        {
            JsonValueKind.True => 1,
            JsonValueKind.False => 0,
            JsonValueKind.Number => Value.TryGetUInt16(out ushort value) ? value : null,
            JsonValueKind.String => ushort.TryParse(Value.GetString(), out ushort value) ? value : null,
            JsonValueKind.Null or JsonValueKind.Undefined => null,
            JsonValueKind.Object or JsonValueKind.Array => throw new InvalidOperationException(),
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    public uint? AsUInteger()
    {
        return Value.ValueKind switch
        {
            JsonValueKind.True => 1,
            JsonValueKind.False => 0,
            JsonValueKind.Number => Value.TryGetUInt32(out uint value) ? value : null,
            JsonValueKind.String => uint.TryParse(Value.GetString(), out uint value) ? value : null,
            JsonValueKind.Null or JsonValueKind.Undefined => null,
            JsonValueKind.Object or JsonValueKind.Array => throw new InvalidOperationException(),
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    public ulong? AsULong()
    {
        return Value.ValueKind switch
        {
            JsonValueKind.True => 1,
            JsonValueKind.False => 0,
            JsonValueKind.Number => Value.TryGetUInt64(out ulong value) ? value : null,
            JsonValueKind.String => ulong.TryParse(Value.GetString(), out ulong value) ? value : null,
            JsonValueKind.Null or JsonValueKind.Undefined => null,
            JsonValueKind.Object or JsonValueKind.Array => throw new InvalidOperationException(),
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    public float? AsSingle()
    {
        return Value.ValueKind switch
        {
            JsonValueKind.True => 1,
            JsonValueKind.False => 0,
            JsonValueKind.Number => Value.TryGetSingle(out float value) ? value : null,
            JsonValueKind.String => float.TryParse(Value.GetString(), out float value) ? value : null,
            JsonValueKind.Null or JsonValueKind.Undefined => null,
            JsonValueKind.Object or JsonValueKind.Array => throw new InvalidOperationException(),
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    public decimal? AsDecimal()
    {
        return Value.ValueKind switch
        {
            JsonValueKind.True => 1,
            JsonValueKind.False => 0,
            JsonValueKind.Number => Value.TryGetDecimal(out decimal value) ? value : null,
            JsonValueKind.String => decimal.TryParse(Value.GetString(), out decimal value) ? value : null,
            JsonValueKind.Null or JsonValueKind.Undefined => null,
            JsonValueKind.Object or JsonValueKind.Array => throw new InvalidOperationException(),
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    public object? AsDouble()
    {
        return Value.ValueKind switch
        {
            JsonValueKind.True => 1,
            JsonValueKind.False => 0,
            JsonValueKind.Number => Value.TryGetDouble(out double value) ? value : null,
            JsonValueKind.String => double.TryParse(Value.GetString(), out double value) ? value : null,
            JsonValueKind.Null or JsonValueKind.Undefined => null,
            JsonValueKind.Object or JsonValueKind.Array => throw new InvalidOperationException(),
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    public string? AsString()
    {
        return Value.ValueKind switch
        {
            JsonValueKind.True => "true",
            JsonValueKind.False => "false",
            JsonValueKind.Number => Value.GetRawText(),
            JsonValueKind.String => Value.GetString(),
            JsonValueKind.Null or JsonValueKind.Undefined => null,
            JsonValueKind.Object or JsonValueKind.Array => throw new InvalidOperationException(),
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    public Guid? AsGUID()
    {
        return Value.ValueKind switch
        {
            JsonValueKind.True => throw new InvalidOperationException(),
            JsonValueKind.False => throw new InvalidOperationException(),
            JsonValueKind.Number => throw new InvalidOperationException(),
            JsonValueKind.String => Value.GetGuid(),
            JsonValueKind.Null or JsonValueKind.Undefined => null,
            JsonValueKind.Object or JsonValueKind.Array => throw new InvalidOperationException(),
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    public DateTime? AsDateTime()
    {
        return Value.ValueKind switch
        {
            JsonValueKind.True => throw new InvalidOperationException(),
            JsonValueKind.False => throw new InvalidOperationException(),
            JsonValueKind.Number => throw new InvalidOperationException(),
            JsonValueKind.String => Value.GetDateTime(),
            JsonValueKind.Null or JsonValueKind.Undefined => null,
            JsonValueKind.Object or JsonValueKind.Array => throw new InvalidOperationException(),
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    public DateTimeOffset? AsDateTimeOffset()
    {
        return Value.ValueKind switch
        {
            JsonValueKind.True => throw new InvalidOperationException(),
            JsonValueKind.False => throw new InvalidOperationException(),
            JsonValueKind.Number => Value.TryGetInt64(out long value) ? DateTimeOffset.FromUnixTimeSeconds(value) : null,
            JsonValueKind.String => Value.GetDateTimeOffset(),
            JsonValueKind.Null or JsonValueKind.Undefined => null,
            JsonValueKind.Object or JsonValueKind.Array => throw new InvalidOperationException(),
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    public object?[] AsArray()
    {
        return Value.EnumerateArray().Select(x => x.Deserialize<JSONProperty>()?.GetValue()).ToArray();
    }

    public Dictionary<string, object?> AsDictionary()
    {
        return Value.EnumerateObject().ToDictionary(x => x.Name, x => x.Value.Deserialize<JSONProperty>()?.GetValue());
    }

    private bool? GetNumberAsBoolean()
    {
        if (Value.TryGetInt32(out int valueInt))
        {
            return valueInt switch
            {
                0 => false,
                1 => true,
                _ => null
            };
        }

        if (Value.TryGetDecimal(out decimal valueDecimal))
        {
            return valueDecimal switch
            {
                0m => false,
                1m => true,
                _ => null
            };
        }

        return null;
    }

    private static JsonElement ConvertToJsonElement(object? value)
    {
        return JsonDocument.Parse(JsonSerializer.Serialize(value)).RootElement;
    }
}
