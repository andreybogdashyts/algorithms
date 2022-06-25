var result = Result.decodeString("mnes__ya_____mi");


Console.ReadLine();

class Result
{
    public static string decodeString(string encodedString)
    {
        string s = "";
        for (int i = 0; i < encodedString.Length / 3; i++)
        {
            s += encodedString[i] == '_' ? ' ' : encodedString[i];
            for (int j = i + 6; j < encodedString.Length; j+=6)
            {
                s += encodedString[j] == '_' ? ' ' : encodedString[j];
            }
        }
        return s;
    }
}