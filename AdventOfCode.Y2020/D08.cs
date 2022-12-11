using System.Collections;

namespace AdventOfCode.Y2020;

public class D08 : IDay<int>
{
    public int Year => 2020;

    public int Day => 8;

    public string Title => "Handheld Halting";

    public int Part1(ReadOnlySpan<char> span)
    {
        var instructions = ParseInput(span);
        if (!TryExecuteInstructions(instructions, out var value))
            return value;
        throw new ArgumentException(null, nameof(span));
    }

    static (string Operation, int Argument) ParseLine(ReadOnlySpan<char> span)
    {
        var i = span.IndexOf(' ');
        var operation = span.Slice(0, i).ToString();
        var argument = int.Parse(span.Slice(i + 1));
        return (operation, argument);
    }

    static List<(string Operation, int Argument)> ParseInput(ReadOnlySpan<char> span)
    {
        var list = new List<(string, int)>();
        foreach (var item in span.EnumerateLines())
        {
            list.Add(ParseLine(item));
        }
        return list;
    }

    public int Part2(ReadOnlySpan<char> span)
    {
        var instructions = ParseInput(span);
        for (int i = 0; i < instructions.Count; i++)
        {
            if (instructions[i].Operation == "acc")
                continue;
            var original = instructions[i];
            instructions[i] = instructions[i].Operation == "nop" ? ("jmp", instructions[i].Argument) : ("nop", instructions[i].Argument);
            if (TryExecuteInstructions(instructions, out var value))
                return value;
            instructions[i] = original;
        }
        throw new ArgumentException(null, nameof(span));
    }

    static bool TryExecuteInstructions(List<(string Operation, int Argument)> instructions, out int value)
    {
        value = 0;
        var exe = new BitArray(instructions.Count);
        for (int i = 0; i < instructions.Count;)
        {
            if (exe[i])
            {
                return false;
            }
            exe[i] = true;
            switch (instructions[i].Operation)
            {
                case "acc":
                    value += instructions[i].Argument;
                    i += 1;
                    break;
                case "jmp":
                    i += instructions[i].Argument;
                    break;
                case "nop":
                    i += 1;
                    break;
            }
        }
        return true;
    }
}
