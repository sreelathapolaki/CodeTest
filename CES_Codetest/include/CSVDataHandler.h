#include<iostream>
#include <map>
#include <vector>
#include <string>
#include <iterator> 
#include <sstream>
#include <iomanip> 
#include <cmath>
#include <algorithm>
#include <boost/lexical_cast.hpp> 

using namespace std;
using namespace boost;
using boost::lexical_cast; 

namespace DataAnalyze
{
	class CSVDataHandler
	{
		public:
		       CSVDataHandler();
			   std::map<std::string, vector<std::string> > CSVDataReader(vector<string> vec);
		       vector<string> CSVAnalyze(std::map<std::string, vector<std::string>>);
			   ~CSVDataHandler();
			   void ParseCSVData(vector<string> vec);
			   std::string getTicker();
			   long double getBidDiff();
			   long double getBidCal();
			   long long getVolume();
			   unsigned long getTimestamp();
			   int getBidSizeTotal();
			   
		private:
		        void SortVector(vector<string>& vec);
				std::string ticker ;
				long double bidDiff;
				long double bidCal;
				long long volume;
				unsigned long timestamp;
				int bidsizeTotal;
				
				
	};
}