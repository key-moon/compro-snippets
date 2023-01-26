#load "GCD.csx"

// HEADER
// title: Least Common Multiple
// shortcut: lcm
// description: 最小公倍数を見つける
// author: keymoon

// BODY
static long LCM(long a, long b) { return a / GCD(a, b) * b; }
