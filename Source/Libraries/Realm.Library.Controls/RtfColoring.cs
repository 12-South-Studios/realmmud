using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace Realm.Library.Controls
{
    /// <summary>
    /// enabes syntaxhighlighting for a richtextbox by using rtf
    /// </summary>
    public static class RtfColoring
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="richTextBox"></param>
        public static void ProcessRtfColoring(this SyntaxRichTextBox richTextBox)
        {
            if (richTextBox == null)
                throw new ArgumentNullException(nameof(richTextBox));

            var settings = richTextBox.Settings;
            if (settings.Keywords.Count < 1)
                return;

            // reset the text to get a clear rtf
            var strTextToAdd = richTextBox.Text;
            richTextBox.Clear();
            richTextBox.AppendText(strTextToAdd);
            var strRtf = richTextBox.Rtf;

            // find index of start of header
            var iRtfLoc = strRtf.IndexOf("\\rtf", StringComparison.Ordinal);

            // get index of where we'll insert the colour table
            // try finding opening bracket of first property of header first
            var iInsertLoc = strRtf.IndexOf('{', iRtfLoc);

            // if there is no property, we'll insert colour table
            // just before the end bracket of the header
            if (iInsertLoc == -1) iInsertLoc = strRtf.IndexOf('}', iRtfLoc) - 1;

            var strCommentColor =
                $"\\red{settings.CommentColor.R.ToString(CultureInfo.InvariantCulture)}\\green{settings.CommentColor.G.ToString(CultureInfo.InvariantCulture)}\\blue{settings.CommentColor.B.ToString(CultureInfo.InvariantCulture)}";

            var strStringColor =
                $"\\red{settings.StringColor.R.ToString(CultureInfo.InvariantCulture)}\\green{settings.StringColor.G.ToString(CultureInfo.InvariantCulture)}\\blue{settings.StringColor.B.ToString(CultureInfo.InvariantCulture)}";

            var strKeywordColor =
                $"\\red{settings.KeywordColor.R.ToString(CultureInfo.InvariantCulture)}\\green{settings.KeywordColor.G.ToString(CultureInfo.InvariantCulture)}\\blue{settings.KeywordColor.B.ToString(CultureInfo.InvariantCulture)}";

            var strIntegerColor =
                $"\\red{settings.IntegerColor.R.ToString(CultureInfo.InvariantCulture)}\\green{settings.IntegerColor.G.ToString(CultureInfo.InvariantCulture)}\\blue{settings.IntegerColor.B.ToString(CultureInfo.InvariantCulture)}";

            // insert the colour table at our chosen location
            strRtf = strRtf.Insert(iInsertLoc,
                $"{{\\colortbl ;{strCommentColor};{strStringColor};{strKeywordColor};{strIntegerColor};}}");

            // build the keywords regex
            var strKeywords = settings.Keywords.Aggregate(string.Empty, (current, keyword) => current + keyword + ",");
            strKeywords = strKeywords.Substring(0, strKeywords.Length - 1);

            var r = new Regex(@", ?");
            strKeywords = $@"\b({r.Replace(strKeywords, @"|")})\b";

            // start coloring
            // Keywords
            r = new Regex(strKeywords, RegexOptions.Singleline | RegexOptions.IgnoreCase);
            strRtf = r.Replace(strRtf, MatchKeyword);

            // Integers
            r = new Regex("(\\b(?:[0-9]*\\.)?[0-9]+\\b)", RegexOptions.IgnoreCase);
            strRtf = r.Replace(strRtf, MatchInteger);

            // Comments
            r = new Regex($"({settings.Comment}.*$)", RegexOptions.Multiline | RegexOptions.IgnoreCase);
            strRtf = r.Replace(strRtf, MatchComment);

            // Strings
            r = new Regex("(\"[^\"\\\\\\r\\n]*(?:\\\\.[^\"\\\\\\r\\n]*)*\"|\'[^\'\\\\\\r\\n]*(?:\\\\.[^\'\\\\\\r\\n]*)*\')", RegexOptions.Singleline | RegexOptions.IgnoreCase);
            strRtf = r.Replace(strRtf, MatchString);

            richTextBox.Rtf = strRtf;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        private static string MatchKeyword(Match match)
        {
            return match.Groups[1].Success
                ? $@"\cf3 {RemoveRtfColors(match.Value)}\cf0 "
                : string.Empty;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        private static string MatchString(Match match)
        {
            return match.Groups[1].Success
                ? $@"\cf2 {RemoveRtfColors(match.Value)}\cf0 "
                : string.Empty;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        private static string MatchComment(Match match)
        {
            return match.Groups[1].Success
                ? $@"\cf1 {RemoveRtfColors(match.Value)}\cf0 "
                : string.Empty;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        private static string MatchInteger(Match match)
        {
            return match.Groups[1].Success
                ? $@"\cf4 {RemoveRtfColors(match.Value)}\cf0 "
                : string.Empty;
        }

        /// <summary>
        /// remove all rtf-colors from a string
        /// </summary>
        /// <param name="strText"></param>
        /// <returns>String</returns>
        private static string RemoveRtfColors(string strText)
        {
            var r = new Regex(@"\\cf[0-9] ");
            return r.Replace(strText, "");
        }
    }
}