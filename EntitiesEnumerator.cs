using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vilnius_University_Advisor
{
    class EntitiesEnumerator : IEnumerator<DataNode>
    {

        private List<DataNode> itrList;
        private int index = -1;

        public DataNode Current => itrList[index];

        object IEnumerator.Current => Current;

        public EntitiesEnumerator(List<DataNode> list)
        {
            itrList = list;
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            index++;

            return index < itrList.Count;
        }

        public void Reset()
        {
            index = 0;
        }
    }
}
