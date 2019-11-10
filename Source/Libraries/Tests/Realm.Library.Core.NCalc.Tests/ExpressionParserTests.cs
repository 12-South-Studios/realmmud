using System;
using System.Text.RegularExpressions;
using FluentAssertions;
using NCalc;
using Xunit;

namespace Realm.Library.Core.NCalc.Tests
{
    public class ExpressionParserTests
    {
        [Theory]
        [InlineData("4", 4)]
        [InlineData("5", 5)]
        public void Execute_SingleValue(string expression, int expected)
        {
            var parser = new ExpressionParser();
            parser.Execute(expression).Should().Be(expected);
        }

        [Theory]
        [InlineData("4+1", 5)]
        [InlineData("4+5+1", 10)]
        public void Execute_AddsValues(string expression, int expected)
        {
            var parser = new ExpressionParser();
            parser.Execute(expression).Should().Be(expected);
        }

        [Theory]
        [InlineData("4-1", 3)]
        [InlineData("4-1-2", 1)]
        public void Execute_SubtractsValues(string expression, int expected)
        {
            var parser = new ExpressionParser();
            parser.Execute(expression).Should().Be(expected);
        }

        [Theory]
        [InlineData("4*2", 8)]
        [InlineData("4*2*2", 16)]
        public void Execute_MultipliesValues(string expression, int expected)
        {
            var parser = new ExpressionParser();
            parser.Execute(expression).Should().Be(expected);
        }

        [Theory]
        [InlineData("4/2", 2)]
        [InlineData("4/2/2", 1)]
        public void Execute_DividesValues(string expression, int expected)
        {
            var parser = new ExpressionParser();
            parser.Execute(expression).Should().Be(expected);
        }

        [Theory]
        [InlineData("4+2-3", 3)]
        [InlineData("(4+2)/3+10", 12)]
        public void Execute_MixedOperations(string expression, int expected)
        {
            var parser = new ExpressionParser();
            parser.Execute(expression).Should().Be(expected);
        }

        private static int RollFunction(FunctionArgs args)
        {
            var t = DateTime.UtcNow - new DateTime(1970, 1, 1);
            var random = new Random(Convert.ToInt32(t.TotalSeconds));

            return random.Next((int)args.Parameters[0].Evaluate(), (int)args.Parameters[1].Evaluate());
        }

        private static string ReplaceRollCall(Match regexMatch)
        {
            return
                $"Roll({(string.IsNullOrEmpty(regexMatch.Groups[1].Value) ? "1" : regexMatch.Groups[1].Value)}, {regexMatch.Groups[3].Value})";
        }

        [Theory]
        [InlineData("2d6", 2, 12)]
        [InlineData("Roll(2, 6)", 2, 12)]
        [InlineData("2d6+4", 6, 16)]
        [InlineData("2d6+4+1d10", 7, 26)]
        [InlineData("d10", 1, 10)]
        public void Execute_StandardDiceFormat(string expression, int minExpected, int maxExpected)
        {
            var table = new ExpressionTable();
            table.Add(new CustomExpression
                          {
                              Name = "Roll",
                              RegexPattern = @"([0-9]+)?(d|D)([0-9]+)",
                              ExpressionFunction = RollFunction,
                              ReplacementFunction = ReplaceRollCall
                          });

            var parser = new ExpressionParser(table);

            var result = parser.Execute(expression);
            result.Should().BeGreaterOrEqualTo(minExpected);
            result.Should().BeLessOrEqualTo(maxExpected);
        }

        private static int NumberFunction(FunctionArgs args)
        {
            return 18;
        }
        private static string ReplaceNumberCall(Match regexMatch)
        {
            return "Number()";
        }

        [Theory]
        [InlineData("N", 18, 18)]
        [InlineData("N+5", 23, 23)]
        [InlineData("5+N+N+25", 66, 66)]
        [InlineData("2*N", 36, 36)]
        public void Execute_CustomFunction(string expression, int minExpected, int maxExpected)
        {
            var table = new ExpressionTable();
            table.Add(new CustomExpression
                          {
                              Name = "Number",
                              RegexPattern = @"^?\b\w*[n|N]\w*\b$?",
                              ExpressionFunction = NumberFunction,
                              ReplacementFunction = ReplaceNumberCall
                          });

            var parser = new ExpressionParser(table);

            var result = parser.Execute(expression);
            result.Should().BeGreaterOrEqualTo(minExpected);
            result.Should().BeLessOrEqualTo(maxExpected);
        }

        [Theory]
        [InlineData("2d6+N", 20, 30)]
        [InlineData("N+2d6+Number", 38, 48)]
        [InlineData("2d6+N+(2d4*10)", 40, 70)]
        public void Execute_MixedFunctions(string expression, int minExpected, int maxExpected)
        {
            var table = new ExpressionTable();
            table.Add(new CustomExpression
                          {
                              Name = "Roll",
                              RegexPattern = @"([0-9]+)?(d|D)([0-9]+)",
                              ExpressionFunction = RollFunction,
                              ReplacementFunction = ReplaceRollCall
                          });
            table.Add(new CustomExpression
                          {
                              Name = "Number",
                              RegexPattern = @"^?\b\w*[n|N]\w*\b$?",
                              ExpressionFunction = NumberFunction,
                              ReplacementFunction = ReplaceNumberCall
                          });

            var parser = new ExpressionParser(table);

            var result = parser.Execute(expression);
            result.Should().BeGreaterOrEqualTo(minExpected);
            result.Should().BeLessOrEqualTo(maxExpected);
        }
    }
}
