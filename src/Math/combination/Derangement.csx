#load "../ModInt.csx"
#load "Factorial.csx"

///<Title>Derangement Number</Title>
///<Shortcut>derangement</Shortcut>
///<Description>攪乱順列</Description>
///<Author>keymoon</Author>

static ModInt DerangementNumber(int n)
{
    ModInt res = 0;
    var factorialN = Factorial(n);
    for (int i = 2; i <= n; i++)
    {
        if ((i & 1) == 0) res += factorialN / Factorial(i);
        else res -= factorialN / Factorial(i);
    }
    return res;
}