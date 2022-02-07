//Author: Joshua Elmer
//Author's email: joshuaelmer@fullerton.edu
//Course: CPSC223N
//Assignment number: 4
//Title: Ricochet
//Date last updated: 11/6/2020 (mm/dd/yyyy)



using System;
using System.Windows.Forms;            //Needed for "Application" near the end of Main function.
public class Ricochet_main
{  public static void Main()
   {  System.Console.WriteLine("The Ricochet program has begun.");
      ricochetuserinterface ricochet = new ricochetuserinterface();
      Application.Run(ricochet);
      System.Console.WriteLine("The Ricochet program has ended.  Bye.");
   }//End of Main function
}//End of Ricochet_main class
