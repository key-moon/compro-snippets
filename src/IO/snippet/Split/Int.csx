///Title : ReadSplitInt
///Shortcut : rsint</Shortcut>
///Description : 単一行複数データの読み込み(int型)
///Author : keymoon

using System;
using System.Linq;


Console.ReadLine().Split().Select(int.Parse).ToArray()