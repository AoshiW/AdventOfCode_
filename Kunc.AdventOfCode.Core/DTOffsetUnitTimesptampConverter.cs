using System.Text.Json;
using System.Text.Json.Serialization;

namespace Kunc.AdventOfCode;

class DTOffsetUnitTimesptampConverter : JsonConverter<DateTimeOffset>
{
    public override DateTimeOffset Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var unixTimestamp = reader.GetInt64();
        return DateTimeOffset.FromUnixTimeSeconds(unixTimestamp);
    }

    public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options)
    {
        writer.WriteNumberValue(value.ToUnixTimeSeconds());
    }
}
