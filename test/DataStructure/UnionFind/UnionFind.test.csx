#load "../../../src/DataStructure/UnionFind/UnionFind.csx"
#pragma PROBLEM https://onlinejudge.u-aizu.ac.jp/courses/library/3/DSL/1/DSL_1_A

using System;
using System.Linq;

var nq = Console.ReadLine().Split().Select(int.Parse).ToArray();
var (n, q) = (nq[0], nq[1]);

UnionFind uf = new UnionFind(n);

for (int i = 0; i < q; i++)
{
    var cxy = Console.ReadLine().Split().Select(int.Parse).ToArray();
    var (type, x, y) = (cxy[0], cxy[1], cxy[2]);
    if (type == 0)
        uf.TryUnite(x, y);
    else
        Console.WriteLine(uf.Find(x) == uf.Find(y) ? 1 : 0);
}
