#include "CSVWriter.h"

namespace DataAnalyze
{
		
	string CSVWriter::GetCurrentDir()
	{
		char path[256];
		string outputFile;
		HMODULE hModule = GetModuleHandle(nullptr);
			if(hModule){
				GetModuleFileName(hModule,path,sizeof(path)); // get current working directory in windows os
				PathRemoveFileSpec(path);
				strcat(path,"\\");
			}
	   strcat(path,"analyzeddata.csv");	
	   outputFile = std::string(path);   
	   return outputFile;
	}
	
	void CSVWriter::WriteDataToCSV(vector<string> csvData)
	{
		string outFile = GetCurrentDir();
		ofstream outdata;
		
		// Write the final analyzed data to csv file 
		 outdata.open(outFile);
	   if (!outdata.is_open())
	   {
			cout << "Failed to open file to write the data" << endl;
	   }
	   else
	   {
			for (std::vector<string>::const_iterator data = csvData.begin(); data != csvData.end() ;++data)
			{
			   outdata << *data << endl; 
			}
			
		}
		outdata.close();
	}
	
	CSVWriter::~CSVWriter()
	{
		
	}

}