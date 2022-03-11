Morse Code
Overview

Morse Code is delivered in a series signals which are referred to as dashes (-) or dots (.). To keep things simple for the purposes of this challenge we'll only decode letters with a maximum length of three signals.

Morse Code Graph showing a perfect binary tree rooted at a node labeled Start, with two subtrees: the left subtree is labeled Dot and the right subtree is labeled Dash. In the Dot subtree, the nodes are labeled as follows: E is the left child of the Start node. E has left child I and right child A, I has left child S and right child U, A has left child R and right child W. In the Dash subtree, the nodes are labeled as follows: T is the right child of the Start node, T has left child N and right child M, N has left child D and right child K, M has left child G and right child O

http://res.cloudinary.com/strive/image/upload/w_840/f00795e8b5d5d2d0b71863f38126c9b1.png

Here is the Morse Code dichotomic search table courtesy of Wikipedia
Morse Code Examples

-.- translates to K
... translates to S
.- translates to A
-- translates to M
. translates to E
Background

You've started work as morse code translator. Unfortunately some of the signals aren't as distinguishable as others and there are times where a . seems indistinguishable from -. In these cases you write down a ? so that you can figure out what all the posibilities of that letter for that word are later.
Task

Write a function possibilities that will take a string signals and return an array of possible characters that the Morse code signals could represent.
Specification
Challenge.Possibilities(signals)

Parameters

    signals: string - The Morse code signals that needs to be parsed. The may contain one or more unknown signals (?).
Return Value

    List<string> - The list of possible letters for the given group of signals. Letters will always be ordered from how they appear on the chart, from left to right.
Constraints

    There will be no more than 3 characters within signals.

    0 - 3 unknown signals may be given.

Examples
signals 	Return Value
"." 	["E"]
"-" 	["T"]
"-." 	["N"]
"..." 	["S"]
"..-" 	["U"]
"?" 	["E","T"]
".?" 	["I","A"]
"?-?" 	["R","W","G","O"]