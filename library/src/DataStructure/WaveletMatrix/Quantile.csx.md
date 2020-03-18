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


# :warning: src/DataStructure/WaveletMatrix/Quantile.csx

<a href="../../../../index.html">Back to top page</a>

* category: <a href="../../../../index.html#3d0ac36297e222061e32f0418ff902b1">src/DataStructure/WaveletMatrix</a>
* <a href="{{ site.github.repository_url }}/blob/master/src/DataStructure/WaveletMatrix/Quantile.csx">View this file on GitHub</a>
    - Last commit date: 2019-10-09 17:40:05+09:00




## Code

<a id="unbundled"></a>
{% raw %}
```cpp
﻿#load "_global.csx"

///Title : Quantile
///Shortcut : wmquantile
///Description : [start, end)のうちk番目に大きい数を返す
///Author : keymoon

using System;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

[MethodImpl(MethodImplOptions.AggressiveInlining)]
public int Quantile(int start, int end, int k)
{
    int res = 0;
    for (int i = Depth - 1; i >= 0; i--)
    {
        var startRank = BitVectors[i].Rank(start);
        var endRank = BitVectors[i].Rank(end);
        var oneCount = endRank - startRank;
        if (oneCount <= k)
        {
            k -= oneCount;
            start -= startRank;
            end -= endRank;
        }
        else
        {
            res |= 1 << i;
            start = ZeroCount[i] + startRank;
            end = ZeroCount[i] + endRank;
        }
    }
    return res;
}
```
{% endraw %}

<a id="bundled"></a>
{% raw %}
```cpp
Traceback (most recent call last):
  File "/opt/hostedtoolcache/Python/3.8.2/x64/lib/python3.8/site-packages/onlinejudge_verify/docs.py", line 340, in write_contents
    bundled_code = language.bundle(self.file_class.file_path, basedir=pathlib.Path.cwd())
  File "/opt/hostedtoolcache/Python/3.8.2/x64/lib/python3.8/site-packages/onlinejudge_verify/languages/csharpscript.py", line 108, in bundle
    raise NotImplementedError
NotImplementedError

```
{% endraw %}

<a href="../../../../index.html">Back to top page</a>

