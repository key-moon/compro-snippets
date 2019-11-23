///Title : WriteLine(Yes/No)
///Shortcut : cwyn
///Description : Yes/Noを出力
///Author : keymoon

using System;

#if !DECLARATIONS
//条件
bool cond;
//yes
string @yes = "Yes";
//no
string @no = "No";
#endif

Console.WriteLine(cond ? @yes : @no);