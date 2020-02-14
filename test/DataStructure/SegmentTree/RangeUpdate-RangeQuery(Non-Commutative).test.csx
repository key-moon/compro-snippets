#load "../../../src/DataStructure/SegmentTree/RangeUpdate-RangeQuery(Non-Commutative).csx"
#pragma PROBLEM https://onlinejudge.u-aizu.ac.jp/courses/library/3/DSL/all/DSL_2_F

using System;
using System.Linq;

var nq = Console.ReadLine().Split().Select(int.Parse).ToArray();
var (n, q) = (nq[0], nq[1]);
Func<int, int, int> Assign = (x, y) => y == int.MaxValue ? x : y;
SegmentTree<int, int> segTree = new SegmentTree<int, int>(n, int.MaxValue, int.MaxValue, Math.Min, Assign, Assign);
for (int i = 0; i < q; i++)
{
    var query = Console.ReadLine().Split().Select(int.Parse).ToArray();
    if (query[0] == 0)
        segTree.Update(query[1], query[2], query[3]);
    else
        Console.WriteLine(segTree.Query(query[1], query[2]));
}
