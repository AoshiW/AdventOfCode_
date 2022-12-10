namespace AdventOfCode.Y2021;

public partial class D11
{
    class MapItem
    {
        public MapItem(char cc) => CharNum = cc;
        public bool Flashed;
        public char CharNum;
    }
}
