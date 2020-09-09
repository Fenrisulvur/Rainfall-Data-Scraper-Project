using System;
using System.Collections;
using System.Net;
using Microsoft.VisualBasic.FileIO;

namespace Rainfall
{
    class DataBase
    {
        ArrayList data = new ArrayList(); //Where we store rainfall data for the session
        public DataBase() { //Constructor, initializies the 'DataBase' 
            GetCSV("http://ncei.noaa.gov/data/coop-hourly-precipitation/v2/access/AQC00914594.csv"); //url for the rainfall csv file
            
            using (TextFieldParser csvParser = new TextFieldParser(@"RainfallDB.csv"))
            {
                csvParser.CommentTokens = new string[] { "#" };
                csvParser.SetDelimiters(new string[] { "," });
                csvParser.HasFieldsEnclosedInQuotes = true;

                // Skip the row with the column names
                csvParser.ReadLine();
                while (!csvParser.EndOfData)
                {
                    // Read current line fields, pointer moves to the next line.
                    //Field 4 is the data in the csv file, field 126 is the "Daily Sum" of the rain in 1/100ths of an inch
                    string[] fields = csvParser.ReadFields();
                    string Date = fields[4];
                    string Rainfall = fields[126];
                    data.Add(new string[]{Date, Rainfall}); //We add the stripped data to the arraylist, tossing unneeded fields
                }
            }
        }
        public void GetCSV(string url)
        {
            WebClient webClient = new WebClient();
            webClient.DownloadFile(url, "RainfallDB.csv"); //download file to root dir of project
        }
        public string getRainfall(string searchDate) //search every table in data and return entry at specified data if existing
        {
            string result = "No data found."; //Default return string if no data is found

            foreach(string[] entry in data){
                if (entry[0] == searchDate){

                    double Rainfall = double.Parse(entry[1]); //this could be done in the file reader when creating the table
                    Rainfall = Rainfall/100; // convert from 1/100ths to inches

                    result = string.Format("Date: {0} Rainfall sum: {1} Inches", entry[0],Rainfall); //format data
                    break; //No need to check further results
                }
            }
            return result; //return data
        }
    }
}