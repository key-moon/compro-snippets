///<Title>ReadSplitInt</Title>
///<Shortcut>rsint</Shortcut>
///<Description>単一行複数データの読み込み(int型)</Description>
///<Author>keymoon</Author>

using System;
using System.Linq;


Console.ReadLine().Split().Select(int.Parse).ToArray()