using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV
{
    class LSH
    {
        public LSH(int iD_Lop, string nameLop)
        {
            ID_Lop = iD_Lop;
            NameLop = nameLop;
        }

        public int ID_Lop { get; set; }
        public string NameLop { get; set; }

    }
}
