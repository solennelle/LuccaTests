using System;
using LuccaDevises.Models;

namespace LuccaDevises
{
    static class Program
    {
        static void Main(string[] args)
        {
            IOutput output = new Output();
            if (args.Length != 1) {
                output.OnError("A file path is needed to start the app");
            }

            IFileParser fileParser = new FileParser(output);
            InputFile ParsedFile = fileParser.ParseEntryFile(args[0]);
            Console.WriteLine(ShortestPath.GetCurrencyExchange(ParsedFile.Graph, ParsedFile.Instructions));
        }
    }
}
