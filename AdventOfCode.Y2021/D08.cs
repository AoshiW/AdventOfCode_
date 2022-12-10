namespace AdventOfCode.Y2021;

public class D08 : IDay<int>
{
    public int Year => 2021;

    public int Day => 8;

    public string Title => "Seven Segment Search";

    public int Part1(ReadOnlySpan<char> span)
    {
        int count = 0;
        foreach (var line in span.EnumerateLines())
        {
            foreach (var item in line.EnumerateSlices(" |", 10))
            {
                if (item.Length is 2 or 3 or 4 or 7)
                    count++;
            }
        }
        return count;
    }

    public int Part2(ReadOnlySpan<char> span)
    {
        int sum = 0;
        Span<int> num = stackalloc int[10];
        Span<(int Value, int Length)> arr = stackalloc (int, int)[14];
        foreach (var item in span.EnumerateLines())
        {
            var enumerator = item.EnumerateSlices(" |");
            for (int i = 0; enumerator.MoveNext(); i++)
            {
                arr[i] = (ToNumber(enumerator.Current), enumerator.Current.Length);
            }
            num[1] = arr.Find(x => x.Length == 2).Value;
            num[4] = arr.Find(x => x.Length == 4).Value;
            num[7] = arr.Find(x => x.Length == 3).Value;
            num[8] = arr.Find(x => x.Length == 7).Value;

            int arg = num[1];
            num[3] = arr.Find(x => x.Length == 5 && (x.Value & arg) == arg).Value;
            num[6] = arr.Find(x => x.Length == 6 && (x.Value & arg) != arg).Value;

            arg = num[4];
            num[9] = arr.Find(x => x.Length == 6 && (x.Value & arg) == arg).Value;
            arg = num[9];
            int arg2 = num[6];
            num[0] = arr.Find(x => x.Length == 6 && x.Value != arg && x.Value != arg2).Value;

            arg = num[3];
            arg2 = num[6] & num[1];
            num[5] = arr.Find(x => x.Length == 5 && x.Value != arg && (x.Value & arg2) != 0).Value;
            arg2 = num[5];
            num[2] = arr.Find(x => x.Length == 5 && x.Value != arg && x.Value != arg2).Value;

            int temp = 0;
            foreach (var itemNum in arr.Slice(10))
            {
                temp = temp * 10 + num.IndexOf(itemNum.Value);
            }
            sum += temp;
        }
        return sum;
    }

    static int ToNumber(ReadOnlySpan<char> span)
    {
        int num = 0;
        foreach (var item in span)
        {
            num |= 1 << item switch
            {
                'a' => 1,
                'b' => 2,
                'c' => 3,
                'd' => 4,
                'e' => 5,
                'f' => 6,
                'g' => 7,
                _ => throw new ArgumentException(null, nameof(span))
            };
        }
        return num;
    }
}
