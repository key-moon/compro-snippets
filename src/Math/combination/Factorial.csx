#load "../ModInt.csx"

///Title : Factorial
///Shortcut : factorial
///Description : 階乗
///Author : keymoon

using System.Linq;
using System.Collections.Generic;

static List<ModInt> factorialMemo = new List<ModInt>() { 1 };
static ModInt Factorial(int x)
{
    for (int i = factorialMemo.Count; i <= x; i++) factorialMemo.Add(factorialMemo.Last() * i);
    return factorialMemo.Last();
}