Simple C++ program to parse csv file and do some manipulations and save data to another csv
Sreelatha Polaki Oct.31st 2018

*** The CES_CodeTest folder contains the below files ***

dataanalyze.cpp (source file)
makefile (makefile for build)
dataanalyze.exe (generated output binary)
marketdata_for_interview.csv (input file)
analyzeddata.csv (generated output file)


*** To build the source on Windows ***

1. Set the path for g++ compiler
2. set the Boost library path (modify in makefile)
3. cmd> make

*** To Run the executable ***

cmd> dataanalyze.exe
It prompts for input file path ( please enter valid input file path )


*** Design and impementation ***
The source code used Boost library tokenizers to parse the CSV file and saved data to std::vector container. 
No specific design patterns followed for this application.
If the fields in csv modified then the program will not work as expected.
I have not used any object oriented programming in this application as the code is not designed for any file format.
I have tested the code only with the provided input .csv file without any modifications.

*** Build/Test Environment ***
OS: Windows 10 x64
Text Editor: Notepad++
compiler: gcc version 8.1.0 (GCC)