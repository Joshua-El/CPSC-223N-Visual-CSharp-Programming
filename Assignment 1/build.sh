
#Ruler:==1=========2=========3=========4=========5=========6=========7=========8=========9=========0=========1=========2=========3**
#Author: Joshua Elmer
#Course: CPSC223n
#Semester: Fall 2020
#Assignment: 1
#Due: October 10, 2020.




echo View the list of source files
ls -l

echo Compile Converterlogic.cs to create the file: Converterlogic.dll
mcs -target:library -out:Converterlogic.dll Converterlogic.cs

echo Compile Converteruserinterface.cs to create the file: Converteruserinterface.dll
mcs -target:library -r:System.Drawing.dll -r:System.Windows.Forms.dll -r:Converterlogic.dll -out:Converteruserinterface.dll Converteruserinterface.cs

echo Compile Convertermain.cs and link the two previously created dll files to create an executable file.
mcs -r:System -r:System.Windows.Forms -r:Converteruserinterface.dll -out:Conv.exe Convertermain.cs

echo View the list of files in the current folder
ls -l

echo Run the Assignment 1 program.
./Conv.exe

echo The script has terminated.
