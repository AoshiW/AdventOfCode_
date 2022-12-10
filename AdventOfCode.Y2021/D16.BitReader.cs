namespace AdventOfCode.Y2021;

public partial class D16
{
    ref struct BitReader
    {
        static readonly ulong[] mask = new ulong[64];

        static BitReader()
        {
            var value = 0ul;
            for (int i = 0; i < 64; i++)
            {
                value = (value << 1) | 1;
                mask[i] = value;
            }
        }

        int _position = 0, _left = 0;
        ulong _value = 0;
        readonly ReadOnlySpan<char> _span;
        
        public BitReader(ReadOnlySpan<char> span)
        {
            _span = span;
        }

        public readonly int Left => (_span.Length - _position) * 4 + _left;

        public  ulong Read(int count)
        {
            while (_left < 61 && _position < _span.Length)
            {
                _value = (_value << 4) | _span[_position++].FromHex();
                _left += 4;
            }
            return (_value >> (_left -= count)) & mask[count - 1];
        }

        public (ulong Version, ulong Type) ReadHeader()
        {
            var v = Read(3);
            var t = Read(3);
            return (v, t);
        }

        public ulong ReadLetter()
        {
            ulong num = 0;
            var next = true;
            while (next)
            {
                next = Read(1) == 1;
                num = (num << 4) | Read(4);
            }
            return num;
        }
    }
}
