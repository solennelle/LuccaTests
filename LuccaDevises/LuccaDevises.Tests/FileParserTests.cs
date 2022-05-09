using System.Collections.Generic;
using LuccaDevises.Exceptions;
using LuccaDevises.Models;
using Xunit;

namespace LuccaDevises.Tests
{
    public class FileParserTests
    {
        [Fact]
        public void ReturnExceptionIfIncorrectFirstLineFormat()
        {
            var entryList = new List<string> {
                "EXCEPTION;550;EUR",
                "2",
                "AUD;CHF;0.9661",
                "EUR;CHF;1.2053"
            };
            Assert.Throws<InvalidFormatException>(() => FileParser.ParseFileFormatting(entryList));
        }

        [Fact]
        public void ReturnExceptionIfIncorrectSecondLineFormat()
        {
            var entryList = new List<string> {
                "AUD;550;EUR",
                "4",
                "AUD;CHF;0.9661",
                "EUR;CHF;1.2053"
            };

            Assert.Throws<InvalidFormatException>(() => FileParser.ParseFileFormatting(entryList));
        }

        [Fact]
        public void ReturnExceptionIfIncorrectCurrencyListFormat()
        {
            var entryList = new List<string> {
                "AUD;550;EUR",
                "2",
                "AUD,CHF,0.9661",
                "EUR,CHF,1.2053"
            };

            Assert.Throws<InvalidFormatException>(() => FileParser.ParseFileFormatting(entryList));
        }
    }
}
