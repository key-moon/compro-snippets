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


# :warning: src/Math/Divisors.csx

<a href="../../../index.html">Back to top page</a>

* category: <a href="../../../index.html#64f6d80a21cfb0c7e1026d02dde4f7fa">src/Math</a>
* <a href="{{ site.github.repository_url }}/blob/master/src/Math/Divisors.csx">View this file on GitHub</a>
    - Last commit date: 2019-11-12 10:17:04+09:00




## Code

<a id="unbundled"></a>
{% raw %}
```cpp
﻿///Title : Divisors
///Shortcut : divisors
///Description : 約数列挙
///Author : keymoon

using System;
using System.Collections.Generic;
using static System.Math;

static IEnumerable<long> Divisors(long n)
{
    var max = (int)Ceiling(Sqrt(n));
    for (int i = 1; i <= max; i++)
        if (n % i == 0) { yield return i; yield return n / i; }
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

