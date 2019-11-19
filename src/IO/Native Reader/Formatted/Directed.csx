//////Title : ReadGraphDirected
///Shortcut : rgd
///Description : 有向グラフの読み込み
///Author : keymoon

using System;
using System.Linq;
using System.Collections.Generic;

#if !DECLARATIONS
/*
//変数
@graph;
*/
//頂点数
int @n;
//辺数
int @m;
#endif

List<int>[] @graph = Enumerable.Repeat(0, @n).Select(_ => new List<int>()).ToArray();
for (int i = 0; i < @m; i++)
{
    var st = Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray();
    @graph[st[0]].Add(st[1]);
}
