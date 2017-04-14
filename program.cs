public class Program
{
     public static class Constants
     {
          public const int k_InputLen = 8; // number of input from user
     }

     public static void Main()  
     {
          Ex01Q5Manager();
     }

     public static void Ex01Q5Manager()
     {
          int userNumber, minDigVal, maxDigVal, aboveUnityDig, belowUnityDig;
          userNumber = GetEightDigitsNumberInput();
          maxDigVal = GetMaxDigit(userNumber);
          minDigVal = GetMinDigit(userNumber);
          aboveUnityDig = GetAboveUnityDig(userNumber);
          belowUnityDig = GetBelowUnityDig(userNumber);
          PrintDetailsFormat(maxDigVal, minDigVal, aboveUnityDig, belowUnityDig);
     }

     public static void PrintDetailsFormat(int maxDigVal, int minDigVal, int aboveUnityDig, int belowUnityDig)
     {
          System.Console.WriteLine(string.Format("The max digit in the number is {0} and the min digit is {1}.", maxDigVal, minDigVal));
          System.Console.WriteLine(string.Format("The number of digits above the unity is {0} and {1} are below the unity.", aboveUnityDig, belowUnityDig));
     }

     public static int GetEightDigitsNumberInput()
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

          return userNumber;
     }

     public static int GetAboveUnityDig(int i_number)
     {
          int unityDigit = i_number % 10, countAbove = 0;
          i_number /= 10;
          while (i_number > 0)
          {
               countAbove = i_number % 10 > unityDigit ? countAbove + 1 : countAbove;
               i_number /= 10;
          }

          return countAbove;
     }

     public static int GetBelowUnityDig(int i_number)
     {
          int unityDigit = i_number % 10, countBelow = 0;
          i_number /= 10;
          while (i_number > 0)
          {
               countBelow = i_number % 10 < unityDigit ? countBelow + 1 : countBelow;
               i_number /= 10;
          }

          return countBelow;
     }

     public static int GetMaxDigit(int i_Num)
     {
          int maxDig = 0;
          while (i_Num != 0) 
          {
               maxDig = System.Math.Max(maxDig, i_Num % 10);
               i_Num /= 10;
          }

          return maxDig;
     }

     public static int GetMinDigit(int i_Num)
     {
          int minDig = 10;
          while (i_Num != 0)
          {
               minDig = System.Math.Min(minDig, i_Num % 10);
               i_Num /= 10;
          }

          return minDig;
     }
} 
