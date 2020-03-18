#load "../../../src/DataStructure/UnionFind/PotentializedUnionFind.csx"
#pragma PROBLEM https://onlinejudge.u-aizu.ac.jp/courses/library/3/DSL/1/DSL_1_B

using System;
using System.Linq;

var nq = Console.ReadLine().Split().Select(int.Parse).ToArray();
var (n, q) = (nq[0], nq[1]);

PotentializedUnionFind<int> uf = new PotentializedUnionFind<int>(n, (x, y) => x + y, x => -x, 0);

for (int i = 0; i < q; i++)
{
    var query = Console.ReadLine().Split().Select(int.Parse).ToArray();
    if (query[0] == 0)
    {
        var (x, y, z) = (query[1], query[2], query[3]);
        uf.TryUnite(x, y, z);
    }
    else
    {
        var (x, y) = (query[1], query[2]);
        Console.WriteLine(uf.Find(x) == uf.Find(y) ? uf.GetPotential(y, x).ToString() : "?");
    }
}
