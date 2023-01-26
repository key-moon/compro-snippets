using System;
using System.Linq;

// HEADER
// title: ReadLineInt
// shortcut: rlint
// description: 複数行単一データの読み込み(int型)
// author: keymoon

// DECLARATIONS
// _n: n

// BODY
Enumerable.Repeat(0, _n).Select(_ => int.Parse(Console.ReadLine())).ToArray()
