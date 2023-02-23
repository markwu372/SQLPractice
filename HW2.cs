using System.Text.RegularExpressions;

namespace System;

public class HW2
{
    static void copyArray()
    {
        int[] arr = new int[10];
        for (int i =0; i<10; i++) {
            arr[i] = i;
        }

        int[] res = new int[arr.Length];
        for (int i =0; i<arr.Length; i++) {
            res[i] = arr[i];
        }
        Console.WriteLine(String.Join(",", arr));
        Console.WriteLine(String.Join(",", res));
    }

    static void updateList()
    {
        Console.WriteLine("Enter command (+ item, - item, or -- to clear)):");
        String command = Console.ReadLine();
        List<String> toDo = new List<string>();
        while (!command.Equals("Q"))
        {
            String start = command.Substring(0, 2);
            String item = command.Substring(2);
            switch (start)
            {
                case "+ ":
                    toDo.Add(item);
                    break;
                case "- ":
                    toDo.Remove(item);
                    break;
                case "--":
                    toDo.Clear();
                    break;
                default:
                    command = "Q";
                    break;
            }
        }
        Console.WriteLine("To Do List is " + toDo);
    }
    
    static int[] FindPrimesInRange(int startNum, int endNum)
    {
        List<int> res = new List<int>();
        for (int i = startNum; i <= endNum; i++)
        {
            bool prime = true;
            for (int j = 2; j < i / 2; j++)
            {
                if (i % j == 0)
                {
                    prime = false;
                    break;
                }
            }
            if (prime & i != 1)
            {
                res.Add(i);
            }
        }
        return res.ToArray();
    }

    static int[] RotateArray(int[] arr, int k)
    {
        int[] res = new int[arr.Length];
        for (int r = 1; r <= k; r++)
        {
            for (int l = 0; l < arr.Length; l++)
            {
                res[(l + r) % arr.Length] += arr[l];
            }
        }
        return res;
    }

    static int[] LongestSequence(int[] arr)
    {
        int count = 1;
        int curr = arr[0];
        int longest = 1;
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] != arr[i - 1])
            {
                count = 0;
            }

            count++;
            if (count > longest)
            {
                longest = count;
                curr = arr[i];
            }
        }
        return Enumerable.Repeat(curr, longest).ToArray();
    }

    static int[] mostFrequent(int[] arr)
    {
        Dictionary<int, int> map = new Dictionary<int, int>();
        foreach (int i in arr)
        {
            if (map.ContainsKey(i))
            {
                map[i]++;
            }
            else
            {
                map.Add(i, 1);
            }
        }

        int max = 0;
        int elem = 0;
        foreach (var (key,val) in map)
        {
            if (val > max)
            {
                max = val;
                elem = key;
            }
        }
        return new []{elem, max};
    }

    static string reverseString1(String str)
    {
        Char[] chars = str.ToCharArray();
        Array.Reverse(chars);
        return String.Join("", chars);
    }
    
    static void reverseString2(String str)
    {
        for (int i = str.Length - 1; i >= 0; i--)
        {
            Console.Write(str[i]);
        }
    }

    static string reversePart(String str)
    {
        char[] charArr = str.ToCharArray();
        List<string> ls = new List<string>();
        string temp = "";
        foreach (char c in charArr)
        {
            if (c != '.' && c!= ' ' && c!= ',' && c != ':' && c != '!' && c != '?' && c != '\"' && c!= '\'' && c != '/' &&
                c != ';' && c!= '=' && c!= '(' && c != ')' && c != '&' && c != '[' && c != ']'  && c != '\\')
            {
                temp += c;
            }
            else if (c == ' ')
            {
                ls.Add(temp);
                temp = "";
            }
            else
            {
                ls.Add(temp);
                ls.Add(c.ToString());
                temp = "";
            }
        }

        List<string> reverseLs = new List<string>(ls);
        reverseLs.Reverse();
        string[] lsStr = ls.ToArray();
        string[] rvStr = reverseLs.ToArray();
        int j = 0;
        for (int i = 0; i < lsStr.Length; i++)
        {
            string s = lsStr[i];
            if (s.Length > 1 || s == "a" || s == "A")
            {
                lsStr[i] = nextString(rvStr, ref j);
            }
        }
        string result = string.Join(" ", lsStr);
        result = Regex.Replace(result, " , ", ",");
        result = Regex.Replace(result, " ! ", "!");
        result = Regex.Replace(result, " / ", "/");
        return result;
    }
    
    static string nextString(string[] s, ref int j)
    {
        for (int i = j + 1; i < s.Length; i++)
        {
            if (s[i].Length > 1 || s[i].Equals("A") || s[i].Equals("a"))
            {
                j = i;
                return s[i];
            }
        }
        j = s.Length;
        return "";
    }

    static string printPalindromes(string str)
    {
        str = Regex.Replace(str, @"[^\w\d\s]", " ");
        str = Regex.Replace(str, "  ", " ");
        string[] res = str.Split(" ");
        List<string> final = new List<string>();

        foreach (var s in res)
        {
            char[] c = s.ToCharArray();
            Array.Reverse(c);
            string r = String.Join("",c);
            if (s.Equals(r))
            {
                final.Add(s);
            }
        }
        final.Sort();
        return String.Join(",", final);

    }
    
    public static void parseURL (string url)
    {
        string protocol = "";
        string server = "";
        string resource = "";
        if (url.Contains("://"))
        {
            string[] twoParts = url.Split("://");
            protocol = twoParts[0];
            if (twoParts[1].Contains("/"))
            {
                twoParts = twoParts[1].Split("/");
                server = twoParts[0];
                resource = twoParts[1];
            }
            else
            {
                server = twoParts[1];
            }
        }
        else
        {
            if (url.Contains("/"))
            {
                string[] twoParts = url.Split("/");
                server = twoParts[0];
                resource = twoParts[1];
            }
            else
            {
                server = url;
            }
        }
        Console.WriteLine("[Protocol] = " + protocol + "");
        Console.WriteLine("[Server] = " + server + "");
        Console.WriteLine("[Resource] = " + resource + "");
    }

    static void Main(String[] args)
    {
        //copyArray();
        //updateList();
        // int[] array2 = {3,2,1,1,2,3,3,2,1};
        // Console.WriteLine(String.Join(",", RotateArray(array2, 3)));
        // Console.WriteLine(string.Join(",", LongestSequence(array2)));
        // int[] array3 = mostFrequent(array2);
        // Console.WriteLine("The number " + array3[0] + " is the most frequent (occur " + array3[1] + " times)");
        //Console.WriteLine(reversePart("The quick brown fox jumps over the lazy dog /Yes! Really!!!/."));
        //Console.WriteLine(printPalindromes("Hi,exe? ABBA! Hog fully a string: ExE. Bob"));
        parseURL("https://www.apple.com/iphone");
    }
}