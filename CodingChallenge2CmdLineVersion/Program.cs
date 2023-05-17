using CodingChallenge.Library;
using System;

namespace CodingChallenge2CmdLineVersion
{
    class Program
    {
        static void Main(string[] args)
        {
            string argsString = string.Join(" ", args);
            IPileCalculationService pileCalculationService = new PileCalculationService();
            int boxesStackCount = pileCalculationService.GetTripsCount(argsString);
            Console.WriteLine("Just finished carrying {0} piles of boxes", boxesStackCount);
        }
    }
}
