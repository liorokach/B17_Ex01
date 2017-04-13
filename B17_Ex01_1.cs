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
          int countDigitsOfTheBin = 0, countUp = 0, countDown = 0;
          float avgValueFromInput, avgDigInBinNum;
          string binInStr, inputNumByStr; // input by user;
          System.Console.WriteLine("Please enter 3 positive numbers with 3 digits each:");
          for (int i = 0; i < Constants.k_NumOfInputs; i++)
          {
               inputNumByStr = System.Console.ReadLine();// get input from user
               int.TryParse(inputNumByStr, out decNums[i]);// check if input is number
               while (decNums[i] == 0 || inputNumByStr.Length != 3)// checking for unvalid input and loop until get valid one
               {
                    i = countUp = countDown = 0;// zeroing 
                    System.Console.WriteLine("The input you entered is invalid. Please try again.");// inform the user that his input invalid
                    inputNumByStr = System.Console.ReadLine();
                    int.TryParse(inputNumByStr, out decNums[i]);
               }
               countUp += IsIncreasing(inputNumByStr.ToString());// increment if the number's digits are increasing
               countDown += IsIncreasing(ReverseString(inputNumByStr).ToString());// increment if the number's digits are decreasing
          }

          System.Console.Write("The binary numbers are: ");
          for (int i = 0; i < Constants.k_NumOfInputs; i++)
          {
               binInStr = ConvertToBinary(decNums[i]);// convert decimal to binary and print the binary value
               System.Console.Write(binInStr);
               countDigitsOfTheBin += binInStr.Length;// add the num of digits of the binary number
               System.Console.Write(i == Constants.k_NumOfInputs - 1 ? "\n" : " ");// print 'space' ,  or 'endline' at the last number to print 
          }

          avgValueFromInput = CalculateAvgValue(decNums);// calculte the average value of a input from user number(decimal)
          avgDigInBinNum = (float)countDigitsOfTheBin / Constants.k_NumOfInputs;// calculate the number of digits in the average binary number
          PrintResult(countUp, countDown, avgDigInBinNum, avgValueFromInput);// printing the result format
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