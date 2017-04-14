using System.Text;

namespace B17_Ex01_1
{
     public class Program
     {
          public static class Constants
          {
               public const int k_NumOfInputs = 3; // number of input from user
          }

          public static void Main()  ////this method is the main
          {
               Ex01Q1Manager();
          }

          public static void Ex01Q1Manager()
          {
               int[] decNums = new int[Constants.k_NumOfInputs];
               int countDigitsOfTheBin = 0, countAscending = 0, countDecreasing = 0;
               float avgValueFromInput, avgDigInBinNum;
               decNums = GetValidInput(ref countAscending, ref countDecreasing);
               countDigitsOfTheBin = PrintBinaryNumbers(decNums);
               avgValueFromInput = CalculateAvgValue(decNums); // calculte the average value of a input from user number(decimal)
               avgDigInBinNum = (float)countDigitsOfTheBin / Constants.k_NumOfInputs; // calculate the number of digits in the average binary number
               PrintResult(countAscending, countDecreasing, avgDigInBinNum, avgValueFromInput); // printing the result format
          }

          public static int PrintBinaryNumbers(int[] decNumbers)
          {
               string binaryStr;
               int countDigits = 0;
               System.Console.Write("The binary numbers are: ");
               for (int i = 0; i < Constants.k_NumOfInputs; i++)
               {
                    binaryStr = ConvertToBinary(decNumbers[i]); // convert decimal to binary and print the binary value
                    System.Console.Write(binaryStr);
                    countDigits += binaryStr.Length; // add the num of digits of the binary number
                    System.Console.Write(i == Constants.k_NumOfInputs - 1 ? "\n" : " "); // print 'space' ,  or 'endline' at the last number to print 
               }

               return countDigits;
          }

          public static int[] GetValidInput(ref int io_CountUp, ref int io_CountDown)
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
                         i = io_CountDown = io_CountUp = 0;
                         System.Console.WriteLine("The input you entered is invalid. Please try again."); // inform the user that his input invalid
                         inputNumByStr = System.Console.ReadLine();
                         int.TryParse(inputNumByStr, out decNumberArr[i]);
                    }

                    io_CountUp += IsIncreasing(inputNumByStr.ToString()); // increment if the number's digits are increasing
                    io_CountDown += IsIncreasing(ReverseString(inputNumByStr).ToString()); // increment if the number's digits are decreasing
               }

               return decNumberArr;
          }

          public static void PrintResult(int i_AscendingCount, int i_DescendingCount, float i_AvgNumOfDigInBin, float i_AvgOfInsertNums)
          {
               System.Console.WriteLine("There are {0} numbers which are an ascending series and {1} which are descending.", i_AscendingCount, i_DescendingCount);
               System.Console.WriteLine("The average number of digits in the binary number is " + i_AvgNumOfDigInBin.ToString());
               System.Console.WriteLine("The general average of the inserted numbers is " + i_AvgOfInsertNums.ToString());
          }

          public static float CalculateAvgValue(int[] i_IntArray)
          {
               int sumOfNums = 0;
               for (int i = 0; i < i_IntArray.Length; i++)
               {
                    sumOfNums += i_IntArray[i];
               }

               return (float)sumOfNums / i_IntArray.Length;
          }

          public static StringBuilder ReverseString(string i_StrToReverse)
          {
               StringBuilder reverseStr = new StringBuilder(i_StrToReverse.Length);
               for (int i = i_StrToReverse.Length - 1; i >= 0; i--)
               {
                    reverseStr.Append(i_StrToReverse[i]);
               }

               return reverseStr;
          }

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

          public static string ConvertToBinary(int i_DecNum) ////this method convert dec to binary
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