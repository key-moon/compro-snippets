using System;

// HEADER
// title: AbortFunc
// shortcut: abortfun
// description: messageを出力してプログラムを終了する
// author: keymoon

// DECLARATIONS
// message: "No"

// BODY
Action abort = () => { Console.WriteLine(message); Environment.Exit(0); };
