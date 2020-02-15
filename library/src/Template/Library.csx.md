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


# :warning: 

<a href="../../../index.html">Back to top page</a>

* category: <a href="../../../index.html#add21aec1c89793e304f7f7664d07d38">src/Template</a>
* <a href="{{ site.github.repository_url }}/blob/master/src/Template/Library.csx">View this file on GitHub</a>
    - Last commit date: 2019-11-20 02:54:11+09:00




## Code

<a id="unbundled"></a>
{% raw %}
```cpp
﻿///Title : Template for Library
///Shortcut : tmpllib
///Description : ライブラリ用のテンプレート
///Author : keymoon

#if !DECLARATIONS
/*
//スニペット名
@title = title;
//ショートカット
@shortcut = shortcut;
//説明
@description = description;
//作者
@author = keymoon;
*/
#endif

///Title : @title
///Shortcut : @shortcut
///Description : @description
///Author : @author

using System;

#if !DECLARATIONS

#endif

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

<a href="../../../index.html">Back to top page</a>

