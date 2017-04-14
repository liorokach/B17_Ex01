using System;
using System.Collections.Generic;
using System.Text;

namespace B17_Ex01_04
{
    public class Program
    {
        public static void Main()
        {
            analayzeString();
        }

        public static void analayzeString()
        {
            int avgOfStr, numsOfUpperCase;
            Console.WriteLine("please enter your string, English Or Numbers only!\n");

            StringBuilder str = new StringBuilder(Console.ReadLine(), 8);

            string reversedStr = ReverseString(str.ToString());

            if (str.Equals(reversedStr))
            {
                Console.WriteLine("The string is palindrom");
            }
            else if (str[0] > '1' && str[0] <= '9')
            {
                avgOfStr = GetAvarageFromStrNumbers(str.ToString());

                string strAvaregeMsg = string.Format("The avarge of the string is: {0}", avgOfStr);
                Console.WriteLine(strAvaregeMsg);
            }
            else if(str[0] >= 'A' && str[0] <= 'z')
            {
                numsOfUpperCase = GetNumOfCamelCase(str.ToString());
                string strCamelCaseMsg = string.Format("The number of upper case is: {0}", numsOfUpperCase);
                Console.WriteLine(strCamelCaseMsg);
            }
        }

        public static int GetNumOfCamelCase(string i_str)
        {
            int howManyCamel = 0;
            int sizeStr = i_str.Length;
            for (int i = 0; i < sizeStr; i++)
            {
                if(i_str[i] >= 'A' && i_str[i] <= 'Z')
                {
                    howManyCamel++;
                }
            }

            return howManyCamel;
        }

        public static int GetAvarageFromStrNumbers(string i_str)
        {
            int avg, sum = 0;
            int sizeStr = i_str.Length;
            for (int i = 0; i < sizeStr; i++)
            {
                sum += i_str[i] - '0';
            }

            return avg = sum / sizeStr;
        }

        public static string ReverseString(string i_str)
        {
            int sizeStr = i_str.Length;
            string reversedStr = string.Empty;

            for (int i = sizeStr - 1; i >= 0; i--)
            {
                reversedStr += i_str[i];
            }

            return reversedStr;
        }
    }
}
