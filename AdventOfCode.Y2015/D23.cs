using System.Runtime.CompilerServices;

namespace AdventOfCode.Y2015;

public class D23 : IDay<int>
{
    enum Instruction
    {
        hlf, tpl, inc, jmp, jie, jio
    }

    public int Year => 2015;

    public int Day => 23;

    public string Title => "Opening the Turing Lock";

    public int Part1(ReadOnlySpan<char> span) => Execute(span, 0);

    static int Execute(ReadOnlySpan<char> span, int registerAStartValue)
    {
        List<(Instruction Instruction, char Register, int Value)> instructions = new();
        foreach (var item in span.EnumerateLines())
        {
            var instruction = Enum.Parse<Instruction>(item.Slice(0, 3));
            var register = '\0';
            var value = 0;
            if (instruction is Instruction.hlf or Instruction.tpl or Instruction.inc)
            {
                register = item[4];
                register = item[^1];
            }
            else if (instruction is Instruction.jmp)
            {
                value = int.Parse(item.Slice(4));
            }
            else
            {
                var index = item.LastIndexOf(' ') + 1;
                value = int.Parse(item.Slice(index));
                register = item[4];
            }
            instructions.Add((instruction, register, value));
        }
        int a = registerAStartValue, b = 0;
        for (int pos = 0; pos < instructions.Count;)
        {
            var instruction = instructions[pos];
            ref int register = ref instruction.Register == 'a' ? ref a
                : ref instruction.Register == 'b' ? ref b
                : ref Unsafe.NullRef<int>();
            switch (instruction.Instruction)
            {
                case Instruction.hlf: register /= 2; pos++; break;
                case Instruction.tpl: register *= 3; pos++; break;
                case Instruction.inc: register++; pos++; break;
                case Instruction.jmp: pos += instruction.Value; break;
                case Instruction.jie:
                    pos += (register & 1) == 0 ? instruction.Value : 1;
                    break;
                case Instruction.jio:
                    pos += register == 1 ? instruction.Value : 1;
                    break;
            }
        }
        return b;
    }

    public int Part2(ReadOnlySpan<char> span) => Execute(span, 1);
}
