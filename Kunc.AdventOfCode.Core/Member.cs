using System.Text.Json.Serialization;

namespace Kunc.AdventOfCode;

public class Member
{
    [JsonPropertyName("global_score")]
    public int GlobalScore { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("completion_day_level")]
    public Dictionary<string, Dictionary<string, PuzzleStarInfo>> CompletionDayLevel { get; set; } = default!;

    //TODO Convertor
    [JsonPropertyName("last_star_ts")]
    public long LastStar { get; set; }

    [JsonPropertyName("local_score")]
    public int LocalScore { get; set; }

    [JsonPropertyName("stars")]
    public int Stars { get; set; }
}
