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

    class Program2
    {
        public static void Main(string[] args)
        {
            int c;
            Console.WriteLine("Enter an integer number of centuries");
            c = Convert.ToInt32(Console.ReadLine());
            String s = String.Format("{0} centuries = {1} years = {2} days = {3} hours = {4} minutes = {5} seconds = {6} milliseconds = " +
                "{7} microseconds = {8} nanoseconds", c, c * 100, c * 100 * 365.24, c * 100 * 365.24 * 24, c * 100 * 365.24 * 24 * 60, c * 100 * 365.24 * 24 * 60 * 60,
                c * 100 * 365.24 * 24 * 60 * 60 * 1000, c * 100 * 365.24 * 24 * 60 * 60 * Math.Pow(10, 6), c * 100 * 365.24 * 24 * 60 * 60 * Math.Pow(10, 9));
            Console.WriteLine(s);
        }

    }

}

