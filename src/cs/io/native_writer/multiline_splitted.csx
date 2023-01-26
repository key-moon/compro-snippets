using System;
using System.Linq;

// HEADER
// title: WriteLine(Multi Line/Splitted)
// shortcut: cwls
// description: 空白区切りで複数行に出力
// author: keymoon

// DECLARATIONS
// _collection: collection

// BODY
Console.WriteLine(string.Join("\n", _collection.Select(x => string.Join(" ", x))));
