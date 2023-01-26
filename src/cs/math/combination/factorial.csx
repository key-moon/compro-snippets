#load "../ModInt.csx"

// HEADER
// title: Factorial
// shortcut: factorial
// description: 階乗
// author: keymoon

// BODY
const int MAX = 10000;
static ModInt[] FactorialMemo = new ModInt[MAX + 1];
static ModInt[] InvFactorialMemo = new ModInt[MAX + 1];
static P()
{
    FactorialMemo[0] = 1;
    for (int i = 1; i <= MAX; i++) FactorialMemo[i] = FactorialMemo[i - 1] * i;
    InvFactorialMemo[MAX] = 1 / FactorialMemo[MAX];
    for (int i = MAX - 1; i >= 0; i--) InvFactorialMemo[i] = InvFactorialMemo[i + 1] * (i + 1);
}
static ModInt Factorial(int x) => FactorialMemo[x];
static ModInt InvFactorial(int x) => InvFactorialMemo[x];
