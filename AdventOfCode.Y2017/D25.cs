using System.Runtime.InteropServices;

namespace AdventOfCode.Y2017;

public partial class D25 : IDay<int>
{
    public int Year => 2017;

    public int Day => 25;

    public string Title => "The Halting Problem";

    public int Part1(ReadOnlySpan<char> span) {

        var states = new List<State[]>();
        int position = 0, state = 0, steps = 0;
        foreach (var item in span.EnumerateLines())
        {
            if (item.IsEmpty)
            {
                states.Add(new State[2] { new(), new() });
                position = 0;
            }
            else if (states.Count > 0)
            {
                if (item.Contains("In state ", StringComparison.OrdinalIgnoreCase) || item.Contains("If the current value is", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }
                if (item.Contains("- Move one slot to the", StringComparison.OrdinalIgnoreCase))
                {
                    states[^1][position].Move = item.Contains("right", StringComparison.OrdinalIgnoreCase) ? 1 : -1;
                }
                else if (item.Contains("- Write the value", StringComparison.OrdinalIgnoreCase))
                {
                    states[^1][position].Value = item[^2] - '0';
                }
                else// (item.Contains("- Continue with state ", StringComparison.OrdinalIgnoreCase))
                {
                    states[^1][position].NextState = item[^2] - 'A';
                    position = 1;
                }
            }
            else
            {
                if(item.Contains("state", StringComparison.OrdinalIgnoreCase))
                {
                    state = item[^2] - 'A';
                }
                else
                {
                    steps = int.Parse(item.Slice(36, item.LastIndexOf(' ') - 36));
                }
            }
        }
        position = 0;
        var dic = new Dictionary<int, int>();
        while (steps-- > 0)
        {
            ref var value = ref CollectionsMarshal.GetValueRefOrAddDefault(dic, position, out _);
            var item = states[state][value];
            value = item.Value;
            state = item.NextState;
            position += -item.Move;
        }
        return dic.Count(x => x.Value == 1);
    }

    public int Part2(ReadOnlySpan<char> span) => default;
}
