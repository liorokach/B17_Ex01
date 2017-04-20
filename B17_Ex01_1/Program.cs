////Ex01_Q1
////Lior Rokach & Oz Nasi 15.04.17
////This program get 3 positive integers from user and convert the numbers to their binary value and print
////Additionally it calculate and print the average digits of binary number, the average value of the integer input number and how many numbers are ascending and decreasing 
using System;
using System.Text;

namespace B17_Ex01_1
{
     public class Program
     {
          public static void Main()
          {
               Ex01Q1Manager();
          }

          /*this function manage the program*/
          public static void Ex01Q1Manager()
          {
               int[] decNumsArr = new int[3];
               string[] NumbersInStrArr = new string[3];
               string[] BinaryArrInStr = new string[3];
               int countAscending = 0, countDescending = 0; 
               float avgValueFromInput, avgDigInBinNum;
               decNumsArr = GetValidInput(NumbersInStrArr);
               countAscending = CheckAscending(NumbersInStrArr);
               countDescending = CheckDescending(NumbersInStrArr);
               BinaryArrInStr = GetBinaryValue(decNumsArr);
               PrintBinaryNumbers(BinaryArrInStr);
               avgValueFromInput = CalculateAvgInputValue(decNumsArr); // calculte the average value of a input from user number(decimal)
               avgDigInBinNum = CalculateAvgBinaryLen(BinaryArrInStr); // calculate the number of digits in the average binary number
               PrintResult(countAscending, countDescending, avgDigInBinNum, avgValueFromInput); // printing the result format
          }

          /*this function get input from user and check if it valid while check if the input is series(ascending\descending), return the input as integer array + by ref counter of ascending and descending number */
          public static int[] GetValidInput(string[] io_StrNumsArr)
          {
               int[] decNumberArr = new int[3];
               string inputNumByStr;
               Console.WriteLine("Please enter 3 positive numbers with 3 digits each:");
               for (int i = 0; i < 3; i++)
               {
                    inputNumByStr = Console.ReadLine(); // get input from user
                    bool validNum = int.TryParse(inputNumByStr, out decNumberArr[i]); // check if input is positive number  
                    while (decNumberArr[i] == 0 || !validNum || inputNumByStr.Length != 3) 
                    {
                         i = 0; ////zeroing the index
                         Console.WriteLine("The input you entered is invalid. Please try again."); // inform the user that his input invalid
                         inputNumByStr = Console.ReadLine();
                         validNum = int.TryParse(inputNumByStr, out decNumberArr[i]);
                    }

                    io_StrNumsArr[i] = inputNumByStr;
               }

               return decNumberArr;
          }

          public static int CheckAscending(string[] i_NumbersInStrArr)
          {
               int countAsending = 0;
               for (int i = 0; i < i_NumbersInStrArr.Length; i++)
               {
                    countAsending += IsIncreasing(i_NumbersInStrArr[i]); // increment if the number's digits are increasing
               }

               return countAsending;
          }

          public static int CheckDescending(string[] i_NumbersInStrArr)
          {
               int countDescending = 0;
               for (int i = 0; i < i_NumbersInStrArr.Length; i++)
               {
                    countDescending += IsIncreasing(ReverseString(i_NumbersInStrArr[i]).ToString()); // increment if the number's digits are decreasing
               }

               return countDescending;
          }

          public static string[] GetBinaryValue(int[] i_DecNumbers)
          {
               string[] binaryStr = new string[i_DecNumbers.Length];
               for (int i = 0; i < i_DecNumbers.Length; i++)
               {
                    binaryStr[i] = ConvertToBinary(i_DecNumbers[i]); // convert decimal to binary value as string
               }

               return binaryStr;
          }

          /*this function get integer array and print the binary value of the integer arrray decimal numbers,additionally the function count the number of digits of all the binary numbers and return that */
          public static void PrintBinaryNumbers(string[] i_BinaryNumbers)
          {
               Console.Write("The binary numbers are: ");
               for (int i = 0; i < i_BinaryNumbers.Length; i++)
               {
                    Console.Write(i_BinaryNumbers[i]);
                    Console.Write(i == i_BinaryNumbers.Length - 1 ? "\n" : " "); // print 'space' ,  or 'endline' at the last number to print 
               }
          }

          /*this function get an integer array and calculate+return the average value of the numbers*/
          public static float CalculateAvgInputValue(int[] i_IntArray)
          {
               int sumOfNums = 0;
               for (int i = 0; i < i_IntArray.Length; i++)
               {
                    sumOfNums += i_IntArray[i]; ////add the number to the sum
               }

               return (float)sumOfNums / i_IntArray.Length; // return the average by divine the sum with the number of numbers
          }

          public static float CalculateAvgBinaryLen(string[] i_BinaryArr)
          {
               int countDigits = 0;
               for (int i = 0; i < i_BinaryArr.Length; i++)
               {
                    countDigits += i_BinaryArr[i].Length; 
               }

               return (float)countDigits / i_BinaryArr.Length; // return the average by divine the sum of digits with the number of BinaryNumbers
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
                         return 0; // not increasing series
                    }

                    previous = c;
               }

               return 1; // the string is increasing series
          }

          /*this function convert integer(decimal) to binary as string and return the binary string*/
          public static string ConvertToBinary(int i_DecNum)
          {
               string binaryStr = string.Empty;
               while (i_DecNum > 0)
               {
                    binaryStr = (i_DecNum % 2).ToString() + binaryStr; // insert to the start the result of the current number mod 2
                    i_DecNum /= 2;
               }

               return binaryStr;
          }

          /*this function print the result(how many numbers are ascending/descending series ,the average digits of a binary number,the average of the input numbers*/
          public static void PrintResult(int i_AscendingCount, int i_DescendingCount, float i_AvgNumOfDigInBin, float i_AvgOfInsertNums)
          {
               string printSeriesResult = string.Format("There are {0} numbers which are an ascending series and {1} which are descending.", i_AscendingCount, i_DescendingCount);
               Console.WriteLine(printSeriesResult);
               Console.WriteLine("The average number of digits in the binary number is " + i_AvgNumOfDigInBin.ToString());
               Console.WriteLine("The general average of the inserted numbers is " + i_AvgOfInsertNums.ToString());
          }
     }
}