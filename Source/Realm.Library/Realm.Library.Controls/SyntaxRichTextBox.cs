using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;

namespace Realm.Library.Controls
{
    /// <summary>
    ///
    /// </summary>
    public class SyntaxRichTextBox : System.Windows.Forms.RichTextBox
    {
        private readonly SyntaxSettings _mSettings = new SyntaxSettings();
        private static bool _paint = true;
        private string _strLine = "";
        private int _lineLength;
        private int _lineStart;
        private int _lineEnd;
        private string _strKeywords = "";

        /// <summary>
        /// The settings.
        /// </summary>
        public SyntaxSettings Settings
        {
            get { return _mSettings; }
        }

        /// <summary>
        /// WndProc
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            if (m.Msg == 0x00f)
            {
                if (_paint)
                    base.WndProc(ref m);
                else
                    m.Result = IntPtr.Zero;
            }
            else
                base.WndProc(ref m);
        }

        /// <summary>
        /// OnTextChanged
        /// </summary>
        /// <param name="e"></param>
        protected override void OnTextChanged(EventArgs e)
        {
            // Calculate shit here.

            var nCurrentSelectionStart = SelectionStart;

            _paint = false;

            // Find the start of the current line.
            _lineStart = nCurrentSelectionStart;
            while ((_lineStart > 0) && (Text[_lineStart - 1] != '\n'))
                _lineStart--;
            // Find the end of the current line.
            _lineEnd = nCurrentSelectionStart;
            while ((_lineEnd < Text.Length) && (Text[_lineEnd] != '\n'))
                _lineEnd++;
            // Calculate the length of the line.
            _lineLength = _lineEnd - _lineStart;
            // Get the current line.
            _strLine = Text.Substring(_lineStart, _lineLength);

            // Process this line.
            ProcessLine();

            _paint = true;
        }

        /// <summary>
        /// Process a line.
        /// </summary>
        private void ProcessLine()
        {
            // Save the position and make the whole line black
            var nPosition = SelectionStart;
            SelectionStart = _lineStart;
            SelectionLength = _lineLength;
            SelectionColor = Color.Black;

            // Process the keywords
            ProcessRegex(_strKeywords, Settings.KeywordColor);
            // Process numbers
            if (Settings.EnableIntegers)
                ProcessRegex("\\b(?:[0-9]*\\.)?[0-9]+\\b", Settings.IntegerColor);
            // Process strings
            if (Settings.EnableStrings)
                ProcessRegex("\"[^\"\\\\\\r\\n]*(?:\\\\.[^\"\\\\\\r\\n]*)*\"", Settings.StringColor);
            // Process comments
            if (Settings.EnableComments && !string.IsNullOrEmpty(Settings.Comment))
                ProcessRegex(Settings.Comment + ".*$", Settings.CommentColor);

            SelectionStart = nPosition;
            SelectionLength = 0;
            SelectionColor = Color.Black;
        }

        /// <summary>
        /// Process a regular expression.
        /// </summary>
        /// <param name="strRegex">The regular expression.</param>
        /// <param name="color">The color.</param>
        private void ProcessRegex(string strRegex, Color color)
        {
            var regKeywords = new Regex(strRegex, RegexOptions.IgnoreCase | RegexOptions.Compiled);
            Match regMatch;

            for (regMatch = regKeywords.Match(_strLine); regMatch.Success; regMatch = regMatch.NextMatch())
            {
                // Process the words
                var nStart = _lineStart + regMatch.Index;
                var nLenght = regMatch.Length;
                SelectionStart = nStart;
                SelectionLength = nLenght;
                SelectionColor = color;
            }
        }

        /// <summary>
        /// Compiles the keywords as a regular expression.
        /// </summary>
        public void CompileKeywords()
        {
            var keywords = Settings.Keywords as List<string>;
            if (keywords == null) return;

            for (var i = 0; i < keywords.Count; i++)
            {
                var strKeyword = keywords[i];

                if (i == keywords.Count - 1)
                    _strKeywords += String.Format("\\b{0}\\b", strKeyword);
                else
                    _strKeywords += String.Format("\\b{0}\\b|", strKeyword);
            }
        }

        /// <summary>
        ///
        /// </summary>
        public void ProcessAllLines()
        {
            _paint = false;

            var nStartPos = 0;
            var i = 0;
            while (i < Lines.Length)
            {
                _strLine = Lines[i];
                _lineStart = nStartPos;
                _lineEnd = _lineStart + _strLine.Length;

                ProcessLine();
                i++;

                nStartPos += _strLine.Length + 1;
            }

            _paint = true;
        }
    }
}