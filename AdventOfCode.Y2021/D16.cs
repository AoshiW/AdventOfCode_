namespace AdventOfCode.Y2021;

public partial class D16 : IDay<ulong>
{
    public int Year => 2021;

    public int Day => 16;

    public string Title => "Packet Decoder";

    public ulong Part1(ReadOnlySpan<char> span)
    {
        var bitReader = new BitReader(span);
        ulong sum = 0;
        while (bitReader.Left > 7)
        {
            var header = bitReader.ReadHeader();
            sum += header.Version;
            if (header.Type == 4)
            {
                bitReader.ReadLetter();
            }
            else
            {
                var temp = bitReader.Read(1);
                bitReader.Read(temp == 0 ? 15 : 11);
            }
        }
        return sum;
    }

    public ulong Part2(ReadOnlySpan<char> span)
    {
        var br = new BitReader(span);
        return Evaluate(ref br);
    }

    static readonly Func<ulong, ulong, ulong>[] funcs = new Func<ulong, ulong, ulong>[]
    {
        (a, b) => a + b,
        (a, b) => a * b,
        Math.Min,
        Math.Max,
        (a, b) => a, 
        (n, m) => n > m ? 1ul : 0,
        (n, m) => n < m ? 1ul : 0,
        (n, m) => n == m ? 1ul : 0,
    };

    static ulong Evaluate(ref BitReader bitReader)
    {
        var header = bitReader.ReadHeader();
        if (header.Type == 4)
            return bitReader.ReadLetter();
        var func = funcs[header.Type];
        return bitReader.Read(1) == 0 
            ? F1(ref bitReader, func) 
            : F2(ref bitReader, func);
    }

    static ulong F1(ref BitReader bitReader, Func<ulong, ulong, ulong> func)
    {
        var r = bitReader.Read(15);
        var qTarget = bitReader.Left - (int)r;
        var temp = Evaluate(ref bitReader);
        while (bitReader.Left != qTarget)
        {
            temp = func(temp, Evaluate(ref bitReader));
        }
        return temp;
    }

    static ulong F2(ref BitReader bitReader, Func<ulong, ulong, ulong> func)
    {
        var count = (int)bitReader.Read(11);
        var temp = Evaluate(ref bitReader);
        for (int i = 1; i < count; i++)
        {
            temp = func(temp, Evaluate(ref bitReader));
        }
        return temp;
    }
}
