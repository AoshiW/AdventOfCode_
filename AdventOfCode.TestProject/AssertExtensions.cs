using Kunc.AdventOfCode;

namespace AdventOfCode.TestProject;

static class AssertExtensions
{
    public static IAdventOfCodeClient Client { get; }

    static AssertExtensions()
    {
        var aocSession = Environment.GetEnvironmentVariable("aoc_session") ?? throw new ArgumentNullException("aocSession");
        Client = AdventOfCodeClient.CreateWithFileCache(
            new() { Session = aocSession },
            new() { PuzzleDirectory = Path.Combine("..", "..", "..", "..", "aoc_cache", "inputs") }
            );
    }

    public static async Task TestDayAsync<T>(this Assert assert, object part1, object? part2) where T : IDay, new()
    {
        var day = new T();
        var input = await Client.GetPuzzleInputAsync(day.Year, day.Day).ConfigureAwait(false);
        try
        {
            Assert.AreEqual(part1, day.Part1(input.AsSpan().TrimEnd()), nameof(IDay.Part1));
            Assert.AreEqual(part2, day.Part2(input.AsSpan().TrimEnd()), nameof(IDay.Part2));
        }
        catch (NotImplementedException ex)
        {
            Assert.Inconclusive($"Not Implemented {ex?.TargetSite?.Name}");
        }
    }
}
