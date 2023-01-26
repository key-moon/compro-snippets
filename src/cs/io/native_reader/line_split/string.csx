using System;
using System.Linq;
// HEADER
// title: ReadLineSplitString
// shortcut: rlsstr
// description: 複数行複数データの読み込み(string型)
// author: keymoon

// DECLARATIONS
// _n: n

// BODY
Enumerable.Repeat(0, _n).Select(_ => Console.ReadLine().Split()).ToArray()
