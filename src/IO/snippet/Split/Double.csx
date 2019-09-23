///Title : ReadSplitDouble
///Shortcut : rsdouble</Shortcut>
///Description : 単一行複数データの読み込み(double型)
///Author : keymoon

using System;
using System.Linq;


Console.ReadLine().Split().Select(double.Parse).ToArray()