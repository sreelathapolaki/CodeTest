#include <iostream>     
#include <fstream>      
#include <vector>
#include <string>
#include <iterator>     
#include <map>
#include <cmath>
#include <sstream>
#include <iomanip> 
#include <windows.h>
#include <Shlwapi.h>

// boost library includes
#include <boost/tokenizer.hpp>
#include <boost/assign/list_of.hpp>
#include <boost/assign/std/vector.hpp>

using namespace std;
using namespace boost;

int main()
{
    string inFile, outFile;   
    pair <map<string, vector<string>>::const_iterator, bool> ret; 
	std::string::size_type sz;
    typedef tokenizer< escaped_list_separator<char> > Tokenizer;
    vector< string > vec;
	vector <string> outvec ;
    string fline, csvline, finalline;
	vector< string > finaloutvec;
	std::map<std::string, vector<std::string> > analyze;
	ofstream outdata;
	
	cout << "Please Enter input file name (include complete path, .csv format)" << endl;
	cin >> inFile;

	ifstream in(inFile.c_str());
    if (!in.is_open()) return 1; // Failed to open the file return from program

	// parse the csv file using boost tokenizer and then copy data to vector
    while (getline(in,fline))
    {
        Tokenizer tok(fline);
        vec.assign(tok.begin(),tok.end());
		if (vec.size() < 1) 
			continue;
   		long double bidval = std::stold(vec.at(2))*std::stoi(vec.at(5)) + std::stold(vec.at(4)) * std::stoi(vec.at(3)) ;
		csvline = vec.at(1) + " " + std::to_string(std::stod(vec.at(4))-std::stod(vec.at(2))) + " " + vec.at(6) + " " + vec.at(0)+ " " +  std::to_string( bidval ) + " " + std::to_string(std::stoi(vec.at(5))+std::stoi(vec.at(3)));
		outvec.push_back(csvline);
    }
	
	cout << "Total lines in csv are " << outvec.size() << endl; 
	std::sort (outvec.begin(), outvec.end()); // sort the vector based on tickers
	
	for (auto it = outvec.begin(); it != outvec.end(); it++) 
	{
     	vector<string> analyzevec;
		stringstream maxstream;
		stringstream minstream;
		stringstream askbidstream;
	
		std::string s = *it;
        std::stringstream ss(*it);
        std::istream_iterator<std::string> begin(ss);
        std::istream_iterator<std::string> end;
        std::vector<std::string> vstrings (begin, end);
	
		std::map<std::string, std::vector<std::string> >::const_iterator search = analyze.find (vstrings.at(0) );
		
		if(search != analyze.end()) 
		{
		 std::vector<std::string> s = search->second;
		  long double maxbid = std::max (std::stold(s.at(0), &sz), std::stold (vstrings.at(1), &sz) );
		  maxstream << fixed << setprecision(2) << maxbid;
          long double minbid = std::min (std::stold(s.at(1), &sz), std::stold (vstrings.at(1), &sz) ); 
		  minstream << fixed << setprecision(2) << minbid;
		  long long  vol = std::stoll (s.at(2), &sz) + std::stoll (vstrings.at(2), &sz); 
		  unsigned long  time = std::max(std::stoul (vstrings.at(3), &sz), std::stoul (s.at(3), &sz) );
		  int dtime = std::stol (vstrings.at(3), &sz) - std::stol (s.at(3), &sz);
		  int timediff = std::max (std::stoi (s.at(4), &sz), dtime);
          long double askbid = std::stold (s.at(5), &sz) + std::stold (vstrings.at(4), &sz);
		  askbidstream << fixed << setprecision(2) << askbid;
		  int asksize = std::stoi (s.at(6), &sz) + std::stoi (vstrings.at(5), &sz);
		  analyzevec.push_back (maxstream.str() ); 
		  analyzevec.push_back (minstream.str() );
		  analyzevec.push_back (std::to_string(vol) );
		  analyzevec.push_back (std::to_string(time));
		  analyzevec.push_back (std::to_string(timediff) );
		  analyzevec.push_back (askbidstream.str() ); 
		  analyzevec.push_back (std::to_string(asksize) );
	
		  analyze[vstrings.at(0)] = analyzevec;
     	}
		else
		{
			int timediff =0;
			analyzevec.push_back (vstrings.at(1) );
			analyzevec.push_back (vstrings.at(1) );
		    analyzevec.push_back (vstrings.at(2) );
		    analyzevec.push_back (vstrings.at(3) );
			analyzevec.push_back (std::to_string(timediff));
		    analyzevec.push_back (vstrings.at(4) );
		    analyzevec.push_back (vstrings.at(5) );
			analyze.insert( pair<string, vector<string> > (vstrings.at(0), analyzevec) );
		}
	}
	
   for(map<string,vector<string> >::iterator ii=analyze.begin(); ii!=analyze.end(); ++ii)
   {
       std::vector<std::string> vstrings(ii->second.begin(), ii->second.end());
	   long double avgbid = std::stold(vstrings.at(4))/std::stold(vstrings.at(5));
       finalline = (*ii).first + "," + vstrings.at(0) +" "+ vstrings.at(1) +","+vstrings.at(2) +","+ vstrings.at(4)+","+ std::to_string(avgbid); 
	   finaloutvec.push_back( finalline);
   }

   // Write the final analyzed data to csv file 
    char path[256];
	HMODULE hModule = GetModuleHandle(nullptr);
		if(hModule){
			GetModuleFileName(hModule,path,sizeof(path)); // get current working directory in windows os
			PathRemoveFileSpec(path);
			strcat(path,"\\");
		}
   strcat(path,"analyzeddata.csv");	
   outFile = std::string(path);   
   outdata.open(outFile);
   if (!outdata.is_open())
   {
		cout << "Failed to open file to write the data" << endl;
   }
   else
   {
		for (vector<string>::const_iterator val = finaloutvec.begin(); val != finaloutvec.end() ;++val)
		{
		   outdata << *val << endl; 
	    }
    }
 	outdata.close();
 
}