#load "../ModInt.csx"
#load "Factorial.csx"

// HEADER
// title: Derangement Number
// shortcut: derangement
// description: 攪乱順列
// author: keymoon

// BODY
static ModInt DerangementNumber(int n)
{
    ModInt res = 0;
    var factorialN = Factorial(n);
    for (int i = 2; i <= n; i++)
    {
        if ((i & 1) == 0) res += factorialN * InvFactorial(i);
        else res -= factorialN * InvFactorial(i);
    }
    return res;
}
