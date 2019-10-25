using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vilnius_University_Advisor
{
    class ValidationMsgPrinter
    {
        private static ValidationMsgPrinter instance = new ValidationMsgPrinter();

        public static ValidationMsgPrinter GetInstance()
        {
            return instance;
        }

        public void PrintOnlyMessage(string text, string caption)
        {
            MessageBox.Show(text, caption);
        }
        public void PrintWarningMessage(string text, string caption)
        {
            MessageBox.Show(text, caption, 0, MessageBoxIcon.Exclamation);
        }
    }
}
