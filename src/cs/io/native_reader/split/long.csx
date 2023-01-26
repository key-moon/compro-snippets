using System;
using System.Linq;

// HEADER
// title: ReadSplitLong
// shortcut: rslong
// description: 単一行複数データの読み込み(long型)
// author: keymoon

// BODY
Console.ReadLine().Split().Select(long.Parse).ToArray()
