////Ex01_Q5
////Lior Rokach & Oz Nasi 15.04.17
////This program get 8 digits positive integer from user and found and print to screen the max digit and min digit, 
////Additionally the program prints how many digits are bigger than the unity digit and how much smaller
namespace B17_Ex01_5
{
     public class Program
     {
          public static class Constants
          {
               public const int k_InputLen = 8; // number of digits input from user
          }

          public static void Main()
          {
               Ex01Q5Manager();
          }

          /*this function get 8 digits number from user and check details about this number(max/min digit, how many digits bigger/smaller than unity digit) and print the result*/
          public static void Ex01Q5Manager()
          {
               int aboveUnityDig, belowUnityDig;
               string userNumberStr;
               char minDigVal, maxDigVal;
               userNumberStr = GetEightDigitsNumberInput();
               maxDigVal = GetMaxDigit(userNumberStr);
               minDigVal = GetMinDigit(userNumberStr);
               aboveUnityDig = CountAboveUnityDig(userNumberStr);
               belowUnityDig = CountBelowUnityDig(userNumberStr);
               PrintResult(maxDigVal, minDigVal, aboveUnityDig, belowUnityDig);
          }

          /*this function get 2 char represent max/min digit and 2 integer represent number of digits above/below the unity and print them to the user */
          public static void PrintResult(char i_maxDigVal, char i_minDigVal, int i_aboveUnityDig, int i_belowUnityDig)
          {
               System.Console.WriteLine(string.Format("The maximum digit in the number is {0} and the minimum digit is {1}.", i_maxDigVal, i_minDigVal));
               System.Console.WriteLine(string.Format("The number of digits above the unity is {0} and {1} is below the unity.", i_aboveUnityDig, i_belowUnityDig));
          }

          /*this function get from the user eight digits positive integer(check validation) and return the valid input as string*/
          public static string GetEightDigitsNumberInput()
          {
               int userNumber;
               System.Console.WriteLine("Please enter integer positive number with 8 digits:");
               string inputNumByStr = System.Console.ReadLine(); // get input from user
               int.TryParse(inputNumByStr, out userNumber);
               while (userNumber == 0 || inputNumByStr.Length != Constants.k_InputLen)
               {
                    System.Console.WriteLine("Invalid input, please try again.");
                    inputNumByStr = System.Console.ReadLine(); // get input from user
                    int.TryParse(inputNumByStr, out userNumber);
               }

               return inputNumByStr;
          }

          /*this function count how many digits are bigger than the unity digits and return the counter*/
          public static int CountAboveUnityDig(string i_numberStr)
          {
               int countAbove = 0;
               for (int i = 0; i < Constants.k_InputLen - 1; i++) 
               {
                    if (i_numberStr[i] > i_numberStr[Constants.k_InputLen - 1])
                    {
                         countAbove++;
                    }
               }

               return countAbove;
          }

          /*this function count how many digits are smaller than the unity digits and return the counter*/
          public static int CountBelowUnityDig(string i_numberStr)
          {
               int countBelow = 0;
               for (int i = 0; i < Constants.k_InputLen - 1; i++)
               {
                    if (i_numberStr[i] < i_numberStr[Constants.k_InputLen - 1])
                    {
                         countBelow++;
                    }
               }

               return countBelow;
          }

          /*this function get string and return the biggest char value of the string number*/
          public static char GetMaxDigit(string i_NumStr)
          {
               char maxDig = '0';
               for (int i = 0; i < Constants.k_InputLen; i++)
               {
                    maxDig = (char)(System.Math.Max(maxDig - '0', i_NumStr[i] - '0')+'0');
               }

               return maxDig;
          }
          /*this function get string and return the smallest char value of the string number*/
          public static char GetMinDigit(string i_NumStr)
          {
               char minDig = '9';
               for (int i = 0; i < Constants.k_InputLen; i++)
               {
                    minDig = (char)(System.Math.Min(minDig - '0', i_NumStr[i] - '0')+'0');
               }

               return minDig;
          }
     }
}