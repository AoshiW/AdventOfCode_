namespace AdventOfCode.Y2017;

public partial class D12
{
    class Program
    {
        public int Id;
        public List<int> Pipes;
        public override string ToString() => $"{Id} <-> {string.Join(", ", Pipes)}";
    }
}
