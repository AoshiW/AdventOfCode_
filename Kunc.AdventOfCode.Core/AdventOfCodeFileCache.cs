namespace Kunc.AdventOfCode;

public class AdventOfCodeFileCache : IAdventOfCodeCache
{
    private readonly AdventOfCodeFileCacheOptions _options;

    public AdventOfCodeFileCache(AdventOfCodeFileCacheOptions options)
    {
        ArgumentNullException.ThrowIfNull(options);
        _options = options;
    }

    /// <inheritdoc/>
    public async Task<string?> GetPuzzleInputAsync(int year, int day, CancellationToken cancellationToken)
    {
        var path = CreatePuzzleFilePath(year, day, out _);
        if (File.Exists(path))
        {
            return await File.ReadAllTextAsync(path, cancellationToken).ConfigureAwait(false);
        }
        else
        {
            return null;
        }
    }

    /// <inheritdoc/>
    public async Task SetPuzzleInputAsync(int year, int day, string input, CancellationToken cancellationToken)
    {
        ArgumentException.ThrowIfNullOrEmpty(input);
        var path = CreatePuzzleFilePath(year, day, out var directoryPath);
        EnsureDirectory(directoryPath);
        await File.WriteAllTextAsync(path, input, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<string?> GetPrivateLeaderboardAsync(int year, int ownerId, CancellationToken cancellationToken)
    {
        var path = CreatePrivLeaderboarddFilePath(year, ownerId, out _);
        if (File.Exists(path))
        {
            var lastWrite = File.GetLastWriteTimeUtc(path);
            if (lastWrite + _options.LeaderboardCache < DateTime.UtcNow)
                return await File.ReadAllTextAsync(path, cancellationToken).ConfigureAwait(false);
        }
        return null;
    }

    /// <inheritdoc/>
    public async Task SetPrivateLeaderboardAsync(int year, int ownerId, string jsonLeaderboard, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(jsonLeaderboard);
        var path = CreatePrivLeaderboarddFilePath(year, ownerId, out var directoryPath);
        EnsureDirectory(directoryPath);
        await File.WriteAllTextAsync(path, jsonLeaderboard, cancellationToken).ConfigureAwait(false);
    }

    static void EnsureDirectory(string directoryPath)
    {
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }
    }

    string CreatePuzzleFilePath(int year, int day, out string directoryPath)
    {
        var args = new object[] { year, day };
        directoryPath = string.Format(_options.PuzzleDirectory, args);
        var filename = string.Format(_options.PuzzleFilename, args);
        var relativePath = Path.Combine(directoryPath, filename);
        return Path.GetFullPath(relativePath);
    }

    string CreatePrivLeaderboarddFilePath(int year, int ownerId, out string directoryPath)
    {
        var args = new object[] { year, ownerId };
        directoryPath = string.Format(_options.LeaderboardDirectory, args);
        var filename = string.Format(_options.LeaderboardFilename, args);
        var relativePath = Path.Combine(directoryPath, filename);
        return Path.GetFullPath(relativePath);
    }
}
