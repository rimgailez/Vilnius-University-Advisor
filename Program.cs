using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;

namespace Vilnius_University_Advisor
{
    static class Program
    {[STAThread]
        static void Main()
        {
            DataMaster.GetInstance().ReadFromJson();
            //run WinForm
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new RegForm());
        }
    }
}
