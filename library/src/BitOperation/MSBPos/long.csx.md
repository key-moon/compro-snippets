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


# :warning: src/BitOperation/MSBPos/long.csx

<a href="../../../../index.html">Back to top page</a>

* category: <a href="../../../../index.html#ba4980ba298973ff61237fcb5c0cc029">src/BitOperation/MSBPos</a>
* <a href="{{ site.github.repository_url }}/blob/master/src/BitOperation/MSBPos/long.csx">View this file on GitHub</a>
    - Last commit date: 2019-11-20 02:54:11+09:00




## Code

<a id="unbundled"></a>
{% raw %}
```cpp
﻿///Title : Most Significant Bit Position(long)
///Shortcut : msbposl
///Description : 最も上に立っているbitのindex(0-indexed)
///Author : keymoon

using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

#if !DECLARATIONS
/*
//型
@T = long;
*/
using @T = System.Int64;
#endif

[MethodImpl(MethodImplOptions.AggressiveInlining)]
static int MSBPos(@T n)
{
    int res = 0;
    if (0 != (n >> (res | 32))) res |= 32;
    if (0 != (n >> (res | 16))) res |= 16;
    if (0 != (n >> (res | 8))) res |= 8;
    if (0 != (n >> (res | 4))) res |= 4;
    if (0 != (n >> (res | 2))) res |= 2;
    if (0 != (n >> (res | 1))) res |= 1;
    return res;
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

