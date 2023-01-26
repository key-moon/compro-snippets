using System;

// HEADER
// title: Surround
// shortcut: surround
// description: グリッドを囲む
// author: keymoon

// DECLARATIONS
// collection: collection
//       wall: '#'
//      width: w

// BODY
collection.Append(new String(wall, width)).Prepend(new String(wall, width)).Select(x => wall + x + wall).ToArray()
