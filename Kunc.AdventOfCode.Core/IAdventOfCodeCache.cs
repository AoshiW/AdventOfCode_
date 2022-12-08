namespace Kunc.AdventOfCode;

public interface IAdventOfCodeCache
{
    Task<string?> GetPuzzleInputAsync(int year, int day, CancellationToken cancellationToken = default);
    
    Task SetPuzzleInputAsync(int year, int day, string input, CancellationToken cancellationToken = default);

    Task<string?> GetPrivateLeaderboardAsync(int year, int ownerId, CancellationToken cancellationToken = default);
    
    Task SetPrivateLeaderboardAsync(int year, int ownerId, string leaderboard, CancellationToken cancellationToken = default);
}
