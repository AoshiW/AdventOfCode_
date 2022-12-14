using System.Drawing;

namespace AdventOfCode.Y2017;

public class D11 : IDay<int>
{
    public int Year => 2017;

    public int Day => 11;

    public string Title => "Hex ed";

    public int Part1(ReadOnlySpan<char> span)
    {
        var point = new PointF();
        foreach (var item in span.EnumerateSlices(","))
        {
            if (item.Length == 1)
            {
                if (item[0] == 'n')
                    point.Y++;
                else
                    point.Y--;
            }
            else
            {
                if (item[0] == 'n')
                    point.Y += 0.5f;
                else
                    point.Y -= 0.5f;
                if (item[1] == 'w')
                    point.X--;
                else
                    point.X++;
            }
        }
        return StepsFromZero(point);
    }

    static int StepsFromZero(PointF point)
    {
        var steps = 0;
        //var n = new SizeF(0, 1);
        //var s = new SizeF(0, -1);
        var nw = new SizeF(-1, 0.5f);
        var ne = new SizeF(1, 0.5f);
        var sw = new SizeF(-1, -0.5f);
        var se = new SizeF(-1, 0.5f);
        while (point.X != 0)
        {
            if (point.X > 0)
            {
                point += point.Y > 0 ? sw : se;
            }
            else
            {
                point += point.Y > 0 ? nw : ne;
            }
            steps++;
        }
        return steps + Math.Abs((int)point.Y);
    }
 
    public int Part2(ReadOnlySpan<char> span)
    {
        throw new NotImplementedException();
        //var hashset = new HashSet<PointF>();
        //var point = new PointF();
        //foreach (var item in span.EnumerateSlices(","))
        //{
        //    if (item.Length == 1)
        //    {
        //        if (item[0] == 'n')
        //            point.Y++;
        //        else
        //            point.Y--;
        //    }
        //    else
        //    {
        //        if (item[0] == 'n')
        //            point.Y += 0.5f;
        //        else
        //            point.Y -= 0.5f;
        //        if (item[1] == 'w')
        //            point.X--;
        //        else
        //            point.X++;
        //    }
        //    hashset.Add(new(Math.Abs(point.X), Math.Abs(point.Y)));
        //}
        //return hashset.Max(StepsFromZero);
    }
}
