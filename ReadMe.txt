Simple C++ program to parse csv file and do some manipulations and save data to another csv
Sreelatha Polaki Oct.31st 2018

*** The CES_CodeTest folder contains the below files ***

include/CSVReader.h
include/CSVDataHandler.h
include/CSVWriter.h
src/CSVReader.cpp
src/CSVDataHandler.cpp
src/CSVWriter.cpp

makefile (makefile for build)
CSVDataParser.exe (generated output binary)
marketdata_for_interview.csv (input file)
analyzeddata.csv (generated output file)
DesignDoc.docx (Design document)

*** To build the source on Windows ***

1. Set the path for g++ compiler
2. set the Boost library path (modify in makefile)
3. cmd> make

*** To Run the executable ***

cmd> CSVDataParser.exe
It prompts for input file path ( please enter valid input file path )


*** Design and impementation ***

The source code used Boost library tokenizers to parse the CSV file and saved data to std::vector container. 

Please refer the DesignDoc.docx for the high level design of the program

If the fields in csv modified (remove/change order) then the program will work as expected.
I have used Some base classes for CSV Reading/Parsing/Writing to make the modification easy if any changes in CSV fields.
I have tested the code with the provided input .csv file and also with by the order of fields and remove some of the fields.

*** Build/Test Environment ***
OS: Windows 10 x64
Text Editor: Notepad++
compiler: gcc version 8.1.0 (GCC)


*** Time calculations ***

Design - 8 hours
Code/Implementation - 6 hours
Testing - 2 hours 