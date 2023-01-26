using System;
using System.Collections.Generic;
using System.Linq;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

// HEADER
// title: PartialPersistentUnionFind
// shortcut: ppuf
// description: 部分永続Union-Find
// author: keymoon

// BODY
class PartialPersistentUnionFind
{
    const int MAX = 1 << 30;
    public readonly int Size;
    public int Now { get; private set; }
    public IEnumerable<int> AllRepresents => Parents.Where((x, y) => x == y);
    int[] Parents;
    int[] Time;
    int[] Sizes;
    List<int>[] SizeHistories;
    List<int>[] TimeStamps;

    public PartialPersistentUnionFind(int size)
    {
        Size = size;
        Parents = new int[size];
        Time = new int[size];
        Sizes = new int[size];
        SizeHistories = new List<int>[size];
        TimeStamps = new List<int>[size];
        for (int i = 0; i < Size; i++)
        {
            Time[i] = MAX;
            Sizes[i] = 1;
            SizeHistories[i] = new List<int>() { 1 };
            TimeStamps[i] = new List<int>() { 0 };
        }
    }

    public bool TryUnite(int x, int y)
    {
        Now++;
        x = Find(x);
        y = Find(y);
        if (x == y) return false;
        if (Sizes[x] < Sizes[y]) { var tmp = x; x = y; y = tmp; }
        Time[y] = Now;
        Parents[y] = x;
        Sizes[x] += Sizes[y];
        TimeStamps[x].Add(Now << 1);
        SizeHistories[x].Add(Sizes[x]);
        return true;
    }
    public int Find(int i, int t = MAX)
    {
        while (Time[i] <= t) i = Parents[i];
        return i;
    }
    public int GetSize(int i, int t = MAX)
    {
        var root = Find(i, t);
        return SizeHistories[root][~TimeStamps[root].BinarySearch(t << 1 | 1) - 1];
    }
}
