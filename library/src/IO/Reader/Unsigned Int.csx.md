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


# :warning: src/IO/Reader/Unsigned Int.csx

<a href="../../../../index.html">Back to top page</a>

* category: <a href="../../../../index.html#085db4af1aa8f80c6806e43b548f59da">src/IO/Reader</a>
* <a href="{{ site.github.repository_url }}/blob/master/src/IO/Reader/Unsigned Int.csx">View this file on GitHub</a>
    - Last commit date: 1970-01-01 00:00:00




## Code

<a id="unbundled"></a>
{% raw %}
```cpp
﻿#load "_global.csx"

///Title : Unsigned Integer Reader
///Shortcut : ureader
///Description : 符号なし整数を読み込む
///Author : keymoon

using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

#if !DECLARATIONS
/*
//型
@T = uint;
Name = UInt;
*/
using @T = System.UInt32;
#endif

public static @T NextName
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    get
    {
        @T res = 0; while (Buffer[ptr] < 48) Move();
        do { res = res * 10 + (@T)(Buffer[ptr] ^ 48); Move(); } while (48 <= Buffer[ptr]);
        return res;
    }
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
