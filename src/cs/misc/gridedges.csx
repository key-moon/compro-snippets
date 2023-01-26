using System;
using System.Linq;
using System.Collections.Generic;

// HEADER
// title: Grid Graph Edges Generator
// shortcut: gridedges
// description: グリッドグラフの辺を生成する
// author: keymoon

// DECLARATIONS
// graph: 
//    _h: h
//    _w: w

// BODY
List<int>[] graph = Enumerable.Repeat(0, _h * _w).Select(_ => new List<int>()).ToArray();
for (int i = 0; i < _h - 1; i++)
    for (int j = 0; j < w; j++)
    { var id = i * _w + j; graph[id].Add(id + _w); graph[id + _w].Add(id); }
for (int i = 0; i < _h; i++)
    for (int j = 0; j < _w - 1; j++)
    { var id = i * _w + j; graph[id].Add(id + 1); graph[id + 1].Add(id); }
