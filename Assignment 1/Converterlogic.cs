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

//This file's name: Converterlogic.cs
//This file purpose: This file contains the alogrithm for converting the imperial number to the metric number
//Date last modified: 2020-Sept-27
//
//
public class Converterlogic
{
 public static double computemetricnumber(double imperialnum)
   {double conversionnum = 0.0254;
    double metricnum = imperialnum * conversionnum;

    return metricnum;
  }//End of computemetricnumber

}//End of Converterlogic
