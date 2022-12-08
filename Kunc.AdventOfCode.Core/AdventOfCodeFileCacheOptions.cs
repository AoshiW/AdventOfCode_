namespace Kunc.AdventOfCode;

public class AdventOfCodeFileCacheOptions
{
    /// <remarks>
    /// {0} for year, {1} for day
    /// </remarks>
    public string PuzzleDirectory { get; set; } = Path.Combine("aocCache", "inputs");

    /// <remarks>
    /// {0} for year, {1} for day
    /// </remarks>
    public string PuzzleFilename { get; set; } = "{0}_{1:00}.txt";

    /// <remarks>
    /// {0} for year, {1} for ownerId
    /// </remarks>
    public string LeaderboardDirectory { get; set; } = Path.Combine("aocCache", "leaderboard");

    /// <remarks>
    /// {0} for year, {1} for ownerId
    /// </remarks>
    public string LeaderboardFilename { get; set; } = "{0}_{1}.txt";

    public TimeSpan LeaderboardCache { get; set; } = TimeSpan.FromMinutes(15);
}
