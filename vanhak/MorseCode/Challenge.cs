using System;
using System.Collections.Generic;
using System.Linq;

namespace MorseCode
{
    static class Challenge
    {
        public static string[] Possibilities(string signals)
        {
            var t = BuildTree();
            var nodes = new List<CodeNode>();
            foreach (var s in signals)
            {
                switch (s)
                {
                    case '?':
                        if (nodes.Any())
                        {
                            var tn = new List<CodeNode>();
                            foreach (var n in nodes)
                            {
                                tn.Add(n.Left);
                                tn.Add(n.Right);
                            }
                            nodes = tn;
                        }
                        else
                        {
                            nodes.Add(t.Left);
                            nodes.Add(t.Right);
                        }
                        break;
                    case '.':
                        if (nodes.Any())
                        {
                            var tn = new List<CodeNode>();
                            foreach (var n in nodes)
                            {
                                tn.Add(n.Left);
                            }
                            nodes = tn;
                        }
                        else
                        {
                            nodes.Add(t.Left);
                        }
                        break;
                    case '-':
                        if (nodes.Any())
                        {
                            var tn = new List<CodeNode>();
                            foreach (var n in nodes)
                            {
                                tn.Add(n.Right);
                            }
                            nodes = tn;
                        }
                        else
                        {
                            nodes.Add(t.Right);
                        }
                        break;
                }
            }
            return nodes.Select(s => s.Code).ToArray();
        }

        public static CodeNode BuildTree()
        {
            return new CodeNode
            {
                Left = new CodeNode
                {
                    Code = "E",
                    Left = new CodeNode
                    {
                        Code = "I",
                        Left = new CodeNode
                        {
                            Code = "S"
                        },
                        Right = new CodeNode
                        {
                            Code = "U"
                        }
                    },
                    Right = new CodeNode
                    {
                        Code = "A",
                        Left = new CodeNode
                        {
                            Code = "R"
                        },
                        Right = new CodeNode
                        {
                            Code = "W"
                        }
                    }
                },
                Right = new CodeNode
                {
                    Code = "T",
                    Left = new CodeNode
                    {
                        Code = "N",
                        Left = new CodeNode
                        {
                            Code = "D"
                        },
                        Right = new CodeNode
                        {
                            Code = "K"
                        }
                    },
                    Right = new CodeNode
                    {
                        Code = "M",
                        Left = new CodeNode
                        {
                            Code = "G"
                        },
                        Right = new CodeNode
                        {
                            Code = "O"
                        }
                    }
                }
            };
        }

        public class CodeNode
        {
            public string Code { get; set; }
            public CodeNode Left { get; set; }
            public CodeNode Right { get; set; }
        }
    }
}
