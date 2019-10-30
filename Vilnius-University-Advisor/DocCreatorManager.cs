using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vilnius_University_Advisor
{
    public class DocCreatorManager
    {
        private IDocCreator docCreator;
        public DocCreatorManager(IDocCreator docCreator)
        {
            this.docCreator = docCreator;
        }

        public void CreateDocument<T>(string path, List<T> list)
        {
            docCreator.GenerateDoc(path, list);
        }
    }
}
