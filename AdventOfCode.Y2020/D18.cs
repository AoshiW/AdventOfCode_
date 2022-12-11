namespace AdventOfCode.Y2020;

public class D18 : IDay<long>
{
    public int Year => 2020;

    public int Day => 18;

    public string Title => "Operation Order";

    public long Part1(ReadOnlySpan<char> span)
    {
        long sum = 0;
        foreach (var item in span.EnumerateLines())
        {
            sum += ProcessPostfix(ToPostfix(item, x => x == '(' ? -1 : 1));
        }
        return sum;
    }

    static Queue<char> ToPostfix(ReadOnlySpan<char> span, Func<char, int> operatorPriority)
    {
        var stack = new Stack<char>();
        var queue = new Queue<char>();
        foreach (var item in span)
        {
            if (item == ' ')
                continue;
            if (char.IsDigit(item))
            {
                queue.Enqueue(item);
            }
            else if (item == '(')
            {
                stack.Push(item);
            }
            else if (item == ')')
            {
                while (stack.TryPop(out var operatorOrBracket) && operatorOrBracket != '(')
                {
                    queue.Enqueue(operatorOrBracket);
                }
            }
            else
            {
                while (stack.TryPeek(out var operan) && operatorPriority(item) <= operatorPriority(operan))
                {
                    queue.Enqueue(stack.Pop());
                }
                stack.Push(item);
            }
        }
        while (stack.TryPop(out var item))
        {
            queue.Enqueue(item);
        }
        return queue;
    }

    static long ProcessPostfix(Queue<char> queue)
    {
        var stak = new Stack<long>();
        while (queue.TryDequeue(out var item))
        {
            if (char.IsDigit(item))
            {
                stak.Push((long)char.GetNumericValue(item));
            }
            else
            {
                Func<long, long, long> fnc = item switch
                {
                    '+' => (a, b) => a + b,
                    '*' => (a, b) => a * b,
                    _ => throw new ArgumentException(null, nameof(queue))
                };
                stak.Push(fnc(stak.Pop(), stak.Pop()));
            }
        }
        return stak.Pop();
    }

    public long Part2(ReadOnlySpan<char> span)
    {
        long sum = 0;
        foreach (var item in span.EnumerateLines())
        {
            sum += ProcessPostfix(ToPostfix(item, x => x switch { '*' => 1, '+' => 2, _ => -1 }));
        }
        return sum;
    }
}
