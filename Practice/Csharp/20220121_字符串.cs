using System;
using System.Text;

namespace CsharpExam
{
    public class _20220121_字符串
    {
        static void Main()
        {
            //Trim
            // string str = "  hello world * ";
            // Console.WriteLine("|" + str.Trim(new[] {' ', '*'})+ "|");        //|hello world|
            // Console.WriteLine("|" + str.TrimStart(new[] {' ', '*'})+ "|");   //|hello world * |
            // Console.WriteLine("|" + str.TrimEnd(new[] {' ', '*'}) + "|");    //|  hello world|

            // string <-> char[]
            // string str = "abcde";
            // char[] cc = str.ToCharArray();
            // str = new string(cc);

            // byte[] <---> string
            // string str = "abcd1";
            // byte[] bb = Encoding.UTF8.GetBytes(str);
            // str = Encoding.UTF8.GetString(bb);

            // StringBuilder <---> string
            // char[] cc = new[] {'a', 'b', 'c'};
            // StringBuilder sb = new StringBuilder();
            // foreach (char c in cc)
            //     sb.Append(c);
            // string str = sb.ToString();


            //Split
            // string str = "hello world*!";
            // string[] spStr = str.Split(new char[] {' ', '*'});

            //IndexOf
            // string str = "123 345 123 34";
            // Console.WriteLine(str.IndexOf("34"));        //4
            // Console.WriteLine(str.LastIndexOf("34"));    //12
            // Console.WriteLine(str.IndexOf("3456"));      //-1

            //Contact
            // string str1 = "abc";
            // string str = string.Concat(str1, "def");

            //EndsWith & StartsWith
            // string str = "11 hello World 2 2";
            // Console.WriteLine(str.StartsWith("11"));      //true
            // Console.WriteLine(str.EndsWith("22"));        //false

            //ToUpper & ToLower
            // string str = "heLLo";
            // Console.WriteLine(str.ToUpper());
            // Console.WriteLine(str.ToLower());

            //Substring
            // string str = "<<<Hello>>>";
            // Console.WriteLine(str.Substring(3, 5));

            //Replace
            // string str = "Hell0 W0rld";
            // Console.WriteLine(str.Replace("0", "o"));

            //Insert
            // string str = "Hello ";
            // Console.WriteLine(str.Insert(6, "world"));
        }
    }
}