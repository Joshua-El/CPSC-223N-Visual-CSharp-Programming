//****************************************************************************************************************************
//Program name: "Imperial to Metric Converter".  This programs accepts an imperial number in inches from the user and        *
//then outputs the Metric equivalent.                                                                                        *
//Copyright (C) 2020  Joshua Elmer                                                                                           *
//This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License  *
//version 3 as published by the Free Software Foundation.                                                                    *
//This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied         *
//warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.     *
//A copy of the GNU General Public License v3 is available here:  <https://www.gnu.org/licenses/>.                           *
//****************************************************************************************************************************






//Author: Joshua Elmer
//Mail: joshuaelmer@csu.fullerton.edu

//Program name: Imperial to Metric Converter
//Programming language: C Sharp
//Date development of program began: 2020-Sept-26
//Date of last update: 2020-Sept-27

//Purpose:  This program will compute acMetric number given its Imperial equivalent.

//Files in project: Convertermain.cs, Converterlogic.cs, Converteruserinterface.cs, build.sh

//This file's name: Converteruserinterface.cs
//This file purpose: This file describes the structure of the user interface window.
//Date last modified: 2020-Sept-27


//Function: The Imperial to Metric Converter.  Enter a non-negative number in the input field, then
//click on the compute button, and the result will appear as a string.


using System;
using System.Drawing;
using System.Windows.Forms;

public class Converteruserinterface: Form
{private Label welcome = new Label();
 private Label author = new Label();
 private Label sequencemessage = new Label();
 private TextBox sequenceinputarea = new TextBox();
 private Label outputinfo = new Label();
 private Button computebutton = new Button();
 private Button clearbutton = new Button();
 private Button exitbutton = new Button();
 private Panel headerpanel = new Panel();
 private Panel displaypanel = new Panel();
 private Panel controlpanel = new Panel();
 private Size maximumConverterinterfacesize = new Size(1024,800);
 private Size minimumConverterinterfacesize = new Size(1024,800);

 public Converteruserinterface()  //Constructor
   {//Set the size of the user interface box.
    MaximumSize = maximumConverterinterfacesize;
    MinimumSize = minimumConverterinterfacesize;
    //Initialize text strings
    Text = "Imperial to Metric Converter";
    welcome.Text = "Welcome to Metric Converter";
    author.Text = "Author: Joshua Elmer";
    sequencemessage.Text = "Enter an Imperial number:";
    sequenceinputarea.Text = "Enter inches: ";
    outputinfo.Text = "Result will display here.";
    computebutton.Text = "Compute";
    clearbutton.Text = "Clear";
    exitbutton.Text = "Exit";

    //Set sizes
    Size = new Size(400,240);
    welcome.Size = new Size(800,44);
    author.Size = new Size(320,34);
    sequencemessage.Size = new Size(400,36);
    sequenceinputarea.Size = new Size(200,30);
    outputinfo.Size = new Size(900,80);   //This label has a large height to accommodate 2 lines output text.
    computebutton.Size = new Size(120,60);
    clearbutton.Size = new Size(120,60);
    exitbutton.Size = new Size(120,60);
    headerpanel.Size = new Size(1024,200);
    displaypanel.Size = new Size(1024,400);
    controlpanel.Size = new Size(1024,200);

    //Set colors
    headerpanel.BackColor = Color.MediumTurquoise;
    displaypanel.BackColor = Color.Chartreuse;
    controlpanel.BackColor = Color.Gold;
    computebutton.BackColor = Color.Red;
    clearbutton.BackColor = Color.Red;
    exitbutton.BackColor = Color.Red;

    //Set fonts
    welcome.Font = new Font("Times New Roman",33,FontStyle.Bold);
    author.Font = new Font("Times New Roman",26,FontStyle.Regular);
    sequencemessage.Font = new Font("Arial",26,FontStyle.Regular);
    sequenceinputarea.Font = new Font("Arial",19,FontStyle.Regular);
    outputinfo.Font = new Font("Arial",26,FontStyle.Regular);
    computebutton.Font = new Font("Liberation Serif",15,FontStyle.Regular);
    clearbutton.Font = new Font("Liberation Serif",15,FontStyle.Regular);
    exitbutton.Font = new Font("Liberation Serif",15,FontStyle.Regular);

    //Set locations
    headerpanel.Location = new Point(0,0);
    welcome.Location = new Point(125,26);
    author.Location = new Point(330,100);
    sequencemessage.Location = new Point(100,60);
    sequenceinputarea.Location = new Point(600,60);
    outputinfo.Location = new Point(100,200);
    computebutton.Location = new Point(200,50);
    clearbutton.Location = new Point(450,50);
    exitbutton.Location = new Point(720,50);
    headerpanel.Location = new Point(0,0);
    displaypanel.Location = new Point(0,200);
    controlpanel.Location = new Point(0,600);

    //Associate the Compute button with the Enter key of the keyboard
    AcceptButton = computebutton;

    //Add controls to the form
    Controls.Add(headerpanel);
    headerpanel.Controls.Add(welcome);
    headerpanel.Controls.Add(author);
    Controls.Add(displaypanel);
    displaypanel.Controls.Add(sequencemessage);
    displaypanel.Controls.Add(sequenceinputarea);
    displaypanel.Controls.Add(outputinfo);
    Controls.Add(controlpanel);
    controlpanel.Controls.Add(computebutton);
    controlpanel.Controls.Add(clearbutton);
    controlpanel.Controls.Add(exitbutton);

    //Register the event handler.  In this case each button has an event handler, but no other
    //controls have event handlers.
    computebutton.Click += new EventHandler(computemetricnumber);
    clearbutton.Click += new EventHandler(cleartext);
    exitbutton.Click += new EventHandler(stoprun);  //The '+' is required.

    //Open this user interface window in the center of the display.
    CenterToScreen();

  }//End of constructor Converteruserinterface

 //Method to execute when the compute button receives an event, namely: receives a mouse click
 protected void computemetricnumber(Object sender, EventArgs events)
   {double imperialnum;        //Formerly: uint imperialnum;
    string output;
    try
       {imperialnum = double.Parse(sequenceinputarea.Text);
        if(imperialnum < 0)
            {Console.WriteLine("Negative integer input received.  Please try again.");
             output = "Negative integer received.  Please try again.";
            }
        else
            {double metricnum = Converterlogic.computemetricnumber(imperialnum);
                   output = "The corresponding Metric number is " + metricnum + "meters.";
            }
       }//End of try
    catch(FormatException malformed_input)
       {Console.WriteLine("Non-double input received.  Please try again.\n{0}",malformed_input.Message);
        output = "Invalid input: no Metric number computed.";
       }//End of catch
     catch(OverflowException too_big)
       {Console.WriteLine("The value inputted is greater than the largest 32-bit integer.  Try again.\n{0}",too_big.Message);
        output = "The input number was too large for 32-bit integers.";
       }//End of catch
    outputinfo.Text = output;
   }//End of computemetricnumber


 //Method to execute when the clear button receives an event, namely: receives a mouse click
 protected void cleartext(Object sender, EventArgs events)
   {sequenceinputarea.Text = ""; //Empty string
    outputinfo.Text = "Result will display here.";
   }//End of cleartext

 //Method to execute when the exit button receives an event, namely: receives a mouse click
 protected void stoprun(Object sender, EventArgs events)
   {Close();
   }//End of stoprun

}//End of clas Converteruserinterface
