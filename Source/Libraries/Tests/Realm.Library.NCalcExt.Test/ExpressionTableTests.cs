using System;
using System.Text.RegularExpressions;
using NCalc;
using NUnit.Framework;

namespace Realm.Library.NCalcExt.Test
{
    [TestFixture]
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

        [Test]
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

            Assert.DoesNotThrow(() => table.Add(expr), "Unit Test expected no exceptions to be thrown!");
        }

        [Test]
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

            Assert.Throws<ArgumentException>(() => table.Add(expr2), 
                "Unit Test expected an ArgumentException to be thrown!");
        }

        [Test]
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

            Assert.Throws<ArgumentException>(() => table.Add(expr2),
                "Unit Test expected an ArgumentException to be thrown!");
        }

        [Test]
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

            Assert.That(table.Get("Test"), Is.EqualTo(expr1));
        }

        [Test]
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

            Assert.That(table.Get("[0-9]"), Is.EqualTo(expr1));
        }
    }
}
