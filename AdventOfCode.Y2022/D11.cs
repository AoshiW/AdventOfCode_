using System.Diagnostics;
using System.Numerics;

namespace AdventOfCode.Y2022;

public partial class D11 : IDay<int>
{
    public int Year => 2022;
    public string Title => "Monkey in the Middle";
    public int Day => 11;

    public int Part1(ReadOnlySpan<char> span)
    {
        var monkeys = ParseInput(span).AsSpan();
        for (int i = 0; i < 20; i++)
        {
            foreach (var m in monkeys)
            {
                for (int s = 0; s < m.StartTime.Count; s++)
                {
                    var item = m.Operation(m.StartTime[s]) / 3;
                    var monkeyIndex = item % m.Division == 0 ? m.True : m.False;
                    monkeys[monkeyIndex].StartTime.Add(item);
                    m.Inspect++;
                }
                m.StartTime.Clear();
            }
        }
        monkeys.Sort(static (l, r) => l.Inspect.CompareTo(r.Inspect));
        return monkeys[^1].Inspect * monkeys[^2].Inspect;
    }

    public int Part2(ReadOnlySpan<char> span)
    {
        throw new NotImplementedException();
        var monkeys = new List<Monkey>
        {
            //new(){StartTime = new(){80}, Operation = v=>v*5, D=2, T=4, F=3},
            //new(){StartTime = new(){75, 83, 74}, Operation = v=>v+7, D=7, T=5, F=6},
            //new(){StartTime = new(){ 86, 67, 61, 96, 52, 63, 73}, Operation = v=>v+5, D=3, T=7, F=0},
            //new(){StartTime = new(){85, 83, 55, 85, 57, 70, 85, 52}, Operation = v=>v+8,D=17, T=1, F=5},
            //new(){StartTime = new(){67, 75, 91, 72, 89}, Operation = v=>v+4, D=11, T=3, F=1},
            //new(){StartTime = new(){66, 64, 68, 92, 68, 77}, Operation = v=>v*2, D=19, T=6, F=2},
            //new(){StartTime = new(){97, 94, 79, 88}, Operation = v=>v*v, T=2,D=5, F=7},
            //new(){StartTime = new(){77, 85}, Operation = v=>v+6, T=4,D=13, F=0},

            new(){StartTime = new(){79u, 98u},Operation = v=>v*19, Division=23, True=2, False=3 },
            new(){StartTime = new(){54, 65, 75, 74},Operation = v=>v+6, Division=19, True=2, False=0},
            new(){StartTime = new(){79, 60, 97},Operation = v=>v*v, Division=13, True=1, False=3},
            new(){StartTime = new(){74},Operation = v=>v+3, Division=17, True=0, False=1},
        };
    }

    static List<Monkey> ParseInput(ReadOnlySpan<char> span)
    {
        var monkeys = new List<Monkey>(8);
        var enumerator = span.EnumerateLines();
        while (enumerator.MoveNext())
        {
            if (enumerator.Current.IsEmpty)
                continue;
            var monkey = new Monkey();
            monkeys.Add(monkey);
            enumerator.MoveNext();
            var item = enumerator.Current.Slice(18);
            while (!item.IsEmpty)
            {
                var index = item.IndexOf(',');
                if (index == -1)
                {
                    monkey.StartTime.Add(int.Parse(item));
                    item = default;
                }
                else
                {
                    monkey.StartTime.Add(int.Parse(item.Slice(0, index)));
                    item = item.Slice(index + 2);
                }
            }
            enumerator.MoveNext();
            var o = enumerator.Current[23];
            item = enumerator.Current.Slice(25);
            if (item is "old")
                monkey.Operation = o switch
                {
                    '+' => static o => o + o,
                    '*' => static o => o * o
                };
            else if (BigInteger.TryParse(item, out var val))
                monkey.Operation = o switch
                {
                    '+' => o => o + val,
                    '*' => o => o * val
                };
            else
                throw new UnreachableException();
            enumerator.MoveNext();
            monkey.Division = uint.Parse(enumerator.Current.Slice(21));
            enumerator.MoveNext();
            monkey.True = int.Parse(enumerator.Current.Slice(29));
            enumerator.MoveNext();
            monkey.False = int.Parse(enumerator.Current.Slice(30));
        }
        return monkeys;
    }
}
