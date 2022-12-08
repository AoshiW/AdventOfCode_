using System.Runtime.InteropServices;

namespace AdventOfCode.Y2016;

public partial class D12
{
    public class PC
    {
        (Action<ValueOrRegister[]>, ValueOrRegister[]) PareLine(ReadOnlySpan<char> span)
        {
            var enumerator = span.EnumerateSlices(" ");
            enumerator.MoveNext();
            var instruction = enumerator.Current;
            var arg = new List<ValueOrRegister>();
            while (enumerator.MoveNext())
            {
                if (int.TryParse(enumerator.Current, out var value))
                    arg.Add(new(value));
                else
                    arg.Add(new(enumerator.Current[0]));
            }
            var argArr = arg.ToArray();
            return instruction switch
            {
                "inc" => (Inc, argArr),
                "dec" => (Dec, argArr),
                "jnz" => (Jnz, argArr),
                "cpy" => (Cpy, argArr),
                "tgl" => (Tgl, argArr),
                _ => throw new NotImplementedException(),
            };
        }

        int _counter = 0;

        public Dictionary<char, int> Registers { get; } = new();
        readonly List<(Action<ValueOrRegister[]>, ValueOrRegister[])> _instructionss = new();

        public PC(ReadOnlySpan<char> span)
        {
            foreach (var item in span.EnumerateLines())
            {
                _instructionss.Add(PareLine(item));
            }
        }

        public void Execute()
        {
            while (_counter < _instructionss.Count)
            {
                var inn = _instructionss[_counter];
                inn.Item1(inn.Item2);
            }
        }

        void Inc(ValueOrRegister[] args)
        {
            ref var val = ref CollectionsMarshal.GetValueRefOrAddDefault(Registers, (char)args[0].Value, out _);
            val++;
            _counter++;
        }

        void Dec(ValueOrRegister[] args)
        {
            ref var val = ref CollectionsMarshal.GetValueRefOrAddDefault(Registers, (char)args[0].Value, out _);
            val--;
            _counter++;
        }

        void Cpy(ValueOrRegister[] args)
        {
            if (args[1].IsRegister)
            {
                ref var reg = ref CollectionsMarshal.GetValueRefOrAddDefault(Registers, (char)args[1].Value, out _);
                reg = args[0].GetValue(Registers);
            }
            _counter++;
        }
        void Jnz(ValueOrRegister[] args)
        {
            if (args[0].GetValue(Registers) != 0)
            {
                _counter += args[1].GetValue(Registers);
            }
            else _counter++;

        }

        /// <remarks>For <see cref="D23"/></remarks>
        void Tgl(ValueOrRegister[] args)
        {
            var offset = args[0].GetValue(Registers) + _counter;
            if (offset < _instructionss.Count)
            {
                var item = _instructionss[offset];
                if (item.Item1 == Inc)
                {
                    _instructionss[offset] = (Dec, item.Item2);
                }
                else if (item.Item2.Length == 1)
                {
                    _instructionss[offset] = (Inc, item.Item2);
                }
                else if (item.Item1 == Jnz)
                {
                    _instructionss[offset] = (Cpy, item.Item2);
                }
                else if (item.Item2.Length == 2)
                {
                    _instructionss[offset] = (Jnz, item.Item2); ;
                }
            }
            _counter++;
        }

        void Out(ValueOrRegister[] args)
        {

        }

        class ValueOrRegister
        {
            public readonly bool IsRegister;
            public readonly int Value;

            public ValueOrRegister(char reg)
            {
                IsRegister = true;
                Value = reg;
            }
            public ValueOrRegister(int val)
            {
                IsRegister = false;
                Value = val;
            }

            public int GetValue(Dictionary<char, int> registers)
            {
                if (IsRegister)
                {
                    ArgumentNullException.ThrowIfNull(registers);
                    return registers.GetValueOrDefault((char)Value);
                }
                return Value;
            }
        }
    }
}
