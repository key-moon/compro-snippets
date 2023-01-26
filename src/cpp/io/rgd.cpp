// HEADER
// title: rgd
// shortcut: rgd
// description: rgd
// author: keymoon

// DECLARATIONS
// verts: n
// edges: m
// graph: g

// BODY
vector<vector<int>> graph(verts);
for (int i = 0; i < edges; i++) {
  int s, t;
  cin >> s >> t;
  s--; t--;
  graph[s].emplace_back(t);
}
