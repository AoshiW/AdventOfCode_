using System.Text;

namespace AdventOfCode.Y2017;

public partial class D19 : IDay<string>
{
    public int Year => 2017;

    public int Day => 19;

    public string Title => "A Series of Tubes";

    public string Part1(ReadOnlySpan<char> span)
    {
        var list = new List<string>();
        foreach (var item in span.EnumerateLines())
        {
            list.Add(item.ToString());
        }
        int x = list[0].IndexOf('|'),
            y = 0;
        var state = States.VerticalDown;
        var sb = new StringBuilder(10);
        while (true)
        {
            var item = list[y][x];
            if (item == ' ')
            {
                break;
            }
            else if (char.IsLetter(item))
            {
                sb.Append(item);
            }
            else if (item == '+')
            {
                state = state.HasFlag(States.Vertical)
                    ? list[y][x - 1] == ' ' ? States.HorizontalRight : States.HorizontalLeft
                    : list[y - 1][x] == ' ' ? States.VerticalDown : States.VerticalUp;
            }
            switch (state)
            {
                case States.VerticalUp: y--; break;
                case States.VerticalDown: y++; break;
                case States.HorizontalLeft: x--; break;
                case States.HorizontalRight: x++; break;
                default: break;
            }
        }
        return sb.ToString();
    }

    public string Part2(ReadOnlySpan<char> span)
    {
        var list = new List<string>();
        foreach (var item in span.EnumerateLines())
        {
            list.Add(item.ToString());
        }
        int x = list[0].IndexOf('|'),
            y = 0;
        var state = States.VerticalDown;
        int steps = 0;
        while (true)
        {
            var item = list[y][x];
            if (item == ' ')
            {
                break;
            }
            steps++;
            if (item == '+')
            {
                state = state.HasFlag(States.Vertical)
                    ? list[y][x - 1] == ' ' ? States.HorizontalRight : States.HorizontalLeft
                    : list[y - 1][x] == ' ' ? States.VerticalDown : States.VerticalUp;
            }
            switch (state)
            {
                case States.VerticalUp: y--; break;
                case States.VerticalDown: y++; break;
                case States.HorizontalLeft: x--; break;
                case States.HorizontalRight: x++; break;
                default: break;
            }
        }
        return steps.ToString();
    }
}
