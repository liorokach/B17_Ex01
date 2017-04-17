////Ex01_Q4
////Lior Rokach & Oz Nasi 15.04.17
////This program get from user string in eight lenght.
////the string shuld contain only nmbers or letter.
////the program indicate if the string is palindroom,
////or if the string contains only letter it counts how many camel letter in string and print it.



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
            string strfromUser = Console.ReadLine();
            bool isInputValid = ValidteInput(strfromUser);
            if (isInputValid)
            {
                StringBuilder str = new StringBuilder(strfromUser, 8);
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
                else if (str[0] >= 'A' && str[0] <= 'z')
                {
                    numsOfUpperCase = GetNumOfCamelCase(str.ToString());
                    string strCamelCaseMsg = string.Format("The number of upper case is: {0}", numsOfUpperCase);
                    Console.WriteLine(strCamelCaseMsg);
                }
            }
            else
            {
                Console.WriteLine("input invalid");
            }
        }

        public static int GetNumOfCamelCase(string i_str)
        {
            int howManyCamel = 0;
            int sizeStr = i_str.Length;
            for (int i = 0; i < sizeStr; i++)
            {
                if (i_str[i] >= 'A' && i_str[i] <= 'Z')
                {
                    howManyCamel++;
                }
            }

            return howManyCamel;
        }

        public static bool ValidteInput(string i_strFromUser)
        {
            bool isAllNumbers, isAllLetters;
            isAllNumbers = ValidteInputNumber(i_strFromUser);
            isAllLetters = ValidteInputLetter(i_strFromUser);

            return (isAllLetters || isAllNumbers) && i_strFromUser.Length == 8;
        }

        public static bool ValidteInputNumber(string i_strFromUser)
        {
            foreach (char c in i_strFromUser)
            {
                if (c < '0' || c > '9')
                {
                    return false;
                }
            }

            return true;
        }

        public static bool ValidteInputLetter(string i_strFromUser)
        {
            foreach (char c in i_strFromUser)
            {
                if (c < 'A' || c > 'z')
                {
                    return false;
                }
            }

            return true;
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