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

    /*
     * Complete the 'oddNumbers' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts following parameters:
     *  1. INTEGER l
     *  2. INTEGER r
     */

    public static List<int> oddNumbers(int l, int r)
    {
        var result = new List<int>();
        for (var i = l; i <= r; i++)
        {
            if (l % 2 != 0)
            {
                result.Add(i);
            }
        }
        return result;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter("output.txt", true);

        int l = Convert.ToInt32(Console.ReadLine().Trim());

        int r = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> result = Result.oddNumbers(l, r);

        textWriter.WriteLine(String.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
