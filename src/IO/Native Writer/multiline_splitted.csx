///Title : WriteLine(Multi Line/Splitted)
///Shortcut : cwls
///Description : 空白区切りで複数行に出力
///Author : keymoon

using System;
using System.Linq;

#if !DECLARATIONS
//コレクション
int[] collection;
#endif

Console.WriteLine(string.Join("\n", collection.Select(x => string.Join(" ", x))));