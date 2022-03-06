using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{
    class Node
    {
        public int Data { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
        public int K { get; set; }
    }

    private static Node GenerateTree(List<List<int>> indexes, int v, int depth)
    {
        if (indexes.Count == 0)
        {
            return null;
        }
        var ixxxl = new List<List<int>>();
        var ixxxl = new List<List<int>>();
        var idx = indexes.First();
        if (idx[0] > 0)
        {
            ixxx = indexes.Skip(1).ToList();
        }
        if (idx[0] > 0)
        {
            ixxx = indexes.Skip(1).ToList();
        }
        var idxs2 = indexes.Skip(2).ToList();
        var n = new Node { Data = v, K = depth };
        if (idx[0] > 0)
        {     
            n.Left = GenerateTree(idxs1, idx[0], depth + 1);
        }
        if (idx[1] > 0)
        {
            
            n.Right = GenerateTree(idxs2, idx[1], depth + 1);
        }
        return n;
    }

    /*
     * Complete the 'swapNodes' function below.
     *
     * The function is expected to return a 2D_INTEGER_ARRAY.
     * The function accepts following parameters:
     *  1. 2D_INTEGER_ARRAY indexes
     *  2. INTEGER_ARRAY queries
     */
    public static List<List<int>> swapNodes(List<List<int>> indexes, List<int> queries)
    {
        var result = new List<List<int>>();
        var idxs = indexes.SelectMany(s => s).ToList();
        idxs.Insert(0, 1);
        foreach (var k in queries)
        {
            var tree = GenerateTree(indexes, 1, 1);
            swap(tree, k);
            var l = new List<int>();
            inorder(tree, l);
            result.Add(l);
        }
        return result;
    }

    private static void swap(Node tree, int k)
    {
        if (tree.K == k)
        {
            var t = tree.Left;
            tree.Left = tree.Right;
            tree.Right = t;
        }
        else
        {
            swap(tree.Left, k);
            swap(tree.Right, k);
        }
    }

    private static void inorder(Node node, List<int> l)
    {
        if(node == null)
        {
            return;
        }
        inorder(node.Left, l);
        l.Add(node.Data);
        inorder(node.Right, l);
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter("output.txt", true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<List<int>> indexes = new List<List<int>>();

        for (int i = 0; i < n; i++)
        {
            indexes.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(indexesTemp => Convert.ToInt32(indexesTemp)).ToList());
        }

        int queriesCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> queries = new List<int>();

        for (int i = 0; i < queriesCount; i++)
        {
            int queriesItem = Convert.ToInt32(Console.ReadLine().Trim());
            queries.Add(queriesItem);
        }

        List<List<int>> result = Result.swapNodes(indexes, queries);

        textWriter.WriteLine(String.Join("\n", result.Select(x => String.Join(" ", x))));

        textWriter.Flush();
        textWriter.Close();
    }
}
