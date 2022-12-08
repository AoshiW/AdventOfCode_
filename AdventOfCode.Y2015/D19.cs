using System.Runtime.InteropServices;

namespace AdventOfCode.Y2015;

public class D19 : IDay<int>
{
    public int Year => 2015;

    public int Day => 19;

    public string Title => "Medicine for Rudolph";

    public int Part1(ReadOnlySpan<char> span)
    {
        var input = ParseInput(span);
        var hs = new HashSet<string>();
        foreach (var (Old, New) in input.Item1)
        {
            for (int index = 0; (index = input.Molecule.IndexOf(Old, index)) != -1; index++)
            {
                var newMolecule = string.Create(input.Molecule.Length - Old.Length + New.Length, (input.Molecule, index, Old, New), (s, a) =>
                {
                    a.Molecule.AsSpan(0, index).CopyTo(s);
                    New.CopyTo(s.Slice(index));
                    a.Molecule.AsSpan(index + Old.Length).CopyTo(s.Slice(index + New.Length));
                });
                hs.Add(newMolecule);
            }
        }
        return hs.Count;
    }

    static (List<(string Old, string New)>, string Molecule) ParseInput(ReadOnlySpan<char> span)
    {
        bool b = true;
        var rep = new List<(string old, string ne)>();
        string molecule = default!;
        foreach (var item in span.EnumerateLines())
        {
            if (item.IsEmpty)
            {
                b = false;
                continue;
            }
            if (b)
            {
                var o = item.Slice(0, item.IndexOf(' '));
                var n = item.Slice(item.LastIndexOf(' ') + 1);
                rep.Add((o.ToString(), n.ToString()));
            }
            else
            {
                molecule = item.ToString();
            }
        }
        return (rep, molecule);
    }

    public int Part2(ReadOnlySpan<char> span)
    {
        throw new NotImplementedException();
    }
}
