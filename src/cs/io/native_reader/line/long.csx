using System;
using System.Linq;

// HEADER
// title: ReadLineLong
// shortcut: rllong
// description: 複数行単一データの読み込み(long型)
// author: keymoon

// DECLARATIONS
// _n: n

// BODY
Enumerable.Repeat(0, _n).Select(_ => long.Parse(Console.ReadLine())).ToArray()
