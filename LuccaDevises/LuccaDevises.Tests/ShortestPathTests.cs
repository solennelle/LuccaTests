using System.Collections.Generic;
using LuccaDevises.Exceptions;
using LuccaDevises.Models;
using Xunit;

namespace LuccaDevises.Tests
{
    public class ShortestPathTests
    {
        private readonly Dictionary<string, Dictionary<string, decimal>> graph = new Dictionary<string, Dictionary<string, decimal>>
        {
            { "AUD", new Dictionary<string, decimal> { { "CHF", 0.9661m } } },
            { "CHF", new Dictionary<string, decimal> { { "AUD", 1.0350m }, { "EUR", 0.8296m } } },
            { "EUR", new Dictionary<string, decimal> { { "CHF", 1.2053m } } }
        };

        [Fact]
        public void CalculateCurrencyReturnsCorrectRate()
        {
            // Setup

            var instructions = new Instructions
            {
                InitialCurrency = "AUD",
                Amount = 550,
                GoalCurrency = "EUR"
            };

            // Execution
            int result = ShortestPath.GetCurrencyExchange(graph, instructions);

            // Data
            Assert.Equal(441, result);
        }

        [Fact]
        public void UnchangedAmountIfStartAndFinishAreIdentical()
        {
            // Setup
            var instructions = new Instructions
            {
                InitialCurrency = "EUR",
                Amount = 550,
                GoalCurrency = "EUR"
            };

            // Execution
            int result = ShortestPath.GetCurrencyExchange(graph, instructions);

            // Data
            Assert.Equal(550, result);
        }

        [Fact]
        public void ReturnExceptionIfGoalIsntInCurrencyList()
        {
            var instructions = new Instructions
            {
                InitialCurrency = "KRW",
                Amount = 550,
                GoalCurrency = "EUR"
            };

            Assert.Throws<MissingCurrencyException>(() => ShortestPath.GetCurrencyExchange(graph, instructions));
        }
    }
}
