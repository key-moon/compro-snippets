using System;
using System.Linq;

// HEADER
// title: ReadLineSplitLong
// shortcut: rlslong
// description: 複数行複数データの読み込み(long型)
// author: keymoon

// DECLARATIONS
// _n: n

// BODY
Enumerable.Repeat(0, _n).Select(_ => Console.ReadLine().Split().Select(long.Parse).ToArray()).ToArray()
