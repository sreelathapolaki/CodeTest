#include "CSVDataHandler.h"
#include "CSVReader.h"

namespace DataAnalyze
{

    CSVDataHandler::CSVDataHandler()
	{
		
	}

	std::map<std::string, vector<std::string> > CSVDataHandler::CSVDataReader(vector<string> vec)
	{
		std::map<std::string, vector<std::string> > analyze;
		SortVector(vec);
		for (auto it = vec.begin(); it != vec.end(); it++) 
		{
			std::string::size_type sz;
			vector<string> analyzevec;
			stringstream maxstream;
			stringstream minstream;
			stringstream askbidstream;
			std::string s = *it;
			std::stringstream ss(*it);
			std::istream_iterator<std::string> begin(ss);
			std::istream_iterator<std::string> end;
			std::vector<std::string> vstrings (begin, end);
			ParseCSVData(vstrings);
			std::map<std::string, std::vector<std::string> >::const_iterator search = analyze.find (ticker);
			
			if(search != analyze.end()) 
			{
			 std::vector<std::string> s = search->second;
			  long double maxbid = std::max (std::stold(s.at(0), &sz), bidDiff );
			  maxstream << fixed << setprecision(2) << maxbid;
			  long double minbid = std::min (std::stold(s.at(1), &sz), bidDiff ); 
			  minstream << fixed << setprecision(2) << minbid;
			  long long  vol = std::stoll (s.at(2), &sz) + volume; 
			  unsigned long  time = std::max(timestamp, std::stoul (s.at(3), &sz) );
			  int dtime = std::stol (vstrings.at(3), &sz) - std::stol (s.at(3), &sz);
			  int timediff = std::max (std::stoi (s.at(4), &sz), dtime);
			  long double askbid = std::stold (s.at(5), &sz) + bidCal;
			  askbidstream << fixed << setprecision(2) << askbid;
			  int asksize = std::stoi (s.at(6), &sz) + bidsizeTotal;
			  analyzevec.push_back (maxstream.str() ); 
			  analyzevec.push_back (minstream.str() );
			  analyzevec.push_back (std::to_string(vol) );
			  analyzevec.push_back (std::to_string(time));
			  analyzevec.push_back (std::to_string(timediff) );
			  analyzevec.push_back (askbidstream.str() ); 
			  analyzevec.push_back (std::to_string(asksize) );
			  analyze[ticker] = analyzevec;
			}
			else
			{
				int timediff =0;
				analyzevec.push_back (std::to_string(bidDiff));
				analyzevec.push_back (std::to_string(bidDiff));
				analyzevec.push_back (std::to_string(volume));
				analyzevec.push_back (std::to_string(timestamp) );
				analyzevec.push_back (std::to_string(timediff));
				analyzevec.push_back (std::to_string(bidCal));
				analyzevec.push_back (std::to_string(bidsizeTotal));
				analyze.insert( pair<string, vector<string> > (ticker, analyzevec) );
			}
		}
		return analyze;
	}

	vector<string> CSVDataHandler::CSVAnalyze(std::map<std::string, vector<std::string>> analyzedMap)
	{
	   vector< string > finaloutvec;
	   string line;
	   for(map<string,vector<string> >::iterator ii=analyzedMap.begin(); ii!=analyzedMap.end(); ++ii)
	   {
		   std::vector<std::string> vstrings(ii->second.begin(), ii->second.end());
		   long double avgbid = std::stold(vstrings.at(4))/std::stold(vstrings.at(5));
		   line = (*ii).first + "," + vstrings.at(0) +","+ vstrings.at(1) +","+vstrings.at(2) +","+ vstrings.at(4)+","+ std::to_string(avgbid); 
		   finaloutvec.push_back( line);
	   }
	   
	   return finaloutvec;
	}
	
	void CSVDataHandler::SortVector(vector<string>& vec)
	{
		std::sort (vec.begin(), vec.end());
	}
	
	void CSVDataHandler::ParseCSVData(vector<string> vec)
	{
		ticker = vec.at(0);
		bidDiff = boost::lexical_cast<long double>(vec.at(1));
		bidCal = boost::lexical_cast<long double>(vec.at(4));
		volume = boost::lexical_cast<long long>(vec.at(2));
		timestamp =  boost::lexical_cast<unsigned long>(vec.at(3));
		bidsizeTotal = boost::lexical_cast<int>(vec.at(5));
	}
    
	std::string CSVDataHandler::getTicker()
    {
		return ticker;
    }
	
	long double CSVDataHandler::getBidDiff()
	{
		return bidDiff;
	}
	
	 long double CSVDataHandler::getBidCal()
	 {
		 return bidCal;
	 }
	
	 long long CSVDataHandler::getVolume()
	 {
		 return volume;
	 }
	
	unsigned long CSVDataHandler::getTimestamp()
	{
		return timestamp;
	}
	
	int CSVDataHandler::getBidSizeTotal()
	{
		return bidsizeTotal;
	}
	
	CSVDataHandler::~CSVDataHandler()
	{
		
		
	}
}