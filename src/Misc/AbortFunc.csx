///Title : AbortFunc
///Shortcut : abortfun
///Description : messageを出力してプログラムを終了する
///Author : keymoon

using System;

#if !DECLARATIONS
//出力するメッセージ
string message = "No";
#endif

Action abort = () => { Console.WriteLine(message); Environment.Exit(0); };