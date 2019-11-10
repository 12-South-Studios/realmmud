using System;
using System.Text.RegularExpressions;
using NCalc;

namespace Realm.Library.Core.NCalc
{
    public class CustomExpression
    {
        public string Name { get; set; }
        public string RegexPattern { get; set; }
        public Regex Regex => new Regex(RegexPattern);
        public Func<FunctionArgs, int> ExpressionFunction { get; set; }
        public Func<Match, string> ReplacementFunction { get; set; }
    }
}
