//Author: Joshua Elmer
//Author's email: joshuaelmer@fullerton.edu
//Course: CPSC223N
//Assignment number: 2
//Title: Traffic Light
//Date last updated: 10/11/2020 (mm/dd/yyyy)




using System;
using System.Windows.Forms;            //Needed for "Application.Run" near the end of Main function.
public class trafficlightmain
{  public static void Main()
   {  System.Console.WriteLine("The graphics program will begin now.");
      trafficlightuserinterface trafficlight_app = new trafficlightuserinterface();
      Application.Run(trafficlight_app);
      System.Console.WriteLine("This graphics program has ended.  Bye.");
   }//End of Main function
}//End of trafficlightmain class
