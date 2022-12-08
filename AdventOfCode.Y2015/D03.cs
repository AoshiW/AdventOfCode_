using System.Drawing;

namespace AdventOfCode.Y2015;

public class D03 : IDay<int>
{
    public int Year => 2015;

    public int Day => 3;

    public string Title => "Perfectly Spherical Houses in a Vacuum";

    public int Part1(ReadOnlySpan<char> span)
    {
        var houses = new HashSet<Point>();
        Point santa = new();
        foreach (var item in span)
        {
            switch (item)
            {
                case '>': santa.X++; break;
                case '<': santa.X--; break;
                case '^': santa.Y--; break;
                case 'v': santa.Y++; break;
                default: throw new ArgumentException($"Illegal  char, '{item}'.", nameof(span));
            }
            houses.Add(santa);
        }
        return houses.Count;
    }

    public int Part2(ReadOnlySpan<char> span)
    {
        var houses = new HashSet<Point>();
        Point santa = new(), roboSanta = new();
        bool isRoboSanta = false;
        foreach (var item in span)
        {
            ref var p = ref isRoboSanta ? ref santa : ref roboSanta;
            switch (item)
            {
                case '>': p.X++; break;
                case '<': p.X--; break;
                case '^': p.Y--; break;
                case 'v': p.Y++; break;
                default: throw new ArgumentException($"Illegal  char, '{item}'.", nameof(span));
            }
            houses.Add(p);
            isRoboSanta = !isRoboSanta;
        }
        return houses.Count;
    }
}
