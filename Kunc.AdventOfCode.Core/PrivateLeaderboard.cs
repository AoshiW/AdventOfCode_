using System.Text.Json.Serialization;

namespace Kunc.AdventOfCode;

public class PrivateLeaderboard
{
    [JsonPropertyName("owner_id")]
    public int OwnerId { get; set; }

    [JsonPropertyName("members")]
    public Dictionary<string, Member> Members { get; set; } = default!;

    ///<remarks>
    ///string represents the year number
    /// </remarks>
    [JsonPropertyName("event")]
    public string Event { get; set; } = default!;
}
