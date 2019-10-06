#load "GCD.csx"

///Title : Least Common Multiple
///Shortcut : lcm
///Description : 最小公倍数を見つける
///Author : keymoon

static long LCM(long a, long b) { return a / GCD(a, b) * b; }