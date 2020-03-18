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


# :heavy_check_mark: test/Math/Primes.test.csx

<a href="../../../index.html">Back to top page</a>

* category: <a href="../../../index.html#0ba367c54975d4d64b0fb7b549b398e6">test/Math</a>
* <a href="{{ site.github.repository_url }}/blob/master/test/Math/Primes.test.csx">View this file on GitHub</a>
    - Last commit date: 2020-03-18 18:25:09+09:00


* see: <a href="https://judge.yosupo.jp/problem/enumerate_primes">https://judge.yosupo.jp/problem/enumerate_primes</a>


## Code

<a id="unbundled"></a>
{% raw %}
```cpp
﻿#load "../../src/Math/Primes.csx"
#pragma PROBLEM https://judge.yosupo.jp/problem/enumerate_primes

using System;
using System.Linq;
using System.Text;

var nab = Console.ReadLine().Split().Select(int.Parse).ToArray();
var (n, a, b) = (nab[0], nab[1], nab[2]);

var next = b;

int count = 0;
int outCount = 0;

StringBuilder builder = new StringBuilder();
foreach (var prime in Primes(n))
{
    if (count == next)
    {
        builder.Append(prime);
        builder.Append(' ');
        outCount++;
        next += a;
    }
    count++;
}

Console.WriteLine($"{count} {outCount}");
Console.WriteLine(builder.ToString());

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

