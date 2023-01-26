using System;
using System.Linq;
using System.Collections.Generic;

// HEADER
// title: ReadGraphUnDirected
// shortcut: rgud
// description: 無向グラフの読み込み
// author: keymoon

// DECLARATIONS
// _graph: graph
// _n: n
// _m: m

// BODY
List<int>[] _graph = Enumerable.Repeat(0, _n).Select(_ => new List<int>()).ToArray();
for (int i = 0; i < _m; i++)
{
    var st = Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray();
    _graph[st[0]].Add(st[1]);
    _graph[st[1]].Add(st[0]);
}
