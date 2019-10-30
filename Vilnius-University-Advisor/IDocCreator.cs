using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vilnius_University_Advisor
{
    public interface IDocCreator
    {
        void GenerateDoc<T>(string path, List<T> list);
    }
}
