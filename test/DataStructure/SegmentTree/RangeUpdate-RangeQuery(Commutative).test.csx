#load "../../../src/DataStructure/SegmentTree/RangeUpdate-RangeQuery(Commutative).csx"
#pragma PROBLEM https://onlinejudge.u-aizu.ac.jp/courses/library/3/DSL/all/DSL_2_H

using System;
using System.Linq;

var nq = Console.ReadLine().Split().Select(int.Parse).ToArray();
var (n, q) = (nq[0], nq[1]);
SegmentTree<long, long> segTree = new SegmentTree<long, long>(new long[n], int.MaxValue / 2, 0, Math.Min, (x, y) => x + y, (x, y) => x + y);
for (int i = 0; i < q; i++)
{
    var query = Console.ReadLine().Split().Select(int.Parse).ToArray();
    if (query[0] == 0)
        segTree.Update(query[1], query[2], query[3]);
    else
        Console.WriteLine(segTree.Query(query[1], query[2]));
}
