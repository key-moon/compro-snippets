///<Title>ReadSplitLong</Title>
///<Shortcut>rslong</Shortcut>
///<Description>単一行複数データの読み込み(long型)</Description>
///<Author>keymoon</Author>

using System;
using System.Linq;


Console.ReadLine().Split().Select(long.Parse).ToArray()