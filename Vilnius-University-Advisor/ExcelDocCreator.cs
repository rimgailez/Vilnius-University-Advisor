using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;

namespace Vilnius_University_Advisor
{
    public class ExcelDocCreator: IDocCreator
    {
        public void GenerateDoc<T>(string path, List<T> list)
        {
            Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();

            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            int i = 0;
            foreach(var elem in list)
            {
                i++;
                xlWorkSheet.Cells[i, 1] = i + ".";
                xlWorkSheet.Cells[i, 2] = elem.ToString();
            }
            //object filename = Path.GetFullPath(Path.Combine(Application.StartupPath, "..\\..")) + "\\test.doc";

            xlWorkBook.SaveAs(path, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            Marshal.ReleaseComObject(xlWorkSheet);
            Marshal.ReleaseComObject(xlWorkBook);
            Marshal.ReleaseComObject(xlApp);
    }
}
}
