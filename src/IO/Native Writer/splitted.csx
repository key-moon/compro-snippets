///Title : WriteLine(Splitted)
///Shortcut : cws
///Description : 空白区切りで出力
///Author : keymoon

using System;

#if !DECLARATIONS
//コレクション
int[] collection;
//区切り文字
string separator = " ";
#endif

Console.WriteLine(string.Join(separator, collection));