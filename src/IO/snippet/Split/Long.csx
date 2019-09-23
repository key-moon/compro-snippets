///Title : ReadSplitLong
///Shortcut : rslong</Shortcut>
///Description : 単一行複数データの読み込み(long型)
///Author : keymoon

using System;
using System.Linq;


Console.ReadLine().Split().Select(long.Parse).ToArray()