using System.Numerics;

namespace AdventOfCode.Y2021;

public partial class D21
{
    record struct Pawn :
        IAdditionOperators<Pawn, int, Pawn>
    {
        public int Space;
        public int Score = 0;

        public Pawn(int space)
        {
            Space = space;
        }

        public static Pawn operator +(Pawn p, int i)
        {
            p.Space += i;
            if (p.Space > 10)
                p.Space %= 10;
            p.Score += p.Space == 0 ? 10 : p.Space;
            return p;
        }
    }
}
