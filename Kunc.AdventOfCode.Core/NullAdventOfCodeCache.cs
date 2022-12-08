namespace Kunc.AdventOfCode;

/// <summary>
/// Minimalistic AoC cache that does nothing.
/// </summary>
public class NullAdventOfCodeCache : IAdventOfCodeCache
{
    /// <summary>
    /// Returns the shared instance of <see cref="NullAdventOfCodeCache"/>.
    /// </summary>
    public static NullAdventOfCodeCache Instance => _instance ??= new();
    private static NullAdventOfCodeCache? _instance;

    private NullAdventOfCodeCache() { }

    /// <inheritdoc/>
    public Task<string?> GetPuzzleInputAsync(int year, int day, CancellationToken cancellationToken = default)
        => Task.FromResult<string?>(null);

    /// <inheritdoc/>
    public Task SetPuzzleInputAsync(int year, int day, string input, CancellationToken cancellationToken = default)
        => Task.CompletedTask;

    /// <inheritdoc/>
    public Task<string?> GetPrivateLeaderboardAsync(int year, int ownerId, CancellationToken cancellationToken = default)
        => Task.FromResult<string?>(null);

    /// <inheritdoc/>
    public Task SetPrivateLeaderboardAsync(int year, int ownerId, string leaderboard, CancellationToken cancellationToken = default)
        => Task.CompletedTask;
}
