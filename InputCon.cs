using System;

namespace Rainfall
{
    static class InputCon
    {
        public static string getInput(string message) //get user input
        {
            Console.WriteLine(message);
            bool run = true;
            DateTime result = DateTime.MinValue;
    
            while(run){
                string userInput = Console.ReadLine();
                DateTime.TryParse(userInput, out result);
                if(!result.Equals(DateTime.MinValue))
                    break;
                Console.WriteLine("Invalid format, please try again. format: MM/DD/YYYY");
            }

            return result.ToString("yyyy-MM-dd");

        }
        public static bool getRetry() //get retry response
        {
            Console.WriteLine("Access another record? press [y/N]");

            ConsoleKeyInfo response = Console.ReadKey();
            char answer = response.KeyChar;
            if (answer == 'y'){
                Console.WriteLine();
                return true;
            } else {
                return false;
            }
        }
    }
}