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
<script type="text/javascript" src="../../../../assets/js/copy-button.js"></script>
<link rel="stylesheet" href="../../../../assets/css/copy-button.css" />


# :heavy_check_mark: test/DataStructure/UnionFind/PotentializedUnionFind.test.csx

<a href="../../../../index.html">Back to top page</a>

* category: <a href="../../../../index.html#33e5eccf684d6653f8b65b9ad5a4655d">test/DataStructure/UnionFind</a>
* <a href="{{ site.github.repository_url }}/blob/master/test/DataStructure/UnionFind/PotentializedUnionFind.test.csx">View this file on GitHub</a>
    - Last commit date: 2020-03-18 21:16:49+09:00


* see: <a href="https://onlinejudge.u-aizu.ac.jp/courses/library/3/DSL/1/DSL_1_B">https://onlinejudge.u-aizu.ac.jp/courses/library/3/DSL/1/DSL_1_B</a>


## Code

<a id="unbundled"></a>
{% raw %}
```cpp
﻿#load "../../../src/DataStructure/UnionFind/PotentializedUnionFind.csx"
#pragma PROBLEM https://onlinejudge.u-aizu.ac.jp/courses/library/3/DSL/1/DSL_1_B

using System;
using System.Linq;

var nq = Console.ReadLine().Split().Select(int.Parse).ToArray();
var (n, q) = (nq[0], nq[1]);

PotentializedUnionFind<int> uf = new PotentializedUnionFind<int>(n, (x, y) => x + y, x => -x, 0);

for (int i = 0; i < q; i++)
{
    var query = Console.ReadLine().Split().Select(int.Parse).ToArray();
    if (query[0] == 0)
    {
        var (x, y, z) = (query[1], query[2], query[3]);
        uf.TryUnite(x, y, z);
    }
    else
    {
        var (x, y) = (query[1], query[2]);
        Console.WriteLine(uf.Find(x) == uf.Find(y) ? uf.GetPotential(y, x).ToString() : "?");
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

<a href="../../../../index.html">Back to top page</a>

