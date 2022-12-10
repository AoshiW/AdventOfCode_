namespace AdventOfCode.Y2021;

public class D10 : IDay<long>
{
    public int Year => 2021;

    public int Day => 10;

    public string Title => "Syntax Scoring";

    public long Part1(ReadOnlySpan<char> span)
    {
        var syntaxErrorScore = 0L;
        var fr = new Stack<char>();
        foreach (var line in span.EnumerateLines())
        {
            fr.Clear();
            foreach (var item in line)
            {
                if (item is '(' or '<' or '[' or '{')
                {
                    fr.Push(item switch
                    {
                        '(' => ')',
                        '<' => '>',
                        '[' => ']',
                        '{' => '}',
                        _ => throw new ArgumentException(null, nameof(span))
                    });
                }
                else
                {
                    if (!fr.TryPop(out var iteem) || iteem != item)
                    {
                        syntaxErrorScore += item switch
                        {

                            ')' => 3,
                            ']' => 57,
                            '}' => 1197,
                            '>' => 25137,
                            _ => throw new ArgumentException(null, nameof(span))
                        };
                    }
                }
            }
        }
        return syntaxErrorScore;
    }

    public long Part2(ReadOnlySpan<char> span)
    {
        var fr = new Stack<char>();
        var scores = new List<long>();
        foreach (var line in span.EnumerateLines())
        {
            fr.Clear();
            var ib = false;
            foreach (var item in line)
            {
                if (item is '(' or '<' or '[' or '{')
                {
                    fr.Push(item switch
                    {
                        '(' => ')',
                        '<' => '>',
                        '[' => ']',
                        '{' => '}',
                        _ => throw new ArgumentException(null, nameof(span))
                    });
                }
                else
                {
                    if (!fr.TryPop(out var iteem) || iteem != item)
                    {
                        ib = true;
                        break;
                    }
                }
            }
            if (!ib)
            {
                var temp = 0L;
                while (fr.TryPop(out var item))
                {
                    temp = temp * 5 + item switch
                    {
                        ')' => 1,
                        ']' => 2,
                        '}' => 3,
                        '>' => 4,
                        _ => throw new ArgumentException(null, nameof(span))
                    };
                }
                scores.Add(temp);
            }
        }
        scores.Sort();
        return scores[scores.Count / 2];
    }
}
