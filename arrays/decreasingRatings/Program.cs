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
     * Complete the 'countDecreasingRatings' function below.
     *
     * The function is expected to return a LONG_INTEGER.
     * The function accepts INTEGER_ARRAY ratings as parameter.
     */
    /*
4
100
3
2
1
15
      */

    public static long countDecreasingRatings(List<int> ratings)
    {
        long r = 0;

        for (int i = 0; i < ratings.Count; i++)
        {
            var l = ratings[i];
            for (int j = i + 1; j < ratings.Count; j++)
            {
                if (l > ratings[j])
                {
                    r++;
                    l = ratings[j];
                }
                else
                {
                    break;
                }
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

        int ratingsCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> ratings = new List<int>();

        for (int i = 0; i < ratingsCount; i++)
        {
            int ratingsItem = Convert.ToInt32(Console.ReadLine().Trim());
            ratings.Add(ratingsItem);
        }

        long result = Result.countDecreasingRatings(ratings);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
