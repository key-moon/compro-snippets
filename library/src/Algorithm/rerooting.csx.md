---
layout: default
---

<!-- mathjax config similar to math.stackexchange -->
<script type="text/javascript" async
  src="https://cdnjs.cloudflare.com/ajax/libs/mathjax/2.7.5/MathJax.js?config=TeX-MML-AM_CHTML">
</script>
<script type="text/x-mathjax-config">
  MathJax.Hub.Config({
    TeX: { equationNumbers: { autoNumber: "AMS" }},
    tex2jax: {
      inlineMath: [ ['$','$'] ],
      processEscapes: true
    },
    "HTML-CSS": { matchFontHeight: false },
    displayAlign: "left",
    displayIndent: "2em"
  });
</script>

<script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
<script src="https://cdn.jsdelivr.net/npm/jquery-balloon-js@1.1.2/jquery.balloon.min.js" integrity="sha256-ZEYs9VrgAeNuPvs15E39OsyOJaIkXEEt10fzxJ20+2I=" crossorigin="anonymous"></script>
<script type="text/javascript" src="../../../assets/js/copy-button.js"></script>
<link rel="stylesheet" href="../../../assets/css/copy-button.css" />


# :warning: src/Algorithm/rerooting.csx

<a href="../../../index.html">Back to top page</a>

* category: <a href="../../../index.html#621015de29695bb890bc7e9e3d5f11ad">src/Algorithm</a>
* <a href="{{ site.github.repository_url }}/blob/master/src/Algorithm/rerooting.csx">View this file on GitHub</a>
    - Last commit date: 2020-01-06 02:27:14+09:00




## Code

<a id="unbundled"></a>
{% raw %}
```cpp
﻿///Title : ReRooting
///Shortcut : rerooting
///Description : 全方位木DP
///Author : keymoon

using System;
using System.Collections.Generic;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

class ReRooting<T>
{
    public int NodeCount { get; private set; }

    int[][] Adjacents;
    int[][] IndexForAdjacent;

    T[] Res;
    T[][] DP;

    T Identity;
    Func<T, T, T> Operate;
    Func<T, int, T> OperateNode;

    public ReRooting(int nodeCount, int[][] edges, T identity, Func<T, T, T> operate, Func<T, int, T> operateNode)
    {
        NodeCount = nodeCount;

        Identity = identity;
        Operate = operate;
        OperateNode = operateNode;

        List<int>[] adjacents = new List<int>[nodeCount];
        List<int>[] indexForAdjacents = new List<int>[nodeCount];

        for (int i = 0; i < nodeCount; i++)
        {
            adjacents[i] = new List<int>();
            indexForAdjacents[i] = new List<int>();
        }
        for (int i = 0; i < edges.Length; i++)
        {
            var edge = edges[i];
            indexForAdjacents[edge[0]].Add(adjacents[edge[1]].Count);
            indexForAdjacents[edge[1]].Add(adjacents[edge[0]].Count);
            adjacents[edge[0]].Add(edge[1]);
            adjacents[edge[1]].Add(edge[0]);
        }

        Adjacents = new int[nodeCount][];
        IndexForAdjacent = new int[nodeCount][];
        for (int i = 0; i < nodeCount; i++)
        {
            Adjacents[i] = adjacents[i].ToArray();
            IndexForAdjacent[i] = indexForAdjacents[i].ToArray();
        }

        DP = new T[Adjacents.Length][];
        Res = new T[Adjacents.Length];

        for (int i = 0; i < Adjacents.Length; i++) DP[i] = new T[Adjacents[i].Length];
        if (NodeCount > 1) Initialize();
        else if (NodeCount == 1) Res[0] = OperateNode(Identity, 0);
    }

    public T Query(int node) => Res[node];

    private void Initialize()
    {
        int[] parents = new int[NodeCount];
        int[] order = new int[NodeCount];

        #region InitOrderedTree
        var index = 0;
        Stack<int> stack = new Stack<int>();
        stack.Push(0);
        parents[0] = -1;
        while (stack.Count > 0)
        {
            var node = stack.Pop();
            order[index++] = node;
            for (int i = 0; i < Adjacents[node].Length; i++)
            {
                var adjacent = Adjacents[node][i];
                if (adjacent == parents[node]) continue;
                stack.Push(adjacent);
                parents[adjacent] = node;
            }
        }
        #endregion

        #region fromLeaf
        for (int i = order.Length - 1; i >= 1; i--)
        {
            var node = order[i];
            var parent = parents[node];

            T accum = Identity;
            int parentIndex = -1;
            for (int j = 0; j < Adjacents[node].Length; j++)
            {
                if (Adjacents[node][j] == parent)
                {
                    parentIndex = j;
                    continue;
                }
                accum = Operate(accum, DP[node][j]);
            }
            DP[parent][IndexForAdjacent[node][parentIndex]] = OperateNode(accum, node);
        }
        #endregion

        #region toLeaf
        for (int i = 0; i < order.Length; i++)
        {
            var node = order[i];
            T accum = Identity;
            T[] accumsFromTail = new T[Adjacents[node].Length];
            accumsFromTail[accumsFromTail.Length - 1] = Identity;
            for (int j = accumsFromTail.Length - 1; j >= 1; j--) accumsFromTail[j - 1] = Operate(DP[node][j], accumsFromTail[j]);
            for (int j = 0; j < accumsFromTail.Length; j++)
            {
                DP[Adjacents[node][j]][IndexForAdjacent[node][j]] = OperateNode(Operate(accum, accumsFromTail[j]), node);
                accum = Operate(accum, DP[node][j]);
            }
            Res[node] = OperateNode(accum, node);
        }
        #endregion
    }
}

```
{% endraw %}

<a id="bundled"></a>
{% raw %}
```cpp
Traceback (most recent call last):
  File "/opt/hostedtoolcache/Python/3.8.2/x64/lib/python3.8/site-packages/onlinejudge_verify/docs.py", line 340, in write_contents
    bundled_code = language.bundle(self.file_class.file_path, basedir=pathlib.Path.cwd())
  File "/opt/hostedtoolcache/Python/3.8.2/x64/lib/python3.8/site-packages/onlinejudge_verify/languages/csharpscript.py", line 110, in bundle
    raise NotImplementedError
NotImplementedError

```
{% endraw %}

<a href="../../../index.html">Back to top page</a>

