#load "../ModInt.csx"

///<Title>Factorial</Title>
///<Shortcut>factorial</Shortcut>
///<Description>階乗</Description>
///<Author>keymoon</Author>

using System.Linq;
using System.Collections.Generic;

static List<ModInt> factorialMemo = new List<ModInt>() { 1 };
static ModInt Factorial(int x)
{
    for (int i = factorialMemo.Count; i <= x; i++) factorialMemo.Add(factorialMemo.Last() * i);
    return factorialMemo.Last();
}