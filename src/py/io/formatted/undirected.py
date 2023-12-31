# HEADER
# title: ReadGraphUnDirected
# shortcut: rgud
# description: 無向グラフの読み込み
# author: keymoon

# DECLARATIONS
# _graph: graph
# _n: n
# _m: m

# BODY
_graph = [[] for _ in _n]
for _ in range(_m):
    s, t = [int(x) - 1 for x in input().split()]
    _graph[s].append(t)
    _graph[t].append(s)
