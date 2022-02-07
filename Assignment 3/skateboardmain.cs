//Author: Joshua Elmer
//Author's email: joshuaelmer@fullerton.edu
//Course: CPSC223N
//Assignment number: 3
//Title: Skateboarder
//Date last updated: 10/18/2020 (mm/dd/yyyy)



using System;
using System.Windows.Forms;            //Needed for "Application" near the end of Main function.
public class Straight_line_main
{  public static void Main()
   {  System.Console.WriteLine("The Skateboarder program has begun.");
      skateboarduserinterface skateboard = new skateboarduserinterface();
      Application.Run(skateboard);
      System.Console.WriteLine("The Skateboarder program has ended.  Bye.");
   }//End of Main function
}//End of Straight_line_main class
