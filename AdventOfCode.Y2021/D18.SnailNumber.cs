using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Text;

namespace AdventOfCode.Y2021;

public partial class D18
{
    class SnailNumber :
        ISpanParsable<SnailNumber>,
        IAdditionOperators<SnailNumber, SnailNumber, SnailNumber>
    {
        [MemberNotNullWhen(false, nameof(Left), nameof(Right))]
        public bool IsValue => Left is null || Right is null;
        public int Value;
        public SnailNumber? Left, Right;
        private SnailNumber? _parrent;

        public int GetMagnitude() => IsValue ? Value : 3 * Left.GetMagnitude() + 2 * Right.GetMagnitude();
        static SnailNumber? Copy(SnailNumber? sn)
        {
            if (sn is null)
                return null;
            var temp = new SnailNumber()
            {
                Value = sn.Value,
                Left = Copy(sn.Left),
                Right = Copy(sn.Right),
            };
            if (!temp.IsValue)
                temp.Left._parrent = temp.Right._parrent = temp;
            return temp;
        }

        public static bool TryExplode(SnailNumber? snailNumber, int level)
        {
            if (snailNumber is null || snailNumber.IsValue)
                return false;
            if (level == 4)
            {
                var tempSN = snailNumber;
                while (tempSN == tempSN._parrent?.Left)
                {
                    tempSN = tempSN._parrent;
                }
                tempSN = tempSN?._parrent?.Left;
                if (tempSN is not null)
                {
                    while (!tempSN.IsValue)
                    {
                        tempSN = tempSN.Right;
                    }
                    tempSN.Value += snailNumber.Left.Value;
                }
                tempSN = snailNumber;
                while (tempSN == tempSN._parrent?.Right)
                {
                    tempSN = tempSN._parrent;
                }
                tempSN = tempSN?._parrent?.Right;
                if (tempSN is not null)
                {
                    while (!tempSN.IsValue)
                    {
                        tempSN = tempSN.Left;
                    }
                    tempSN.Value += snailNumber.Right.Value;
                }
                snailNumber.Left = snailNumber.Right = null;
                return true;
            }
            level++;
            return TryExplode(snailNumber.Left, level) || TryExplode(snailNumber.Right, level);
        }

        public static bool TrySplit(SnailNumber snailNumber)
        {
            if (!snailNumber.IsValue)
            {
                return TrySplit(snailNumber.Left) || TrySplit(snailNumber.Right);
            }
            if (snailNumber.Value > 9)
            {
                snailNumber.Left = new()
                {
                    _parrent = snailNumber,
                    Value = snailNumber.Value / 2,
                };
                snailNumber.Right = new()
                {
                    _parrent = snailNumber,
                    Value = snailNumber.Value - snailNumber.Left.Value,
                };
                snailNumber.Value = 0;
                return true;
            }
            return false;
        }

        public static SnailNumber operator +(SnailNumber left, SnailNumber right)
        {
            var temp = new SnailNumber()
            {
                Left = Copy(left),
                Right = Copy(right)
            };
            temp.Left!._parrent = temp.Right!._parrent = temp;
            while (TryExplode(temp, 0) || TrySplit(temp))
                ;
            return temp;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            ToStringCore(sb, this);
            return sb.ToString();
        }

        static void ToStringCore(StringBuilder stringBuilder, SnailNumber snailNumber)
        {
            if (snailNumber.IsValue)
            {
                stringBuilder.Append(snailNumber.Value);
            }
            else
            {
                stringBuilder.Append('[');
                ToStringCore(stringBuilder, snailNumber.Left);
                stringBuilder.Append(',');
                ToStringCore(stringBuilder, snailNumber.Right);
                stringBuilder.Append(']');
            }
        }

        public static SnailNumber Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
            => TryParse(s, provider, out var result)
            ? result
            : throw new FormatException();

        public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, [MaybeNullWhen(false)] out SnailNumber result)
        {
            result = default;
            if (s[0] == '[')
            {
                var i = 1;
                int b = 0;
                for (; b != 0 || i == 1; i++)
                {
                    if (s[i] == '[')
                    {
                        b++;
                    }
                    else if (s[i] == ']')
                    {
                        b--;
                    }
                }
                if (b != 0)
                    return false;
                var leftSlice = s.Slice(1, i - 1);
                var rightSlice = s.Slice(++i, s.Length - i - 1);
                if (!TryParse(leftSlice, provider, out var left) || !TryParse(rightSlice, provider, out var right))
                {
                    return false;
                }
                result = new SnailNumber()
                {
                    Left = left,
                    Right = right
                };
                result.Left._parrent = result.Right._parrent = result;
                return true;
            }
            else
            {
                if (int.TryParse(s, out var number))
                {
                    result = new() { Value = number };
                    return true;

                }
                else
                {
                    return false;
                }
            }
        }

        public static SnailNumber Parse(string s, IFormatProvider? provider)
        {
            ArgumentNullException.ThrowIfNull(s);
            return Parse(s.AsSpan(), provider);
        }

        public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out SnailNumber result)
            => TryParse(s.AsSpan(), provider, out result);
    }
}
