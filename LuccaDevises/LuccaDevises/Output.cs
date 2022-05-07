using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using LuccaDevises.Models;

namespace LuccaDevises
{
    public class Output : IOutput
    {
        public void OnError (string message) {
            Console.WriteLine(message);
            Environment.Exit(1);
        }
    }
}