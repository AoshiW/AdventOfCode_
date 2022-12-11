using System.Text;

namespace AdventOfCode.Y2020;

public class D22 : IDay<int>
{
    public int Year => 2020;

    public int Day => 22;

    public string Title => "Crab Combat";

    public int Part1(ReadOnlySpan<char> span)
    {
        var decks = ParseInput(span);
        while (decks[0].Count > 0 && decks[1].Count > 0)
        {
            var p1 = decks[0].First!;
            decks[0].RemoveFirst();
            var p2 = decks[1].First!;
            decks[1].RemoveFirst();
            if (p1.Value > p2.Value)
            {
                decks[0].AddLast(p1);
                decks[0].AddLast(p2);
            }
            else
            {
                decks[1].AddLast(p2);
                decks[1].AddLast(p1);
            }
        }
        return Score(decks.First(x => x.Count > 0));
    }

    static LinkedList<int>[] ParseInput(ReadOnlySpan<char> span)
    {
        var result = new LinkedList<int>[2] { new(), new() };
        bool player = true, skip = true;
        foreach (var item in span.EnumerateLines())
        {
            if (item.Length == 0)
            {
                skip = true;
                player = false;

            }
            else if (skip)
            {
                skip = false;
                continue;
            }
            else
            {
                result[player ? 0 : 1].AddLast(int.Parse(item));
            }
        }
        return result;
    }

    static int Score(LinkedList<int> queue)
    {
        var result = 0;
        int i = queue.Count;
        foreach (var item in queue)
        {
            result += item * i;
            i--;
        }
        return result;
    }

    public int Part2(ReadOnlySpan<char> span)
    {
        var decks = ParseInput(span);
        var result = Game(decks);
        return Score(decks[result ? 0 : 1]);
    }

    bool Game(LinkedList<int>[] decks)
    {
        HashSet<string> history = new();
        while (decks[0].Count > 0 && decks[1].Count > 0)
        {
            if (Checkdecks(decks, history))
                return true;
            var p1 = decks[0].First!;
            decks[0].RemoveFirst();
            var p2 = decks[1].First!;
            decks[1].RemoveFirst();
            bool result;
            if (decks[0].Count >= p1.Value && decks[1].Count >= p2.Value)
            {
                var temp = new[]
                {
                    ToLinkedList(decks[0], p1.Value), ToLinkedList(decks[1], p2.Value)
                };
                result = Game(temp);
            }
            else
            {
                result = p1.Value > p2.Value;
            }
            if (result)
            {
                decks[0].AddLast(p1);
                decks[0].AddLast(p2);
            }
            else
            {
                decks[1].AddLast(p2);
                decks[1].AddLast(p1);
            }
        }
        return decks[0].Count > 0;
    }

    static LinkedList<T> ToLinkedList<T>(LinkedList<T> ts, int count)
    {
        var temp = new LinkedList<T>();
        foreach (var item in ts)
        {
            temp.AddLast(item);
            if (--count == 0)
                break;
        }
        return temp;
    }

    static bool Checkdecks(LinkedList<int>[] queue, HashSet<string> history)
    {
        var sb = new StringBuilder();
        for (int i = 0; i < queue.Length; i++)
        {
            foreach (var item in queue[i])
            {
                sb.Append(item).Append('_');
            }
            sb.Append('-');
        }
        return !history.Add(sb.ToString());
    }
}
