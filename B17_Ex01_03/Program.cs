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
            int numOfLoop, hight;
            bool isInputValid;
            string hightString;
            do
            {
                Console.WriteLine("Please enter the hight of the sand clock ! \n");
                hightString = Console.ReadLine();
                isInputValid = ValidateInput(hightString, out hight);
            }
            while (!isInputValid);

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

        public static bool ValidateInput(string i_StrHight, out int io_Hight)
        {
            return int.TryParse(i_StrHight, out io_Hight);
        }

        public static void InitiateStarString(int i_Hight, ref StringBuilder io_StarString)
        {
            for (int i = 0; i < i_Hight; i++)
            {
                io_StarString.Insert(i, "*");
            }
        }

        public static void PrintBegeiningOfSandClock(int i_NumOfLoop, int i_Hight, ref StringBuilder io_StarString)
        {
            for (int i = 0; i < i_NumOfLoop; i++)
            {
                Console.WriteLine(io_StarString);
                if (i != i_NumOfLoop - 1)
                {
                    io_StarString.Replace("*", " ", i, 1);
                    io_StarString.Replace("*", " ", i_Hight - i - 1, 1);
                }
            }
        }

        public static void PrintEndOfSandClock(int i_NumOfLoop, int i_Hight, ref StringBuilder io_StarString)
        {
            for (int i = i_NumOfLoop - 1; i >= 0; i--)
            {
                io_StarString.Replace(" ", "*", i, 1);
                io_StarString.Replace(" ", "*", i_Hight - i - 1, 1);
                Console.WriteLine(io_StarString);
            }
        }
    }
}