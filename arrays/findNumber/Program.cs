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
     * Complete the 'findNumber' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY arr
     *  2. INTEGER k
     */

    public static string findNumber(List<int> arr, int k)
    {
        var r = "NO";
        foreach (var i in arr)
        {
            if(i == k)
            {
                r = "YES";
                break;
            }
        }
        return r;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter("output.txt", true);

        int arrCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = new List<int>();

        for (int i = 0; i < arrCount; i++)
        {
            int arrItem = Convert.ToInt32(Console.ReadLine().Trim());
            arr.Add(arrItem);
        }

        int k = Convert.ToInt32(Console.ReadLine().Trim());

        string result = Result.findNumber(arr, k);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
