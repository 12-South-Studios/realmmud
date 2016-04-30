using System.Collections.Generic;
using System.Drawing;

namespace Realm.Library.Controls
{
    /// <summary>
    /// Settings for the keywords and colors.
    /// </summary>
    public class SyntaxSettings
    {
        private readonly SyntaxList _rgKeywords = new SyntaxList();
        private string _strComment = "";
        private Color _colorComment = Color.Green;
        private Color _colorString = Color.Gray;
        private Color _colorInteger = Color.Red;
        private bool _enableComments = true;
        private bool _enableIntegers = true;
        private bool _enableStrings = true;

        #region Properties

        /// <summary>
        /// A list containing all keywords.
        /// </summary>
        public ICollection<string> Keywords => _rgKeywords.RgList;

        /// <summary>
        /// The color of keywords.
        /// </summary>
        public Color KeywordColor
        {
            get { return _rgKeywords.Color; }
            set { _rgKeywords.Color = value; }
        }

        /// <summary>
        /// A string containing the comment identifier.
        /// </summary>
        public string Comment
        {
            get { return _strComment; }
            set { _strComment = value; }
        }

        /// <summary>
        /// The color of comments.
        /// </summary>
        public Color CommentColor
        {
            get { return _colorComment; }
            set { _colorComment = value; }
        }

        /// <summary>
        /// Enables processing of comments if set to true.
        /// </summary>
        public bool EnableComments
        {
            get { return _enableComments; }
            set { _enableComments = value; }
        }

        /// <summary>
        /// Enables processing of integers if set to true.
        /// </summary>
        public bool EnableIntegers
        {
            get { return _enableIntegers; }
            set { _enableIntegers = value; }
        }

        /// <summary>
        /// Enables processing of strings if set to true.
        /// </summary>
        public bool EnableStrings
        {
            get { return _enableStrings; }
            set { _enableStrings = value; }
        }

        /// <summary>
        /// The color of strings.
        /// </summary>
        public Color StringColor
        {
            get { return _colorString; }
            set { _colorString = value; }
        }

        /// <summary>
        /// The color of integers.
        /// </summary>
        public Color IntegerColor
        {
            get { return _colorInteger; }
            set { _colorInteger = value; }
        }

        #endregion Properties
    }
}