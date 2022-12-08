namespace AdventOfCode.Y2022;

public class D02 : IDay<int>
{
    public int Year => 2022;

    public int Day => 2;

    public string Title => "Rock Paper Scissors";

    static int[,] Map1 = new int[,]
    {  
        //Rock Pape Scis
        // X,   Y,   Z
        { 1+3, 2+6, 3+0 }, //A - Rock
        { 1+0, 2+3, 3+6 }, //B - Paper
        { 1+6, 2+0, 3+3 }, //C - Scissors
    };

    public int Part1(ReadOnlySpan<char> span) => TotalScore(span, Map1);

    static readonly int[,] Map2 = new int[,]
    {  
        //Loss Draw  Win
        // X,   Y,   Z
        { 3+0, 1+3, 2+6 }, //A - Rock
        { 1+0, 2+3, 3+6 }, //B - Paper
        { 2+0, 3+3, 1+6 }, //C - Scissors
    };

    public int Part2(ReadOnlySpan<char> span) => TotalScore(span, Map2);

    static int TotalScore(ReadOnlySpan<char> span, int[,] map)
    {
        var point = 0;
        foreach (var item in span.EnumerateLines())
        {
            point += map[item[0] - 'A', item[2] - 'X'];
        }
        return point;
    }
}
