using System.Runtime.InteropServices;

namespace AdventOfCode.Y2016;

public partial class D10 : IDay<int>
{
    public int Year => 2016;

    public int Day => 10;

    public string Title => "Balance Bots";

    record Move(int BotId, bool IsOutput);

    public int Part1(ReadOnlySpan<char> span)
    {
        var (bots, move) = Init(span);
        KeyValuePair<int, Bot> it;
        while ((it = bots.FirstOrDefault(x => x.Value.Chip.Count == 2)).Value is not null)
        {
            if (it.Value.Chip.Contains(17) && it.Value.Chip.Contains(61))
                return it.Key;
            move.Remove(it.Key, out var remove);
            MakeMove(bots, remove, it.Key);
        }
        throw new ArgumentException(null, nameof(span));
    }

    static (Dictionary<int, Bot> bots, Dictionary<int, (Move Low, Move High)> move) Init(ReadOnlySpan<char> span)
    {
        var move = new Dictionary<int, (Move Low, Move High)>();
        var dic = new Dictionary<int, Bot>();
        foreach (var item in span.EnumerateLines())
        {
            if (item.StartsWith("value", StringComparison.OrdinalIgnoreCase))
            {
                var enumerator = item.EnumerateSlices(" ");
                enumerator.MoveNext();
                enumerator.MoveNext();
                var value = int.Parse(enumerator.Current);
                enumerator.MoveNext();
                enumerator.MoveNext();
                enumerator.MoveNext();
                enumerator.MoveNext();
                var botI = int.Parse(enumerator.Current);
                if (dic.TryGetValue(botI, out var bot))
                {
                    bot.Chip.Add(value);
                }
                else
                {
                    dic[botI] = new(value);
                }
            }
            else
            {
                var enumerator = item.EnumerateSlices(" ");
                enumerator.MoveNext();
                enumerator.MoveNext();
                var bot = int.Parse(enumerator.Current);
                enumerator.MoveNext();
                enumerator.MoveNext();
                enumerator.MoveNext();
                enumerator.MoveNext();
                var where = enumerator.Current;
                enumerator.MoveNext();
                var botI = int.Parse(enumerator.Current);
                var low = new Move(botI, where.Equals("output", StringComparison.OrdinalIgnoreCase));
                enumerator.MoveNext();
                enumerator.MoveNext();
                enumerator.MoveNext();
                enumerator.MoveNext();
                where = enumerator.Current;
                enumerator.MoveNext();
                botI = int.Parse(enumerator.Current);
                var high = new Move(botI, where.Equals("output", StringComparison.OrdinalIgnoreCase));
                move.Add(bot, (low, high));
            }
        }
        return (dic, move);
    }

    static void MakeMove(Dictionary<int, Bot> dic, (Move Low, Move High) item, int i)
    {
        var bot = dic[i];
        var min = bot.Chip.Min();
        bot.Chip.Remove(min);
        var max = bot.Chip[0];
        bot.Chip.Remove(max);
        ref var value = ref CollectionsMarshal.GetValueRefOrAddDefault(dic, item.Low.BotId, out var exists)!;
        if (!exists)
        {
            value = new();
        }
        if (item.Low.IsOutput)
        {
            value.Output = min;
        }
        else
        {
            value.Chip.Add(min);
        }

        value = ref CollectionsMarshal.GetValueRefOrAddDefault(dic, item.High.BotId, out exists)!;
        if (!exists)
        {
            value = new();
        }
        if (item.High.IsOutput)
        {
            value.Output = max;
        }
        else
        {
            value.Chip.Add(max);
        }
    }

    public int Part2(ReadOnlySpan<char> span)
    {
        var (bots, move) = Init(span);
        KeyValuePair<int, Bot> it;
        while ((it = bots.FirstOrDefault(x => x.Value.Chip.Count == 2)).Value is not null)
        {
            move.Remove(it.Key, out var remove);
            MakeMove(bots, remove, it.Key);
        }
        return bots[0].Output * bots[1].Output * bots[2].Output;
    }
}
