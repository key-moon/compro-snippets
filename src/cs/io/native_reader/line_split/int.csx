using System;
using System.Linq;

// HEADER
// title: ReadLineSplitInt
// shortcut: rlsint
// description: 複数行複数データの読み込み(int型)
// author: keymoon

// DECLARATIONS
// _n: n

// BODY
Enumerable.Repeat(0, _n).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).ToArray()
