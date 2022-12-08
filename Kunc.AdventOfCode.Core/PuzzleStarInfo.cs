using System.Text.Json.Serialization;

namespace Kunc.AdventOfCode;

public class PuzzleStarInfo
{
    [JsonPropertyName("get_star_ts"), JsonConverter(typeof(DTOffsetUnitTimesptampConverter))]
    public DateTimeOffset GetStar { get; set; }

    [JsonPropertyName("star_index")]
    public int StarIndex { get; set; }
}
