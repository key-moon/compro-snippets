#load "../ModInt.csx"
#load "Factorial.csx"

// HEADER
// title: Combination
// shortcut: combination
// description: nCr
// author: keymoon

// BODY
static ModInt Combination(int n, int m) => Factorial(n) * InvFactorial(m) * InvFactorial(n - m);
