using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace transmission_renamer.Classes
{
    public static class TextBoxBackFix
    {
        public static void SearchCtrlBackSpace(object sender, KeyEventArgs e)
        {
            TextBox box = (TextBox)sender;
            if (e.KeyData == (Keys.Back | Keys.Control))
            {
                if (!box.ReadOnly && box.SelectionLength == 0)
                {
                    string text = Regex.Replace(box.Text.Substring(0, box.SelectionStart), @"(^\W)?\w*\W*$", "");
                    box.Text = text + box.Text.Substring(box.SelectionStart);
                    box.SelectionStart = text.Length;
                }
                e.SuppressKeyPress = true;
            }
        }
    }
}
