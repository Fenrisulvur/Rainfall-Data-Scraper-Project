using System;

namespace Rainfall
{
    class Program
    {
        static void Main(string[] args)
        {
            DataBase dataBase = new DataBase(); 

            bool loop = true;

            while (loop){
                string response = InputCon.getInput("Input date to access. format: MM/DD/YYYY");
                Console.WriteLine("Search result: "+ dataBase.getRainfall(response));
                loop = InputCon.getRetry();
            }
        }
    }
}
