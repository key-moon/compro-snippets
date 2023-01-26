// HEADER
// title: cws
// shortcut: cws
// description: cws
// author: keymoon

// DECLARATIONS
//   seq: seq
// split: ' '

// BODY
bool output_fstelem = true;
for (var&& elem : seq) {
  if (output_fstelem) output_fstelem = false;
  else cout << split;
  cout << elem;
}
cout << newl;
