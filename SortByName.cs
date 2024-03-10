using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryLabor10
{
    public class SortByName : IComparer
    {
        public int Compare(object x, object y)
        {
            Musicalinstrument name1 = x as Musicalinstrument;
            Musicalinstrument name2 = y as Musicalinstrument;

            if (name1 == null && name2 == null) return 0;
            if (name1 == null) return -1;
            if (name2 == null) return 1;

            return string.Compare(name1.Name, name2.Name);
        }
    }
}
          