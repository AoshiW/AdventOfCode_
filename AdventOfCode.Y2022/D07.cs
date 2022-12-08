using System.Runtime.InteropServices;

namespace AdventOfCode.Y2022;

public partial class D07 : IDay<int>
{
    public int Year => 2022;

    public int Day => 7;

    public string Title => "No Space Left On Device";

    public int Part1(ReadOnlySpan<char> span)
    {
        var root = Parse(span);
        return Sum(root);
    }

    static int Sum(Dir dir)
    {
        int totalsum = 0;
        if (dir.TotalSize <= 100_000)
            totalsum += dir.TotalSize;
        foreach (var item in CollectionsMarshal.AsSpan(dir.SubDirs))
        {
            totalsum += Sum(item);
        }
        return totalsum;
    }

    const int TotalDiskSpace = 70_000_000;
    const int RequiredDiskSpace = 30_000_000;

    public int Part2(ReadOnlySpan<char> span)
    {
        var root = Parse(span);
        var need = RequiredDiskSpace + root.TotalSize - TotalDiskSpace;
        var min = root;
        FindDirWithMinSize(root.SubDirs, need, ref min);
        return min.TotalSize;
    }


    static void FindDirWithMinSize(List<Dir> dirs, int minSize, ref Dir currentMin)
    {
        foreach (var item in CollectionsMarshal.AsSpan(dirs))
        {
            if (item.TotalSize < currentMin.TotalSize && item.TotalSize > minSize)
            {
                currentMin = item;
                FindDirWithMinSize(currentMin.SubDirs, minSize, ref currentMin);
            }
        }
    }

    static Dir Parse(ReadOnlySpan<char> span)
    {
        var root = new Dir("/");
        foreach (var item in span.EnumerateLines())
        {
            if (item is "$ ls" or "$ cd /")
            {
                continue;
            }
            else if (item.StartsWith("dir ", StringComparison.OrdinalIgnoreCase))
            {
                var dirName = item.Slice(4).ToString();
                root.SubDirs.Add(new(dirName, root));
            }
            else if (item is "$ cd ..")
            {
                root = root.Parent!;
            }
            else if (item.StartsWith("$ cd ", StringComparison.OrdinalIgnoreCase))
            {
                var dirName = item.Slice(5).ToString();
                foreach (var item2 in CollectionsMarshal.AsSpan(root.SubDirs))
                {
                    if (item2.Name == dirName)
                    {
                        root = item2;
                        break;
                    }
                }
            }
            else
            {
                var index = item.IndexOf(' ');
                var size = int.Parse(item.Slice(0, index));
                root.TotalFileSize += size;
            }
        }
        while (root.Parent is not null)
        {
            root = root.Parent;
        }
        return root;
    }
}
