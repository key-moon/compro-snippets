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
<script type="text/javascript" src="../../../../../assets/js/copy-button.js"></script>
<link rel="stylesheet" href="../../../../../assets/css/copy-button.css" />


# :warning: src/IO/Native Reader/Formatted/UnDirected.csx

<a href="../../../../../index.html">Back to top page</a>

* category: <a href="../../../../../index.html#401077d8d5439a9e266e2d538b758d58">src/IO/Native Reader/Formatted</a>
* <a href="{{ site.github.repository_url }}/blob/master/src/IO/Native Reader/Formatted/UnDirected.csx">View this file on GitHub</a>
    - Last commit date: 1970-01-01 00:00:00




## Code

<a id="unbundled"></a>
{% raw %}
```cpp
﻿///Title : ReadGraphUnDirected
///Shortcut : rgud
///Description : 無向グラフの読み込み
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
    @graph[st[1]].Add(st[0]);
}

```
{% endraw %}

<a id="bundled"></a>
{% raw %}
```cpp
Traceback (most recent call last):
  File "/opt/hostedtoolcache/Python/3.8.1/x64/lib/python3.8/site-packages/onlinejudge_verify/docs.py", line 347, in write_contents
    bundled_code = language.bundle(self.file_class.file_path, basedir=self.cpp_source_path)
  File "/opt/hostedtoolcache/Python/3.8.1/x64/lib/python3.8/site-packages/onlinejudge_verify/languages/csharpscript.py", line 108, in bundle
    raise NotImplementedError
NotImplementedError

```
{% endraw %}

<a href="../../../../../index.html">Back to top page</a>
