////Ex01_Q3
////Lior Rokach & Oz Nasi 15.04.17
////This program get from user hight and acordingly print sand clock.
////for example - hight = 5
////
////    *****
////     ***
////      *
////     ***
////    ***** 
////
//// in addition this program use a refernce the previous question - Q2 that print a sand clock with hight =5.

using System;
using System.Collections.Generic;
using System.Text;
using B17_Ex01_02;

namespace B17_Ex01_03
{
    public class Program
    {
        public static void Main()
        {
            AdvancedSandClock();
        }

        public static void AdvancedSandClock()
        {
            Console.WriteLine("Please enter the hight of the sand clock ! \n");
            string hightString = Console.ReadLine();
            int numOfLoop;
            bool isInputValid = ValidateInput(hightString);
            if (isInputValid)
            {
                int hight = int.Parse(hightString);
                StringBuilder starString = new StringBuilder(hight);
                if (hight % 2 == 0)
                {
                    hight = hight - 1;
                }

                InitiateStarString(hight, ref starString);
                numOfLoop = (hight - 5) / 2;

                if (hight == 5)
                {
                    B17_Ex01_02.Program.SandClockHightFive(numOfLoop);
                }
                else if (hight >= 7)
                {
                    PrintBegeiningOfSandClock(numOfLoop, hight, ref starString);
                    B17_Ex01_02.Program.SandClockHightFive(numOfLoop);
                    PrintEndOfSandClock(numOfLoop, hight, ref starString);
                }
                else if (hight == 3)
                {
                    System.Console.WriteLine(string.Format(" {0}\n  {1}\n {2}", "***", "*", "***"));
                }
                else if (hight == 1)
                {
                    Console.WriteLine("*");
                }
            }
            else
            {
                Console.WriteLine("input invalid");
            }
        }

        public static bool ValidateInput(string io_strHight)
        {
            foreach (char c in io_strHight)
            {
                if (c < '0' || c > '9')
                {
                    return false;
                }
            }

            return true;
        }

        public static void InitiateStarString(int i_hight, ref StringBuilder io_starString)
        {
            for (int i = 0; i < i_hight; i++)
            {
                io_starString.Insert(i, "*");
            }
        }

        public static void PrintBegeiningOfSandClock(int i_numOfLoop, int i_hight, ref StringBuilder io_starString)
        {
            for (int i = 0; i < i_numOfLoop; i++)
            {
                Console.WriteLine(io_starString);
                if (i != i_numOfLoop - 1)
                {
                    io_starString.Replace("*", " ", i, 1);
                    io_starString.Replace("*", " ", i_hight - i - 1, 1);
                }
            }
        }

        public static void PrintEndOfSandClock(int i_numOfLoop, int i_hight, ref StringBuilder io_starString)
        {
            for (int i = i_numOfLoop - 1; i >= 0; i--)
            {
                io_starString.Replace(" ", "*", i, 1);
                io_starString.Replace(" ", "*", i_hight - i - 1, 1);
                Console.WriteLine(io_starString);
            }
        }
    }
}