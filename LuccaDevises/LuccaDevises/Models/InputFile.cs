using System.Collections.Generic;

namespace LuccaDevises.Models
{
    public class InputFile {
        public Instructions Instructions {get; set;}
        public int RemainingLines {get;set;}
        public Dictionary<string, Dictionary<string, decimal>> Graph {get; set;}
    }
}