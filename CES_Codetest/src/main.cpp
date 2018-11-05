#include <iostream>
#include<map>
#include<vector>
#include "CSVReader.h"
#include "CSVWriter.h"
#include "CSVDataHandler.h"

using namespace std;
using namespace DataAnalyze;

int main()
{
	string inFile;
	 
	std::map<std::string, vector<std::string> > analyzemap;
	vector<string> finalOutVec;
	CSVWriter cw;
	cout << "Please Enter input file name (include complete path, .csv format)" << endl;
	cin >> inFile;

	CSVReader cr(inFile);
	cr.ReadCSVLine();
	CSVDataHandler dh;
	analyzemap = dh.CSVDataReader(cr.outputVec);
	finalOutVec = dh.CSVAnalyze(analyzemap);
	cw.WriteDataToCSV(finalOutVec);
	
}
	