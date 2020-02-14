#load "../../../src/DataStructure/SegmentTree/RangeUpdate-PointQuery(Non-Commutative).csx"
#pragma PROBLEM https://onlinejudge.u-aizu.ac.jp/courses/library/3/DSL/all/DSL_2_D

using System;
using System.Linq;

var nq = Console.ReadLine().Split().Select(int.Parse).ToArray();
var (n, q) = (nq[0], nq[1]);
SegmentTree<int> segTree = new SegmentTree<int>(n, int.MaxValue, (x, y) => y == int.MaxValue ? x : y);
for (int i = 0; i < q; i++)
{
    var query = Console.ReadLine().Split().Select(int.Parse).ToArray();
    if (query[0] == 0)
        segTree.Operate(query[1], query[2], query[3]);
    else
        Console.WriteLine(segTree[query[1]]);
}
