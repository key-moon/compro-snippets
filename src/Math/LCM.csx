#load "GCD.csx"

///<Title>Euclidean algorithm</Title>
///<Shortcut>gcd</Shortcut>
///<Description>最大公約数を見つける</Description>
///<Author>keymoon</Author>

static long LCM(long a, long b) { return a / GCD(a, b) * b; }