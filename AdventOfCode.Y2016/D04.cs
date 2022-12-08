using System.Runtime.InteropServices;
using System.Text;

namespace AdventOfCode.Y2016;

public class D04 : IDay<int>
{
    public int Year => 2016;

    public int Day => 4;

    public string Title => "Security Through Obscurity";

    public int Part1(ReadOnlySpan<char> span)
    {
        int sum = 0, value = 0;
        var dic = new Dictionary<char, int>();
        foreach (var line in span.EnumerateLines())
        {
            dic.Clear();
            bool isChecksum = false;
            foreach (var item in line.EnumerateSlices("-[]"))
            {
                if (isChecksum)
                {
                    var top5 = dic.OrderByDescending(x => x.Value).ThenBy(x => x.Key).Take(5).Select(x => x.Key).ToList();
                    if (item.All(top5.Contains))
                        sum += value;
                }
                else if (int.TryParse(item, out value))
                {
                    isChecksum = true;
                }
                else
                {
                    foreach (var proc in item)
                    {
                        ref var refValue = ref CollectionsMarshal.GetValueRefOrAddDefault(dic, proc, out _);
                        refValue++;
                    }
                }
            }
        }
        return sum;
    }

    public int Part2(ReadOnlySpan<char> span)
    {
        var sb = new StringBuilder();
        foreach (var item in span.EnumerateLines())
        {
            int last = item.LastIndexOf('-');
            int id = int.Parse(item.Slice(last + 1, item.IndexOf('[') - last - 1));
            var sid = id % 26;
            sb.Clear();
            for (int i = 0; i < last; i++)
            {
                sb.Append(item[i] == '-' ? ' ' : (char)((item[i] + sid - 'a') % 26 + 'a'));
            }
            if (sb.Equals("northpole object storage"))
                return id;
        }
        return -1;
    }
}
