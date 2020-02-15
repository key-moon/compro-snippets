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


# :warning: src/DataStructure/WaveletMatrix/Select.csx

<a href="../../../../index.html">Back to top page</a>

* category: <a href="../../../../index.html#3d0ac36297e222061e32f0418ff902b1">src/DataStructure/WaveletMatrix</a>
* <a href="{{ site.github.repository_url }}/blob/master/src/DataStructure/WaveletMatrix/Select.csx">View this file on GitHub</a>
    - Last commit date: 2019-10-09 17:40:05+09:00




## Code

<a id="unbundled"></a>
{% raw %}
```cpp
﻿#load "_global.csx"

///Title : Select
///Shortcut : wmselect
///Description : k番目に登場するkindのindexを返す
///Author : keymoon

using System;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

[MethodImpl(MethodImplOptions.AggressiveInlining)]
public int Select(int k, int kind)
{
    var place = BlockStartIndex[kind] + k;
    for (int i = 0; i < Depth; i++)
    {
        bool param = (kind & (1 << i)) != 0;
        if (param) place = BitVectors[i].Select1(place - ZeroCount[i]);
        else place = BitVectors[i].Select0(place);
    }
    return place;
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

<a href="../../../../index.html">Back to top page</a>

