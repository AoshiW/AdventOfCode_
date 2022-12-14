using System.Numerics;

namespace AdventOfCode.Y2022;

public partial class D11
{
    class Monkey
    {
        public List<BigInteger> StartTime { get; set; } = new(4);
        public Func<BigInteger, BigInteger> Operation { get; set; } = default!;
        public uint Division;
        public int True;
        public int False;
        public int Inspect;
    }
}
