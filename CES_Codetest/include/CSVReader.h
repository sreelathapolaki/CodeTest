#include <vector>
#include <string>
#include <iterator>  
#include <map>
#include <fstream> 
#include <iostream>
// boost library includes
#include <boost/tokenizer.hpp>
#include <boost/assign/list_of.hpp>
#include <boost/assign/std/vector.hpp>
#include <boost/lexical_cast.hpp> 


using namespace std;
using namespace boost;
using boost::lexical_cast; 

namespace DataAnalyze
{
	
	class CSVReader
	{
		public:
			CSVReader();
			CSVReader(std::string inFile);
	        void ReadCSVLine();
	     	long getTimeStamp();
			std::string getTicker();
			double getBid();
			int getBidSize();
			double getAsk();
			int getAskSize();
			long getVolume();
			void ParseCSVLine(vector<string>);
			
			vector<string> inputVec;
	        vector <string> outputVec;
			
			~CSVReader();
	private:
		    long  timestamp;
			std::string ticker;
			double bid;
			int bidSize;
			double ask;
			int askSize;
			long volume; 
			string inputFile;
			
	};
}