// lior rokach
using System.Text;

public class B17_Ex01_2
{
     public static void Main()  ////this method is the main
     {
          // StringBuilder fiveLineSandMachine = CreateFiveLineSandMachine();
          // System.Console.WriteLine(fiveLineSandMachine);
          System.Console.WriteLine(string.Format(" {0}\n  {1}\n   {2}\n  {3}\n {4}", "*****", "***", "*", "***", "*****"));
     }

     public static StringBuilder CreateFiveLineSandMachine()
     {
          StringBuilder sandMachine = new StringBuilder(" *****\n");
          sandMachine.Append("  ***\n");
          sandMachine.Append("   *\n");
          sandMachine.Append("  ***\n");
          sandMachine.Append(" *****");
          return sandMachine;
     }
}