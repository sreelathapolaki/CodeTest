#include "CSVReader.h"


namespace DataAnalyze
{
	typedef tokenizer< escaped_list_separator<char> > Tokenizer;
	vector<string> headervec;
	map<string, int> headermap;
	
	CSVReader::CSVReader()
	{
		
	}
	
	CSVReader::CSVReader(string inFile)
	{
		string fline;
		Tokenizer tok(fline);
		vector<string> vec;
		
		string line ;
		inputFile = inFile;
		ifstream in(inputFile.c_str());
		if (in.is_open())
		{
			getline(in, fline);
			tokenizer<escaped_list_separator<char> > tk(fline, escaped_list_separator<char>('\\', ',', '\"'));
			for (tokenizer<escaped_list_separator<char> >::iterator i(tk.begin());
			   i!=tk.end();++i) 
			{
			   headervec.push_back(*i);
			}
            int index =0;
			for (auto it = headervec.begin(); it != headervec.end(); it++) 
			{
				headermap.insert(pair<string, int>(*it, index));
				index ++;
			}

			// parse the csv file using boost tokenizer and then copy data to vector
			while (getline(in, fline))
			{
				Tokenizer tok(fline);
				const auto n = std::distance( tok.begin(), tok.end() );
				vec.assign(tok.begin(), tok.end());
				if (vec.size() < 1)
					continue;
				for (int i=0;i<n;i++)
				{
					line = line + vec.at(i) + " ";
				}
				inputVec.push_back(line);
				line="";
			}
		}
	}
	
	void CSVReader::ReadCSVLine()
	{
		string line;
		std::string csvline;
		std::map<std::string, vector<std::string> > analyze;

		for (auto it = inputVec.begin(); it != inputVec.end(); it++) 
		{
			std::string s = *it;
			std::stringstream ss(*it);
			std::istream_iterator<std::string> begin(ss);
			std::istream_iterator<std::string> end;
			std::vector<std::string> vstrings (begin, end);
			ParseCSVLine(vstrings);
			long double bidval = getBid() * getAskSize() + getAsk() * getBidSize();
			csvline = getTicker() + " " + std::to_string(getAsk() - getBid()) + " " + std::to_string(getVolume()) + " " + std::to_string(getTimeStamp())+ " " +  std::to_string( bidval ) + " " + std::to_string(getAskSize() + getBidSize());
			outputVec.push_back(csvline);
		}
	}
	
	long CSVReader::getTimeStamp()
	{
		return timestamp;
	}

	std::string CSVReader::getTicker()
	{
		return ticker;
	}
	
	double CSVReader::getBid()
	{
		return bid;
	}
	
	int CSVReader::getBidSize()
	{
		return bidSize;
	}
	
	double CSVReader::getAsk()
	{
		return ask;
	}

	int CSVReader::getAskSize()
	{
		return askSize;
	}
	long CSVReader::getVolume()
	{
		return volume;
	}

	void CSVReader::ParseCSVLine(vector<string> vec)
	{
		
		std::map<std::string, int>::const_iterator ts = headermap.find ("Timestamp");
		if(ts != headermap.end()) 
		{
			timestamp=boost::lexical_cast<long>(vec.at(ts->second));
		}
		std::map<std::string, int>::const_iterator tk = headermap.find ("Ticker");
		if(tk != headermap.end()) 
		{
			ticker = vec.at(tk->second);
		}
		std::map<std::string, int>::const_iterator bd = headermap.find ("Bid");
		if(bd != headermap.end()) 
		{
			bid = boost::lexical_cast<double>(vec.at(bd->second));
		}
		std::map<std::string, int>::const_iterator bs = headermap.find ("BidSize");
	    if(bs != headermap.end()) 
		{
			bidSize =boost::lexical_cast<int>(vec.at(bs->second));
		}
		std::map<std::string, int>::const_iterator ak = headermap.find ("Ask");
	    if(ak != headermap.end()) 
		{
				ask=boost::lexical_cast<double>(vec.at(ak->second));
		}
		std::map<std::string, int>::const_iterator as = headermap.find ("AskSize");
	    if(as != headermap.end()) 
		{
			askSize = boost::lexical_cast<int>(vec.at(as->second)); 
		}
		std::map<std::string, int>::const_iterator vol = headermap.find ("Volume");
	    if(vol != headermap.end()) 
		{
				volume = boost::lexical_cast<long>(vec.at(vol->second));
		}
	}
	
	CSVReader::~CSVReader()
	{
		
	}
}