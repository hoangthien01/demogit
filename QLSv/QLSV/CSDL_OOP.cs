using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace QLSV
{
    class CSDL_OOP
    {
        private static CSDL_OOP _Instance;

        public static CSDL_OOP Instance
        {
            get
            {
                if (_Instance == null )
                {
                    _Instance = new CSDL_OOP();
                }
                return _Instance;
            }
            private set { }
        }

        private CSDL_OOP()
        {

        }

        public List<SV> GetAllSV()
        {
            List<SV> data = new List<SV>();
            foreach (DataRow i  in CSDL.Instance.dtSV.Rows)
            {
                data.Add(GetSV(i));
            }
            return data;
        }

        public SV GetSV(DataRow i)
        {
            return new SV
            {
                MSSV = Convert.ToInt32(i["MSSV"].ToString()),
                NameSV = i["NameSV"].ToString(),
                Gender = Convert.ToBoolean(i["Gender"].ToString()),
                NS = Convert.ToDateTime(i["NS"].ToString()),
                ID_Lop = Convert.ToInt32(i["ID_Lop"].ToString())
            };
        }

        public List<LSH> GetAllLSH() 
        {
            List<LSH> data = new List<LSH>();
            foreach ( DataRow i in CSDL.Instance.dtLop.Rows)
            {
                data.Add(GetLSH(i));
            }
            return data;
        }

        public LSH GetLSH(DataRow i)
        {
            return new LSH
            (
                Convert.ToInt32(i["ID_Lop"].ToString()),i["NameLop"].ToString()
            );
        }

        public List<SV> GetListSV(int ID_Lop, string Name)
        {
            List<SV> data = new List<SV>();
            foreach(SV i in GetAllSV())
            {
                if ((i.ID_Lop == ID_Lop || ID_Lop == 0) && i.NameSV.Contains(Name))
                {
                    data.Add(new SV
                    {
                        NameSV = i.NameSV,
                        MSSV = i.MSSV,
                        Gender = i.Gender,
                        NS = i.NS,
                        ID_Lop = i.ID_Lop
                    });
                }
            }
            return data;
        }
        public void ExecuteDB(SV s)
        {
            bool check = false;
            foreach (SV i in GetAllSV())
            {
                if(i.MSSV == s.MSSV)
                {
                    check = true;
                }
            }
            if ( check)
            {
                CSDL.Instance.EditDataRowSV(s);
            } else
            {
                CSDL.Instance.AddDataRowSV(s);
            }
        }

        public SV GetSVByMSSV(int MSSV)
        {
            SV s = new SV();
            foreach(SV i in GetAllSV())
            {
                if (i.MSSV == MSSV)
                {
                    s = i;
                }
            }
            return s;
        }

       /* public void DeleteSV(string MSSV)
        {
            CSDL.Instance.DeleteDataRowSV(MSSV);
        }*/
    }
}
