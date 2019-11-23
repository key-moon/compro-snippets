///Title : Grid Graph Edges Generator
///Shortcut : gridedges
///Description : グリッドグラフの辺を生成する
///Author : keymoon

using System;
using System.Linq;
using System.Collections.Generic;

#if !DECLARATIONS
/*
//変数
@graph;
*/
//高さ
int @h;
//横幅
int @w;
#endif

List<int>[] @graph = Enumerable.Repeat(0, @h * @w).Select(_ => new List<int>()).ToArray();
for (int i = 0; i < @h - 1; i++)
    for (int j = 0; j < @w; j++)
    { var id = i * @w + j; graph[id].Add(id + @w); graph[id + @w].Add(id); }
for (int i = 0; i < @h; i++)
    for (int j = 0; j < @w - 1; j++)
    { var id = i * @w + j; graph[id].Add(id + 1); graph[id + 1].Add(id); }