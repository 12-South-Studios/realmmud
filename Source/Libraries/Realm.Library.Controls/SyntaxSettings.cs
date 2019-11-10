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
        public string Comment { get; set; } = "";

        /// <summary>
        /// The color of comments.
        /// </summary>
        public Color CommentColor { get; set; } = Color.Green;

        /// <summary>
        /// Enables processing of comments if set to true.
        /// </summary>
        public bool EnableComments { get; set; } = true;

        /// <summary>
        /// Enables processing of integers if set to true.
        /// </summary>
        public bool EnableIntegers { get; set; } = true;

        /// <summary>
        /// Enables processing of strings if set to true.
        /// </summary>
        public bool EnableStrings { get; set; } = true;

        /// <summary>
        /// The color of strings.
        /// </summary>
        public Color StringColor { get; set; } = Color.Gray;

        /// <summary>
        /// The color of integers.
        /// </summary>
        public Color IntegerColor { get; set; } = Color.Red;
    }
}