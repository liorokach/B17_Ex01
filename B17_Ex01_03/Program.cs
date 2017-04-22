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
            Console.WriteLine("\n");
            int numOfLoop;
            int hight = int.Parse(hightString);
            StringBuilder starString = new StringBuilder(hight);
            if (hight % 2 == 0)
            {
                hight = hight - 1;
            }

            for (int i = 0; i < hight; i++)
            {
                starString.Insert(i, "*");
            }

            numOfLoop = (hight - 5) / 2;

            if (hight == 5)
            {
                B17_Ex01_02.Program.SandClockHightFive(numOfLoop);
            }
            else if (hight >= 7)
            {
                for (int i = 0; i < numOfLoop; i++)
                {
                    Console.WriteLine(starString);
                    if (i != numOfLoop - 1)
                    {
                        starString.Replace("*", " ", i, 1);
                        starString.Replace("*", " ", hight - i - 1, 1);
                    }
                }

                B17_Ex01_02.Program.SandClockHightFive(numOfLoop);
                for (int i = numOfLoop - 1; i >= 0; i--)
                {
                    starString.Replace(" ", "*", i, 1);
                    starString.Replace(" ", "*", hight - i - 1, 1);
                    Console.WriteLine(starString);
                }
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
    }
}
