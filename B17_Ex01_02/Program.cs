////Ex01_Q2
////Lior Rokach & Oz Nasi 15.04.17
////the program print sand clock with hight = 5
////
////    *****
////     ***
////      *
////     ***
////    ***** 

using System;

namespace B17_Ex01_02
{
    public class Program
    {
        public static void Main()
        {
            SandClockHightFive(0);
        }

        public static void SandClockHightFive(int numSpaces)
        {
            string spaces = string.Empty;
            for (int i = 0; i < numSpaces; i++)
            {
                spaces += " ";
            }

            Console.WriteLine(string.Format("{5}{0}\n {5}{1}\n {5} {2}\n{5} {3}\n{5}{4}", "*****", "***", "*", "***", "*****", spaces));
        }
    }
}