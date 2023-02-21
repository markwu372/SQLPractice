using System;
using System.IO;

namespace System {
    //class Program1 {
    //    public static void Main(string[] args) {
    //        Console.WriteLine("The number of bytes sbyte uses is " + sizeof(sbyte) + ", the min value is " +
    //            sbyte.MinValue + ", and the max value is " + sbyte.MaxValue + ".");
    //        Console.WriteLine("The number of bytes byte uses is " + sizeof(byte) + ", the min value is " +
    //            byte.MinValue + ", and the max value is " + byte.MaxValue + ".");
    //        Console.WriteLine("The number of bytes short uses is " + sizeof(short) + ", the min value is " +
    //            short.MinValue + ", and the max value is " + short.MaxValue + ".");
    //        Console.WriteLine("The number of bytes ushort uses is " + sizeof(ushort) + ", the min value is " +
    //            ushort.MinValue + ", and the max value is " + ushort.MaxValue + ".");
    //        Console.WriteLine("The number of bytes int uses is " + sizeof(int) + ", the min value is " +
    //            int.MinValue + ", and the max value is " + int.MaxValue + ".");
    //        Console.WriteLine("The number of bytes uint uses is " + sizeof(uint) + ", the min value is " +
    //            uint.MinValue + ", and the max value is " + uint.MaxValue + ".");
    //        Console.WriteLine("The number of bytes long uses is " + sizeof(long) + ", the min value is " +
    //            long.MinValue + ", and the max value is " + long.MaxValue + ".");
    //        Console.WriteLine("The number of bytes ulong uses is " + sizeof(ulong) + ", the min value is " +
    //            ulong.MinValue + ", and the max value is " + ulong.MaxValue + ".");
    //        Console.WriteLine("The number of bytes float uses is " + sizeof(float) + ", the min value is " +
    //            float.MinValue + ", and the max value is " + float.MaxValue + ".");
    //        Console.WriteLine("The number of bytes double uses is " + sizeof(double) + ", the min value is " +
    //            double.MinValue + ", and the max value is " + double.MaxValue + ".");
    //        Console.WriteLine("The number of bytes decimal uses is " + sizeof(decimal) + ", the min value is " +
    //            decimal.MinValue + ", and the max value is " + decimal.MaxValue + ".");
    //    }

    //}

    //class ConvertCentury
    //{
    //    public static void Main(string[] args)
    //    {
    //        int c;
    //        Console.WriteLine("Enter an integer number of centuries");
    //        c = Convert.ToInt32(Console.ReadLine());
    //        String s = String.Format("{0} centuries = {1} years = {2} days = {3} hours = {4} minutes = {5} seconds = {6} milliseconds = " +
    //            "{7} microseconds = {8} nanoseconds", c, c * 100, c * 100 * 365.24, c * 100 * 365.24 * 24, c * 100 * 365.24 * 24 * 60, c * 100 * 365.24 * 24 * 60 * 60,
    //            c * 100 * 365.24 * 24 * 60 * 60 * 1000, c * 100 * 365.24 * 24 * 60 * 60 * Math.Pow(10, 6), c * 100 * 365.24 * 24 * 60 * 60 * Math.Pow(10, 9));
    //        Console.WriteLine(s);
    //    }

    //}

    //class FizzBuzz
    //{
    //    public static void Main(string[] args)
    //    {
    //        for (byte i = 0; i < 101; i++)
    //        {
    //            if (i % 3 == 0 & i % 5 == 0)
    //            {
    //                Console.WriteLine("FizzBuzz");
    //            }
    //            else if (i % 3 == 0)
    //            {
    //                Console.WriteLine("Fizz");
    //            }
    //            else if (i % 5 == 0)
    //            {
    //                Console.WriteLine("Buzz");
    //            }
    //            else
    //            {
    //                Console.WriteLine(i);
    //            }
    //        }

    //        int max = 500;
    //        for (byte i = 0; i < max; i++)
    //        {
    //            //the max value of byte will be 255 so it will not reach 500
    //            if (i == byte.MaxValue)
    //            {
    //                break;
    //            }
    //            Console.WriteLine(i);
    //        }
    //    }
    //}

    //class PrintAPyramid
    //{
    //    public static void Main(string[] args)
    //    {
    //        Console.WriteLine("Enter an integer number for the pyramid layer: ");
    //        int layer = int.Parse(Console.ReadLine());

    //        for (int i = 0; i < layer+1; i++) {
    //            for (int j = 0; j < layer-i; j++)
    //            {
    //                Console.Write(" ");
    //            }
    //            for (int j = 0; j < i*2-1; j++)
    //            {
    //                Console.Write("*");
    //            }
    //            for (int j = 0; j < layer- i; j++)
    //            {
    //                Console.Write(" ");
    //            }
    //            Console.Write("\n");
    //        }
    //    }
    //}

    //class GuessNumber
    //{
    //    public static void Main(string[] args)
    //    {
    //        int correctNumber = new Random().Next(3) + 1;
    //        Console.WriteLine("Enter your guessed number: ");
    //        int guessedNumber = int.Parse(Console.ReadLine());
    //        if (guessedNumber < 1 | guessedNumber > 3)
    //        {
    //            Console.WriteLine("Your answer is outside of the range of numbers that are valid guesses.");
    //        }
    //        else if (guessedNumber < correctNumber)
    //        {
    //            Console.WriteLine("Your answer is lower than correct answer.");
    //        }
    //        else if (guessedNumber > correctNumber)
    //        {
    //            Console.WriteLine("Your answer is higher than correct answer.");
    //        }
    //        else if (guessedNumber == correctNumber)
    //        {
    //            Console.WriteLine("You got the correct answer.");
    //        }
    //    }
    //}

    class CalculateAge
    {
        public static void Main(string[] args)
        {
            DateTime birthDate;
            DateTime curr = DateTime.Now.Date;
            int by, bm, bd;
            Console.WriteLine("Enter your birth year: ");
            by = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter your birth month: ");
            bm = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter your birth day: ");
            bd = int.Parse(Console.ReadLine());

            birthDate = new DateTime(by, bm, bd, 0, 0, 0).Date;
            int days = (curr - birthDate).Days;
            int daysToNextAnniversary = 10000 - (days % 10000);
            DateTime ann = curr.AddDays(daysToNextAnniversary);
            Console.WriteLine("Your birthday is {0}. And the next anniverssary is {1}", birthDate.ToString("d"), ann.ToString("d"));
        }
    }
}

