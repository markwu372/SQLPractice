namespace System;

public class HW3
{
    static void Main(string[] args) {
        
        // int[] numbers = GenerateNumbers();
        // Reverse(numbers);
        // PrintNumbers(numbers);
        for (int i = 1; i < 11; i++)
        {
            Console.WriteLine(Fibonacci(i));
        }
    }

    static int[] GenerateNumbers()
    {
        Console.WriteLine("Enter a number for array's length: ");
        int n = Convert.ToInt32(Console.ReadLine());
        int[] num = new int[n];
        for (int i = 0; i < n; i++)
        {
            num[i] = i + 1;
        }
        return num;
    }
    
    static void Reverse(int[] numbers)
    {
        Array.Reverse(numbers);
    }
    
    static void PrintNumbers(int[] numbers)
    {
        string s = String.Join(",", numbers);
        Console.WriteLine(s);
    }

    static int Fibonacci(int idx)
    {
        if (idx == 1 | idx == 2)
        {
            return 1;
        }
        else
        {
            return Fibonacci(idx - 1) + Fibonacci(idx - 2);
        }
    }
}
