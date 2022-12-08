using System.Net;
using System.Text.Json;

namespace Kunc.AdventOfCode;

public partial class AdventOfCodeClient : IAdventOfCodeClient
{
    private readonly AdventOfCodeClientOptions _options;
    private readonly IAdventOfCodeCache _cache;
    private readonly HttpClient _client;

    public static IAdventOfCodeClient CreateWithFileCache(AdventOfCodeClientOptions options, AdventOfCodeFileCacheOptions? cacheOptions = null)
        => new AdventOfCodeClient(options, new AdventOfCodeFileCache(cacheOptions ?? new()));

    public AdventOfCodeClient(AdventOfCodeClientOptions options, IAdventOfCodeCache? cache = null)
    {
        ArgumentNullException.ThrowIfNull(options);
        _options = options;
        _cache = cache ?? NullAdventOfCodeCache.Instance;
        var uri = new Uri(_options.BaseAddress);
        var cookieContainer = new CookieContainer();
        cookieContainer.Add(uri, new Cookie("session", _options.Session));
        var handler = new HttpClientHandler()
        {
            CookieContainer = cookieContainer
        };
        _client = new HttpClient(handler)
        {
            BaseAddress = uri,
        };
    }

    /// <inheritdoc/>
    public async Task<string> GetPuzzleInputAsync(int year, int day, CancellationToken cancellationToken = default)
    {
        var puzzleInput = await _cache.GetPuzzleInputAsync(year, day, cancellationToken).ConfigureAwait(false);
        if (puzzleInput is null)
        {
            puzzleInput = await _client.GetStringAsync($"{year}/day/{day}/input", cancellationToken).ConfigureAwait(false);
            await _cache.SetPuzzleInputAsync(year, day, puzzleInput, cancellationToken).ConfigureAwait(false);
        }
        return puzzleInput;
    }

    /// <inheritdoc/>
    public async Task<PrivateLeaderboard> GetPrivateLeaderboardAsync(int year, int ownerId, CancellationToken cancellationToken = default)
    {
        var leaderboardJson = await _cache.GetPrivateLeaderboardAsync(year, ownerId, cancellationToken).ConfigureAwait(false);
        if (leaderboardJson is null)
        {
            leaderboardJson = await _client.GetStringAsync($"/{year}/leaderboard/private/view/{ownerId}.json", cancellationToken).ConfigureAwait(false);
            await _cache.SetPrivateLeaderboardAsync(year, ownerId, leaderboardJson, cancellationToken).ConfigureAwait(false);
        }
        return JsonSerializer.Deserialize<PrivateLeaderboard>(leaderboardJson)!;
    }
}
