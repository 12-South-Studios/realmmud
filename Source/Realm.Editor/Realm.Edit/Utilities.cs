using System;
using System.Windows.Forms;

namespace Realm.Edit
{
    public static class Utilities
    {
        public static bool ValidateField(this Control control, Func<bool> validationFunction, string warningMessage,
            bool giveFeedback = true)
        {
            if (validationFunction.Invoke())
            {
                if (!giveFeedback) return true;

                Program.MainForm.SetWarningMessage(warningMessage);
                control.BackColor = System.Drawing.Color.DarkRed;
                return true;
            }

            control.BackColor = System.Drawing.Color.Empty;
            return false;
        }

        public static void SetTooltip(this Control aControl, string value, bool autoWrap)
        {
            var tt = new ToolTip();
            tt.SetToolTip(aControl, autoWrap ? AutoWrapString(value) : value);
        }

        private static string AutoWrapString(string msgText)
        {
            var words = msgText.Split(' ');
            var lineLen = 0;
            var wordWrap = string.Empty;

            for (int i = 0; i < words.Length; i++)
            {
                wordWrap += words[i] + " ";
                lineLen += words[i].Length + 1;

                if (i >= words.Length - 1) continue;
                if (lineLen + words[i + 1].Length < 80) continue;

                wordWrap += "\n";
                lineLen = 0;
            }

            return wordWrap;
        }
    }
}
