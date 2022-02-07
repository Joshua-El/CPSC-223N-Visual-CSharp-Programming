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

//This file's name: Convertermain.cs
//This file purpose: This file will activate the user interface
//Date last modified: 2020-Sept-27

//
using System;
//using System.Drawing;
using System.Windows.Forms;  //Needed for "Application" on next to last line of Main
public class Convertermain
{  static void Main(string[] args)
   {System.Console.WriteLine("Welcome to the Main method of the Metric Converter program.");
    Converteruserinterface Converterapp = new Converteruserinterface();
    Application.Run(Converterapp);
    System.Console.WriteLine("Main method will now shutdown.");
   }//End of Main
}//End of Converteronaccimain

//=================================================================================================================================

//Notes to the C# programming class
//This is a sample programming to use for learning to construct user interfaces with C#
//You are free to re-use and parts of this program in your own homework.  That is what an open source licensing agreement intends to do.
//Some things you should notice:
//   The program contains 3 files.  Together they make one program.
//   There is a main function.  Its main job is to activate the user interface in the file "Converteruserinterface.cs".
//   The UI seen by the human user is constructed in layers.
//   The base layer is a bare form: usually it is a gray rectangle.
//   This program places on top of the base form three panels called headerpanel, displaypanel, and controlpanel.
//   The panels can be thought of as "layer 2".
//   On top of each individual panel there are attached some 'objects'.  The objects are layer three.
//   On top of the headerpanel there are some informative messages and nothing more.
//   On top of the displaypanel there is a input box known as a "text box".
//   Also on the displaypanel there is extra space to display output data.
//   On the controlpanel there are three buttons
//   Everything in sight has lots of colors because we want the customer to like to use our software.
//That summarizes the structure of the UI of this program.  That same structure of UI will be re-used in many (or even most) of the
//programs you will create in this course.




//We like to use lots of colors in C# programming.  The following is a list of all the color in C# that have a name.
//Keep the like available; you never know when you may need it.

/*
AliceBlue
AntiqueWhite
Aqua
Aquamarine
Azure
Beige
Bisque
Black
BlanchedAlmond
Blue
BlueViolet
Brown
BurlyWood
CadetBlue
Chartreuse
Chocolate
Coral
CornflowerBlue
Cornsilk
Crimson
Cyan
DarkBlue
DarkCyan
DarkGoldenrod
DarkGray
DarkGreen
DarkKhaki
DarkMagenta
DarkOliveGreen
DarkOrange
DarkOrchid
DarkRed
DarkSalmon
DarkSeaGreen
DarkSlateBlue
DarkSlateGray
DarkTurquoise
DarkViolet
DeepPink
DeepSkyBlue
DimGray
DodgerBlue
Firebrick
FloralWhite
ForestGreen
Fuchsia
Gainsboro
GhostWhite
Gold
Goldenrod
Gray
Green
GreenYellow
Honeydew
HotPink
IndianRed
Indigo
Ivory
Khaki
Lavender
LavenderBlush
LawnGreen
LemonChiffon
LightBlue
LightCoral
LightCyan
LightGoldenrodYellow
LightGreen
LightGray
LightPink
LightSalmon
LightSeaGreen
LightSkyBlue
LightSlateGray
LightSteelBlue
LightYellow
Lime
LimeGreen
Linen
Magenta
Maroon
MediumAquamarine
MediumBlue
MediumOrchid
MediumPurple
MediumSeaGreen
MediumSlateBlue
MediumSpringGreen
MediumTurquoise
MediumVioletRed
MidnightBlue
MintCream
MistyRose
Moccasin
NavajoWhite
Navy
OldLace
Olive
OliveDrab
Orange
OrangeRed
Orchid
PaleGoldenrod
PaleGreen
PaleTurquoise
PaleVioletRed
PapayaWhip
PeachPuff
Peru
Pink
Plum
PowderBlue
Purple
Red
RosyBrown
RoyalBlue
SaddleBrown
Salmon
SandyBrown
SeaGreen
SeaShell
Sienna
Silver
SkyBlue
SlateBlue
SlateGray
Snow
SpringGreen
SteelBlue
Tan
Teal
Thistle
Tomato
Transparent
Turquoise
Violet
Wheat
White
WhiteSmoke
Yellow
YellowGreen
*/
