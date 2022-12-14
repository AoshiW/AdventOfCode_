namespace AdventOfCode.Y2017;

public class D10 : IDay<int>
{
    public int Year => 2017;

    public int Day => 10;

    public string Title => "Knot Hash";

    public int Part1(ReadOnlySpan<char> span)
    {
        Span<int> data = stackalloc int[256];
        Span<int> buffer = stackalloc int[256];
        int skip = 0;
        var rotate = 0;
        for (int i = 1; i < data.Length; i++)
        {
            data[i] = i;
        }
        int index = 0;
        foreach (var item in span.EnumerateSlices(","))
        {
            var value = int.Parse(item);
            if (value + index >= data.Length)
            {
                rotate += index;
                data.RotateLeft(index, buffer);
                index = 0;
            }
            data.Slice(index, value).Reverse();
            index += value + skip++;
            index %= data.Length;
        }
        rotate %= data.Length;
        data.RotateRight(rotate, buffer);
        return data[0] * data[1];
    }

    public int Part2(ReadOnlySpan<char> span)
    {
        span = "1,2,3";
        Span<int> data = stackalloc int[span.Length + 5];
        for (int i = 0; i < span.Length; i++)
        {
            data[i] = span[i];
        }
        data[^5] = 17;
        data[^4] = 31;
        data[^3] = 73;
        data[^2] = 47;
        data[^1] = 23;
        for (int i = 0; i < 64; i++)
        {

        }
        throw new NotImplementedException();
    }
}
