using System;
using LuccaDevises.Models;

namespace LuccaDevises
{
    static class Program
    {
        static void Main(string[] args)
        {
            try {
                if (args.Length != 1) {
                    throw new ArgumentException("One argument is needed");
                }

                var ParsedFile = FileParser.ParseEntryFile(args[0]);

                var finalRate = ShortestPath.GetCurrencyExchange(ParsedFile.Graph, ParsedFile.Instructions);

                Console.WriteLine($"Le résultat est: {finalRate}");
            } catch (Exception ex) {
                Console.Error.WriteLine(ex.Message);
                Environment.Exit(1);
            }
        }
    }
}
