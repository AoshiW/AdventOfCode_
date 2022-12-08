using System.Runtime.InteropServices;

namespace Kunc.AdventOfCode.Utils;

public static class CollectionsExtensions
{
    public static Span<T> AsSpan<T>(this List<T> list) => CollectionsMarshal.AsSpan(list);
    public static ReadOnlySpan<T> AsReadOnlySpan<T>(this List<T> list) => CollectionsMarshal.AsSpan(list);

    public static LinkedListNode<T> NextCircleNode<T>(this LinkedListNode<T> item) => item.Next! ?? item!.List!.First!;
}
