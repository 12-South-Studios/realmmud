using System;
using System.Linq;
using System.Text.RegularExpressions;
using NCalc;

namespace Realm.Library.Core.NCalc
{
    public class ExpressionParser
    {
        private readonly ExpressionTable _expressionTable;

        public ExpressionParser() { }

        public ExpressionParser(ExpressionTable exprTable)
        {
            _expressionTable = exprTable;
        }

        public int Execute(string expr)
        {
            if (string.IsNullOrEmpty(expr)) throw new ArgumentNullException();

            var newExpr = ReplaceExpressionMatches(expr);

            var exp = new Expression(newExpr);
            exp.EvaluateFunction += OnExpOnEvaluateFunction;

            var result = exp.Evaluate();

            int.TryParse(result.ToString(), out var outResult);
            return outResult;
        }

        private void OnExpOnEvaluateFunction(string name, FunctionArgs args)
        {
            var customExpr = _expressionTable?.Get(name);
            if (customExpr?.ExpressionFunction != null)
                args.Result = customExpr.ExpressionFunction.Invoke(args);
        }

        private string ReplaceExpressionMatches(string expr)
        {
            if (_expressionTable == null || !_expressionTable.Keys.Any())
                return expr;

            var newStr = expr;
            foreach (var customExpr in _expressionTable.Values)
            {
                var regex = customExpr.Regex;
                var originalLength = newStr.Length;
                var lengthOffset = 0;

                foreach (Match match in regex.Matches(newStr))
                {
                    var firstPart = newStr.Substring(0, match.Index + lengthOffset);
                    var secondPart = newStr.Substring(match.Index + lengthOffset + match.Length,
                                                         newStr.Length - (match.Index + lengthOffset + match.Length));
                    newStr = firstPart + customExpr.ReplacementFunction.Invoke(match) + secondPart;
                    lengthOffset = newStr.Length - originalLength;
                }
            }

            return newStr;
        }
    }
}
