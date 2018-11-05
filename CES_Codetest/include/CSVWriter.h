#include <iostream> 
#include <vector>
#include <map>
#include <fstream> 
#include <windows.h>
#include <Shlwapi.h>

using namespace std;

namespace DataAnalyze
{
	class CSVWriter
	{
		public:
			   void WriteDataToCSV(vector<string> vec);
			   ~CSVWriter();
		private:
			   string GetCurrentDir();
	};
}