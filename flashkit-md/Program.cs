using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace flashkit_md
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

    public class Int32TextBox : TextBox
    {
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            NumberFormatInfo fi = CultureInfo.CurrentCulture.NumberFormat;

            string c = e.KeyChar.ToString();
            if (char.IsDigit(c, 0))
                return;

            if ((SelectionStart == 0) && (c.Equals(fi.NegativeSign)))
                return;

            // copy/paste
            if ((((int)e.KeyChar == 22) || ((int)e.KeyChar == 3))
                && ((ModifierKeys & Keys.Control) == Keys.Control))
                return;

            if (e.KeyChar == '\b')
                return;

            e.Handled = true;
        }

        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            const int WM_PASTE = 0x0302;
            if (m.Msg == WM_PASTE)
            {
                string text = Clipboard.GetText();
                if (string.IsNullOrEmpty(text))
                    return;

                if ((text.IndexOf('+') >= 0) && (SelectionStart != 0))
                    return;

                int i;
                if (!int.TryParse(text, out i)) // change this for other integer types
                    return;

                if ((i < 0) && (SelectionStart != 0))
                    return;
            }
            base.WndProc(ref m);
        }
    }

}
