namespace AdventOfCode.Y2021;

public partial class D21 : IDay<long>
{
    public int Year => 2021;

    public int Day => 21;

    public string Title => "Dirac Dice";

    static void ParseInput(ReadOnlySpan<char> span, out Pawn p1, out Pawn p2)
    {
        var enumerator = span.EnumerateLines();
        enumerator.MoveNext();
        var lastIndex = enumerator.Current.LastIndexOf(' ');
        p1 = new(int.Parse(enumerator.Current.Slice(lastIndex + 1)));
        enumerator.MoveNext();
        p2 = new(int.Parse(enumerator.Current.Slice(lastIndex + 1)));
    }

    public long Part1(ReadOnlySpan<char> span)
    {
        ParseInput(span, out var p1, out var p2);
        var isPlayer1 = true;
        int num = 1;
        int ii = 0;
        while (p1.Score < 1000 && p2.Score < 1000)
        {
            ref var p = ref isPlayer1 ? ref p1 : ref p2;
            var move = num++; if (num == 101) num = 1;
            move += num++; if (num == 101) num = 1;
            move += num++; if (num == 101) num = 1;
            ii += 3;
            p += move;
            isPlayer1 = !isPlayer1;
        }
        return ii * (p1.Score < 1000 ? p1.Score : p2.Score);
    }

    public long Part2(ReadOnlySpan<char> span)
    {
        ParseInput(span, out var p1, out var p2);
        var res = QuantumRoll(p2, p1);
        return Math.Max(res.Item1, res.Item2);
    }

    static readonly (int, int Value)[] Roll = new[] {
        (1, 3), (1, 9),
        (3, 4), (3, 8),
        (6, 5), (6, 7),
        (7, 6),
    };

    static (long, long) QuantumRoll(Pawn p1, Pawn p2, bool isPlayer1 = true)
    {
        if (p1.Score >= 21)
            return isPlayer1 ? (1, 0) : (0, 1);
        isPlayer1 = !isPlayer1;
        long r1 = 0, r2 = 0;
        foreach (var item in Roll)
        {
            var temp = QuantumRoll(p2 + item.Value, p1, isPlayer1);
            r1 += temp.Item1 * item.Item1;
            r2 += temp.Item2 * item.Item1;
        }
        return (r1, r2);
    }
}
