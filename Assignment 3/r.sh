#!/bin/bash
#In the official documemtation the line above always has to be the first line of any script file.

#Author: Joshua Elmer
#Course: CPSC223n
#Semester: Fall 2020
#Assignment: 3
#Program title: Skateboarder

echo First remove old binary files
rm *.dll
rm *.exe

echo View the list of source files
ls -l

echo "Compile the file ninety-degree-ui.cs:"
mcs -target:library -r:System.Drawing.dll -r:System.Windows.Forms.dll -out:skateboarduserinterface.dll skateboarduserinterface.cs

echo "Compile and link ninety-degree-main.cs:"
mcs -r:System -r:System.Windows.Forms -r:skateboarduserinterface.dll -out:go.exe skateboardmain.cs

echo "Run the program Ninety Degree Turn"
./go.exe

echo "The bash script has terminated."
