#load "GCD.csx"

///Title : Euclidean algorithm
///Shortcut : gcd</Shortcut>
///Description : 最大公約数を見つける
///Author : keymoon

static long LCM(long a, long b) { return a / GCD(a, b) * b; }