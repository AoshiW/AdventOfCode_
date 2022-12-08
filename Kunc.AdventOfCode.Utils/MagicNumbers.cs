using System.Drawing;
using System.Runtime.CompilerServices;

namespace Kunc.AdventOfCode.Utils;

public static class MagicNumbers
{
    public const int MD5HashByteCount = 16;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int MaxStringLengthFor<T>()
    {
        if (typeof(T) == typeof(int))
            return 11;
        throw new ArgumentException(null, nameof(T));
    }

    public static ReadOnlySpan<Size> Offset8 => Offset8Data;
    private static readonly Size[] Offset8Data = new Size[]
    {
            new(-1,-1), new(-1,0), new(-1,1),
            new(0,-1), new(0,1),
            new(1,-1), new(1,0), new(1,1)
    };

    public static ReadOnlySpan<Size> Offset4 => Offset4Data;
    private static readonly Size[]  Offset4Data = new Size[]
    {
        new(-1,0), new(0,-1), new(0,1), new(1,0)
    };
}
