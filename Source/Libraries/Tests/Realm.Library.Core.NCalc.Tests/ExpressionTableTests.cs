using System;
using System.Text.RegularExpressions;
using FluentAssertions;
using NCalc;
using Xunit;

namespace Realm.Library.Core.NCalc.Tests
{
    public class ExpressionTableTests
    {
        private static int FakeFunc(FunctionArgs args)
        {
            return 0;
        }
        private static string FakeReplaceFunc(Match regexMatch)
        {
            return string.Empty;
        }

        [Fact]
        public void Add_HasNoConflicts()
        {
            var table = new ExpressionTable();
            var expr = new CustomExpression
                           {
                               Name = "Test",
                               RegexPattern = "[0-9]",
                               ExpressionFunction = FakeFunc,
                               ReplacementFunction = FakeReplaceFunc
                           };

            Action add = () => table.Add(expr);
            add.Should().NotThrow<Exception>();
        }

        [Fact]
        public void Add_HasANameConflict_ThrowsException()
        {
            var table = new ExpressionTable();
            var expr1 = new CustomExpression
                            {
                                Name = "Test",
                                RegexPattern = "[0-9]",
                                ExpressionFunction = FakeFunc,
                                ReplacementFunction = FakeReplaceFunc
                            };

            table.Add(expr1);

            var expr2 = new CustomExpression
                            {
                                Name = "Test",
                                RegexPattern = "[0-9]",
                                ExpressionFunction = FakeFunc,
                                ReplacementFunction = FakeReplaceFunc
                            };

            Action add = () => table.Add(expr2);
            add.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Add_HasARegexConflict_ThrowsException()
        {
            var table = new ExpressionTable();
            var expr1 = new CustomExpression
                            {
                                Name = "Test",
                                RegexPattern = "[0-9]",
                                ExpressionFunction = FakeFunc,
                                ReplacementFunction = FakeReplaceFunc
                            };

            table.Add(expr1);

            var expr2 = new CustomExpression
                            {
                                Name = "Test1",
                                RegexPattern = "[0-9]",
                                ExpressionFunction = FakeFunc,
                                ReplacementFunction = FakeReplaceFunc
                            };

            Action add = () => table.Add(expr2);
            add.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Get_HasANameMatch_ReturnsValidResult()
        {
            var table = new ExpressionTable();
            var expr1 = new CustomExpression()
                            {
                                Name = "Test",
                                RegexPattern = "[0-9]",
                                ExpressionFunction = FakeFunc,
                                ReplacementFunction = FakeReplaceFunc
                            };

            table.Add(expr1);

            table.Get("Test").Should().Be(expr1);
        }

        [Fact]
        public void Get_HasARegexMatch_ReturnsValidResult()
        {
            var table = new ExpressionTable();
            var expr1 = new CustomExpression()
                            {
                                Name = "Test",
                                RegexPattern = "[0-9]",
                                ExpressionFunction = FakeFunc,
                                ReplacementFunction = FakeReplaceFunc
                            };

            table.Add(expr1);

            table.Get("[0-9]").Should().Be(expr1);
        }
    }
}
