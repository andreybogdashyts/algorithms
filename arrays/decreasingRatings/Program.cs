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

    public static long countDecreasingRatings(List<int> ratings)
    {
        long result = ratings.Count;
        result += count(ratings.ToArray());
        return result;
    }

    public static long count(int[] ratings)
    {
        long counter = 0;
        for (var i = 0; i < ratings.Length - 1; i++)
        {
            if (ratings[i] == ratings[i + 1] + 1)
            {
                counter++;
            }
            else
            {
                counter += count(ratings.Skip(i + 1).ToArray());
            }
        }
        return counter;
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
