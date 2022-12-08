namespace Kunc.AdventOfCode;

public interface IAdventOfCodeClient
{
    Task<string> GetPuzzleInputAsync(int year, int day, CancellationToken cancellationToken = default);

    Task<PrivateLeaderboard> GetPrivateLeaderboardAsync(int year, int ownerId, CancellationToken cancellationToken = default);
}
