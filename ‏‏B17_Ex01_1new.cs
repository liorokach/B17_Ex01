// lior rokach
using System.Text;

public class B17_Ex01_1
{
     public static class Constants
     {
          public const int k_NumOfInputs = 3; // number of input from user
     }

     public static void Main()  ////this method is the main
     {
          int[] decNums = new int[Constants.k_NumOfInputs];
          int countDigitsOfTheBin = 0, countAscending = 0, countDecreasing = 0;
          float avgValueFromInput, avgDigInBinNum;
          decNums = GetValidInput();
          System.Console.Write("The binary numbers are: ");
          GetAscendingAndDecreasingCount(decNums, ref countAscending, ref countDecreasing);
          countDigitsOfTheBin = PrintBinaryNumbers(decNums);
          avgValueFromInput = CalculateAvgValue(decNums); // calculte the average value of a input from user number(decimal)
          avgDigInBinNum = (float)countDigitsOfTheBin / Constants.k_NumOfInputs; // calculate the number of digits in the average binary number
          PrintResult(countAscending, countDecreasing, avgDigInBinNum, avgValueFromInput); // printing the result format
     }

     public static void GetAscendingAndDecreasingCount(int[] decNums, ref int io_CountUp, ref int io_CountDown)
     {
          for (int i = 0; i < Constants.k_NumOfInputs; i++) 
          {
               io_CountUp += IsIncreasing(decNums[i].ToString()); // increment if the number's digits are increasing
               io_CountDown += IsIncreasing(ReverseString(decNums[i].ToString()).ToString()); // increment if the number's digits are decreasing
          }
     }

     public static int PrintBinaryNumbers(int[] decNumbers)
     {
          string binaryStr;
          int countDigits = 0;
          for (int i = 0; i < Constants.k_NumOfInputs; i++)
          {
               binaryStr = ConvertToBinary(decNumbers[i]); // convert decimal to binary and print the binary value
               System.Console.Write(binaryStr);
               countDigits += binaryStr.Length; // add the num of digits of the binary number
               System.Console.Write(i == Constants.k_NumOfInputs - 1 ? "\n" : " "); // print 'space' ,  or 'endline' at the last number to print 
          }

          return countDigits;
     }
     
     public static int[] GetValidInput()
     {
          int[] decNumberArr = new int[Constants.k_NumOfInputs];
          string inputNumByStr;
          System.Console.WriteLine("Please enter 3 positive numbers with 3 digits each:");
          for (int i = 0; i < Constants.k_NumOfInputs; i++)
          {
               inputNumByStr = System.Console.ReadLine(); // get input from user
               int.TryParse(inputNumByStr, out decNumberArr[i]); // check if input is number
               //// checking for unvalid input and loop until get valid one
               while (decNumberArr[i] == 0 || inputNumByStr.Length != 3) 
               {
                    i = 0;
                    System.Console.WriteLine("The input you entered is invalid. Please try again."); // inform the user that his input invalid
                    inputNumByStr = System.Console.ReadLine();
                    int.TryParse(inputNumByStr, out decNumberArr[i]);
               }
          }

          return decNumberArr;
     }

     public static void PrintResult(int AscendingCount, int DescendingCount, float AvgNumOfDigInBin, float AvgOfInsertNums)
     {
          System.Console.WriteLine(string.Format("There are {0} numbers which are an ascending series and {1} which are descending.", AscendingCount, DescendingCount));
          System.Console.WriteLine("The average number of digits in the binary number is " + AvgNumOfDigInBin.ToString());
          System.Console.WriteLine("The general average of the inserted numbers is " + AvgOfInsertNums.ToString());
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

     public static StringBuilder ReverseString(string i_Str)
    {
        StringBuilder reverseStr = new StringBuilder(i_Str.Length);
        for (int i = i_Str.Length - 1; i >= 0; i--)
        {
            reverseStr.Append(i_Str[i]);
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