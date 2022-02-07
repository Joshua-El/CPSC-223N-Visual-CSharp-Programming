#!/bin/bash
#In the official documemtation the line above always has to be the first line of any script file.

#Author: Joshua Elmer
#Course: CPSC223n
#Semester: Fall 2020
#Assignment: 4
#Program title: Ricochet

echo First remove old binary files
rm *.dll
rm *.exe

echo View the list of source files
ls -l

echo "Compile the file ricochetuserinterface.cs:"
mcs -target:library -r:System.Drawing.dll -r:System.Windows.Forms.dll -out:ricochetuserinterface.dll ricochetuserinterface.cs

echo "Compile and link ricochetmain.cs:"
mcs -r:System -r:System.Windows.Forms -r:ricochetuserinterface.dll -out:go.exe ricochetmain.cs

echo "Run the Ricochet program"
./go.exe

echo "The bash script has terminated."
