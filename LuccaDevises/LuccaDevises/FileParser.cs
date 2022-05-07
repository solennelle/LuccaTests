using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using LuccaDevises.Models;

namespace LuccaDevises
{
    public class FileParser : IFileParser
    {
        public IOutput Output {get;set;}
        public FileParser (IOutput output)
        {
            Output = output;
        }

        public InputFile ParseEntryFile(string filePath) {
            string[] entryFile = null;
            try
            {
               entryFile = File.ReadAllLines(filePath);
            }
            catch (FileNotFoundException)
            {
                Output.OnError($"No file with the name {filePath} has been found");
            }

            var entryList = new List<string>(entryFile);

            // Parse the input file for formatting errors
            ParseFileFormatting(entryList);

            var instructions = GetInstructions(entryFile[0]);
            var graph = GetGraph(entryList);

            return new InputFile {
                Instructions = instructions,
                RemainingLines = int.Parse(entryFile[1]),
                Graph = graph
            };
        }

        static public Instructions GetInstructions(string line) {
            var array = line.Split(";");
            return new Instructions
            {
                InitialCurrency = array[0],
                Amount = decimal.Parse(array[1]),
                GoalCurrency = array[2]
            };
        }

        static public Dictionary<string, Dictionary<string, decimal>> GetGraph(List<string> lines) {
            var graph = new Dictionary<string, Dictionary<string, decimal>>();


            // skips the first two lines of the List (instructions and remaining lines);
            foreach (var line in lines.Skip(2))
            {
                var array = line.Split(";");
                var listElement = new CurrencyListElement {
                    FromCurrency = array[0],
                    TargetCurrency = array[1],
                    Rate = decimal.Parse(array[2]),
                };

                // Creates a graph containing the keys and the currency: rate associated
                if (!graph.ContainsKey(listElement.FromCurrency)){
                    graph.Add(listElement.FromCurrency, new Dictionary<string, decimal>());
                }
                if (!graph.ContainsKey(listElement.TargetCurrency)){
                    graph.Add(listElement.TargetCurrency, new Dictionary<string, decimal>());
                }
                graph[listElement.FromCurrency][listElement.TargetCurrency] = listElement.Rate;
                graph[listElement.TargetCurrency][listElement.FromCurrency] = 1 / listElement.Rate;
            }
            return graph;
        }

        public void ParseFileFormatting(List<string> entryList) {
            // Parse of the first line with the instructions
            if (!Regex.IsMatch(entryList[0], @"^[a-zA-Z]{3};\d+;[a-zA-Z]{3}$")) {
                Output.OnError("The format of the first line must fit the format EUR;550;JPY");
            }

            // Parse the 2nd line's format
            if (!int.TryParse(entryList[1], out _)){
                Output.OnError("The format of the second line must be an integer");
            }

            int remainingLines = entryList.Count - 2;
            if (int.Parse(entryList[1]) != remainingLines) {
                Output.OnError("The number given in the 2nd line and the number of remaining lines don't match");
            }

            // Check the remaining lines' format
            for (int i = 0; i < remainingLines; i++) {
                if (!Regex.IsMatch(entryList[i + 2], @"^[a-zA-Z]{3};[a-zA-Z]{3};([0-9]+\.?[0-9]*|\.[0-9]+)$")) {
                    Output.OnError($"The line {entryList[i + 2]} does not match the required format 'EUR;JPY;1.021'");
                }
            }
        }
    }
}