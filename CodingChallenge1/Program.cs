using System;

namespace CodingChallenge1
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowCount = 0;
            do
            {
                rowCount = int.TryParse(Console.ReadLine(), out int rowCountParsed) ? rowCountParsed : 0;
                if (rowCount < 1 || rowCount > 100)
                { 
                    Console.WriteLine("Please input an integer from 1 to 100");
                    continue;
                }

                for (int ctr = 0; ctr < rowCount; ctr++)
                {
                    Console.WriteLine("Please enter a phrase of multiple words");
                    string inputPhrase =  Console.ReadLine();
                    string[] phraseWords = inputPhrase.Split(" ");
                    Array.Reverse(phraseWords, 0, phraseWords.Length);
                    string reversedPhrase = string.Join(' ', phraseWords);
                    Console.WriteLine(reversedPhrase);
                }
                
            } while (rowCount < 1 || rowCount > 100);
        }
    }
}
