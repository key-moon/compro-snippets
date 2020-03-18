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


# :warning: src/Math/combination/Derangement.csx

<a href="../../../../index.html">Back to top page</a>

* category: <a href="../../../../index.html#dbb73c94abaa26f5b39c3e5be6b041af">src/Math/combination</a>
* <a href="{{ site.github.repository_url }}/blob/master/src/Math/combination/Derangement.csx">View this file on GitHub</a>
    - Last commit date: 2019-11-09 06:10:56+09:00




## Depends on

* :warning: <a href="Factorial.csx.html">src/Math/combination/Factorial.csx</a>


## Code

<a id="unbundled"></a>
{% raw %}
```cpp
﻿#load "../ModInt.csx"
#load "Factorial.csx"

///Title : Derangement Number
///Shortcut : derangement
///Description : 攪乱順列
///Author : keymoon

static ModInt DerangementNumber(int n)
{
    ModInt res = 0;
    var factorialN = Factorial(n);
    for (int i = 2; i <= n; i++)
    {
        if ((i & 1) == 0) res += factorialN / Factorial(i);
        else res -= factorialN / Factorial(i);
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

