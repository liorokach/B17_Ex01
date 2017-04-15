////Ex01_Q1
////Lior Rokach & Oz Nasi 15.04.17
////This program get 3 positive integers from user and convert the numbers to their binary value and print
////Additionally it calculate and print the average digits of binary number, the average value of the integer input number and how many numbers are ascending and decreasing 
using System.Text;

namespace B17_Ex01_1
{
     public class Program
     {
          public static class Constants
          {
               public const int k_NumOfInputs = 3; // number of input from user
          }

          public static void Main()
          {
               Ex01Q1Manager();
          }

          /*this function manage the program*/
          public static void Ex01Q1Manager()
          {
               int[] decNums = new int[Constants.k_NumOfInputs];
               int countDigitsOfTheBin = 0, countAscending = 0, countDescending = 0;
               float avgValueFromInput, avgDigInBinNum;
               decNums = GetValidInputAndCheckSeries(ref countAscending, ref countDescending);
               countDigitsOfTheBin = PrintBinaryNumbers(decNums);
               avgValueFromInput = CalculateAvgValue(decNums); // calculte the average value of a input from user number(decimal)
               avgDigInBinNum = (float)countDigitsOfTheBin / Constants.k_NumOfInputs; // calculate the number of digits in the average binary number
               PrintResult(countAscending, countDescending, avgDigInBinNum, avgValueFromInput); // printing the result format
          }

          /*this function get integer array and print the binary value of the integer arrray decimal numbers,additionally the function count the number of digits of all the binary numbers and return that */
          public static int PrintBinaryNumbers(int[] i_decNumbers)
          {
               string binaryStr;
               int countDigits = 0;
               System.Console.Write("The binary numbers are: ");
               for (int i = 0; i < Constants.k_NumOfInputs; i++)
               {
                    binaryStr = ConvertToBinary(i_decNumbers[i]); // convert decimal to binary and print the binary value
                    System.Console.Write(binaryStr);
                    countDigits += binaryStr.Length; // add the num of digits of the binary number
                    System.Console.Write(i == Constants.k_NumOfInputs - 1 ? "\n" : " "); // print 'space' ,  or 'endline' at the last number to print 
               }

               return countDigits;
          }

          /*this function get input from user and check if it valid while check if the input is series(ascending\descending), return the input as integer array + by ref counter of ascending and descending number */
          public static int[] GetValidInputAndCheckSeries(ref int o_CountUp, ref int o_CountDown)
          {
               int[] decNumberArr = new int[Constants.k_NumOfInputs];
               string inputNumByStr;
               System.Console.WriteLine("Please enter 3 positive numbers with 3 digits each:");
               for (int i = 0; i < Constants.k_NumOfInputs; i++)
               {
                    inputNumByStr = System.Console.ReadLine(); // get input from user
                    int.TryParse(inputNumByStr, out decNumberArr[i]); // check if input is positive number  
                    while (decNumberArr[i] == 0 || inputNumByStr.Length != 3)
                    {
                         i = o_CountDown = o_CountUp = 0;
                         System.Console.WriteLine("The input you entered is invalid. Please try again."); // inform the user that his input invalid
                         inputNumByStr = System.Console.ReadLine();
                         int.TryParse(inputNumByStr, out decNumberArr[i]);
                    }

                    o_CountUp += IsIncreasing(inputNumByStr.ToString()); // increment if the number's digits are increasing
                    o_CountDown += IsIncreasing(ReverseString(inputNumByStr).ToString()); // increment if the number's digits are decreasing
               }

               return decNumberArr;
          }

          /*this function print the result(how many numbers are ascending/descending series ,the average digits of a binary number,the average of the input numbers*/
          public static void PrintResult(int i_AscendingCount, int i_DescendingCount, float i_AvgNumOfDigInBin, float i_AvgOfInsertNums)
          {
               System.Console.WriteLine("There are {0} numbers which are an ascending series and {1} which are descending.", i_AscendingCount, i_DescendingCount);
               System.Console.WriteLine("The average number of digits in the binary number is " + i_AvgNumOfDigInBin.ToString());
               System.Console.WriteLine("The general average of the inserted numbers is " + i_AvgOfInsertNums.ToString());
          }

          /*this function get an integer array and calculate+return the average value of the numbers*/
          public static float CalculateAvgValue(int[] i_IntArray)
          {
               int sumOfNums = 0;
               for (int i = 0; i < i_IntArray.Length; i++)
               {
                    sumOfNums += i_IntArray[i];
               }

               return (float)sumOfNums / i_IntArray.Length;
          }

          /*this function get a string and reverse it and return the reverse string as stringbuilder*/
          public static StringBuilder ReverseString(string i_StrToReverse)
          {
               StringBuilder reverseStr = new StringBuilder(i_StrToReverse.Length);
               for (int i = i_StrToReverse.Length - 1; i >= 0; i--)
               {
                    reverseStr.Append(i_StrToReverse[i]);
               }

               return reverseStr;
          }

          /*this function get string and return 1 if the string is asending series and 0 if not */
          public static int IsIncreasing(string i_TextNumber)
          {
               char previous = (char)('0' - 1);
               foreach (char c in i_TextNumber)
               {
                    if (c <= previous)
                    {
                         return 0;
                    }

                    previous = c;
               }

               return 1;
          }

          /*this function convert integer(decimal) to binary as string and return the binary string*/
          public static string ConvertToBinary(int i_DecNum) 
          {
               string binaryStr = string.Empty;
               while (i_DecNum > 0)
               {
                    binaryStr = (i_DecNum % 2).ToString() + binaryStr;
                    i_DecNum /= 2;
               }

               return binaryStr;
          }
     }
}