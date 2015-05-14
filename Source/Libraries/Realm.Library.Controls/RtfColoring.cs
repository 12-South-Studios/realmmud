using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using Realm.Library.Common;

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
            Validation.IsNotNull(richTextBox, "richTextBox");

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

            var strCommentColor = String.Format("\\red{0}\\green{1}\\blue{2}",
                settings.CommentColor.R.ToString(CultureInfo.InvariantCulture),
                settings.CommentColor.G.ToString(CultureInfo.InvariantCulture),
                settings.CommentColor.B.ToString(CultureInfo.InvariantCulture));

            var strStringColor = String.Format("\\red{0}\\green{1}\\blue{2}",
                settings.StringColor.R.ToString(CultureInfo.InvariantCulture),
                settings.StringColor.G.ToString(CultureInfo.InvariantCulture),
                settings.StringColor.B.ToString(CultureInfo.InvariantCulture));

            var strKeywordColor = String.Format("\\red{0}\\green{1}\\blue{2}",
                settings.KeywordColor.R.ToString(CultureInfo.InvariantCulture),
                settings.KeywordColor.G.ToString(CultureInfo.InvariantCulture),
                settings.KeywordColor.B.ToString(CultureInfo.InvariantCulture));

            var strIntegerColor = String.Format("\\red{0}\\green{1}\\blue{2}",
                settings.IntegerColor.R.ToString(CultureInfo.InvariantCulture),
                settings.IntegerColor.G.ToString(CultureInfo.InvariantCulture),
                settings.IntegerColor.B.ToString(CultureInfo.InvariantCulture));

            // insert the colour table at our chosen location
            strRtf = strRtf.Insert(iInsertLoc, String.Format("{{\\colortbl ;{0};{1};{2};{3};}}",
                strCommentColor, strStringColor, strKeywordColor, strIntegerColor));

            // build the keywords regex
            var strKeywords = settings.Keywords.Aggregate(String.Empty, (current, keyword) => current + (keyword + ","));
            strKeywords = strKeywords.Substring(0, strKeywords.Length - 1);

            var r = new Regex(@", ?");
            strKeywords = String.Format(@"\b({0})\b", r.Replace(strKeywords, @"|"));

            // start coloring
            // Keywords
            r = new Regex(strKeywords, RegexOptions.Singleline | RegexOptions.IgnoreCase);
            strRtf = r.Replace(strRtf, MatchKeyword);

            // Integers
            r = new Regex("(\\b(?:[0-9]*\\.)?[0-9]+\\b)", RegexOptions.IgnoreCase);
            strRtf = r.Replace(strRtf, MatchInteger);

            // Comments
            r = new Regex(String.Format("({0}.*$)", settings.Comment), RegexOptions.Multiline | RegexOptions.IgnoreCase);
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
                ? String.Format(@"\cf3 {0}\cf0 ", RemoveRtfColors(match.Value))
                : String.Empty;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        private static string MatchString(Match match)
        {
            return match.Groups[1].Success
                ? String.Format(@"\cf2 {0}\cf0 ", RemoveRtfColors(match.Value))
                : String.Empty;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        private static string MatchComment(Match match)
        {
            return match.Groups[1].Success
                ? String.Format(@"\cf1 {0}\cf0 ", RemoveRtfColors(match.Value))
                : String.Empty;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        private static string MatchInteger(Match match)
        {
            return match.Groups[1].Success
                ? String.Format(@"\cf4 {0}\cf0 ", RemoveRtfColors(match.Value))
                : String.Empty;
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