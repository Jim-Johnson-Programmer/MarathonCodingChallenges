using System;
using System.Text.RegularExpressions;
using CodingChallenge.Library;

namespace CodingChallenge2
{
    //do bonus build where input is args to program.
    class Program
    {
        static void Main(string[] args)
        {
            string inputArgs = GetUserInput();
            IPileCalculationService pileCalculationService = new PileCalculationService();
            int pileTotal = pileCalculationService.GetTripsCount(inputArgs);
            Console.WriteLine("Finished carrying {0} piles of boxes", pileTotal);
        }
        
        private static string GetUserInput()
        {
            string regExString = "^([1-9]|[0-9]+[0-9]|100) [1-5] [2-5]$";
            Regex regEx = new Regex(regExString);
            bool repeatLoop = false;
            string inputArgs = string.Empty;
            Console.WriteLine("Please enter a given pile size (1-100), max pile size (1-5), and multiple trip pile quota (2-5) separated by spaces.");
            do
            {
                //number, max pile size, split pile count                
                inputArgs = Console.ReadLine();
                if (!regEx.IsMatch(inputArgs))
                {
                    Console.WriteLine("Please enter 3 integers separated by spaces, pile size must be 1 to 100, max pile height must be 1 to 5, multiple pile quota must be 2 to 5");
                    repeatLoop = true;
                    continue;
                }
                repeatLoop = false;
            } while (repeatLoop);
            return inputArgs;
        }
    }
}
