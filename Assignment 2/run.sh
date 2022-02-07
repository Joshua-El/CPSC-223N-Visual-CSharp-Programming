#!/bin/bash
#In the official documemtation the line above always has to be the first line of any script file.

#Author: Joshua Elmer
#Course: CPSC223n
#Semester: Fall 2020
#Assignment: 2
#Program title: Traffic Light

echo First remove old binary files
rm *.dll
rm *.exe

echo View the list of source files
ls -l

echo "Compile trafficlightuserinterface.cs to create the file: trafficlightuserinterface.dll"
mcs -t:library -r:System.Windows.Forms.dll -r:System.Drawing.dll -out:trafficlightuserinterface.dll trafficlightuserinterface.cs

echo "Compile trafficlightmain.cs and link the previously created dll file(s) to create an executable file."
mcs -r:System.Windows.Forms.dll -r:System.Drawing.dll -r:trafficlightuserinterface.dll -out:TrafficLight.exe trafficlightmain.cs

echo View the list of files in the current folder
ls -l

echo Run the Assignment 2 program.
./TrafficLight.exe

echo The script has terminated.
