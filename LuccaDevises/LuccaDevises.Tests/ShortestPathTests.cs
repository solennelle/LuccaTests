using System.Collections.Generic;
using LuccaDevises.Models;
using Xunit;

namespace LuccaDevises.Tests
{
    public class ShortestPathTests
    {
        [Fact]
        public void CalculateCurrencyReturnsCorrectRate()
        {
            // Setup
            var graph = new Dictionary<string, Dictionary<string, decimal>>
            {
                { "AUD", new Dictionary<string, decimal> { { "CHF", 0.9661m }, { "JPY", 86.0305m } } },
                { "CHF", new Dictionary<string, decimal> { { "AUD", 1.0350895352447986750853948867m }, { "EUR", 0.8296689620841284327553306231m } } },
                { "JPY", new Dictionary<string, decimal> { { "KRW", 13.1151m }, { "AUD", 0.0116237845880240147389588576m } } },
                { "KRW", new Dictionary<string, decimal> { { "JPY", 0.076247988959291198694634429m } } },
                { "EUR", new Dictionary<string, decimal> { { "CHF", 1.2053m }, { "USD", 1.2989m } } },
                { "USD", new Dictionary<string, decimal> { { "EUR", 0.7698822080221726075910385711m } } },
                { "INR", new Dictionary<string, decimal> { { "JPY", 1.5218383807639628671435093593m } } }
            };

            var instructions = new Instructions
            {
                InitialCurrency = "EUR",
                Amount = 550,
                GoalCurrency = "JPY"
            };

            // Execution
            int result = ShortestPath.GetCurrencyExchange(graph, instructions);

            // Data
            Assert.Equal(59033, result);
        }
    }
}
