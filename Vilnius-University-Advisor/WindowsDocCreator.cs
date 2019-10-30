using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word;

namespace Vilnius_University_Advisor
{
    class WindowsDocCreator : IDocCreator
    {
       public void GenerateDoc<T>(string path, List<T> list)
        {
            Word.Application objWord = new Word.Application();
            objWord.Visible = true;
            objWord.WindowState = Word.WdWindowState.wdWindowStateNormal;

            Word.Document objDoc = objWord.Documents.Add();

            Word.Paragraph objPara;
            objPara = objDoc.Paragraphs.Add();

            foreach(var elem in list)
            {
                objPara.Range.Text = elem.ToString();
                objPara.Range.InsertParagraphAfter();
            }
            
            objDoc.SaveAs2(path);
            objDoc.Close();
            //objWord.Documents.Open(@path);
            objWord.Quit();
        }

    }
}
