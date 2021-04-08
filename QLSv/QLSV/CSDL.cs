using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace QLSV
{
    class CSDL
    {
        public DataTable dtSV { get; set; }
        public DataTable dtLop { get; set; }
        private static CSDL _Instance;
        public static CSDL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new CSDL();
                }
                return _Instance;
            }
            private set
            {
                _Instance = value;
            }
        }
        private CSDL()
        {
            dtSV = new DataTable();
            dtSV.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("MSSV",typeof(int)),
                new DataColumn("NameSV", typeof(string)),
                new DataColumn("Gender",typeof(bool)),
                new DataColumn("NS",typeof(DateTime)),
                new DataColumn("ID_Lop",typeof(int))
            });
            DataRow dr = dtSV.NewRow();
            dr["MSSV"] = "101";
            dr["NameSV"] = "Ho Hoang Thien";
            dr["Gender"] = true;
            dr["NS"] = DateTime.Parse("12/04/2001");
            dr["ID_Lop"] = 1;
            dtSV.Rows.Add(dr);

            DataRow dr1 = dtSV.NewRow();
            dr1["MSSV"] = "102";
            dr1["NameSV"] = "Pham Thanh Nguyen";
            dr1["Gender"] = true;
            dr1["NS"] = DateTime.Parse("10/06/2001");
            dr1["ID_Lop"] = 1;
            dtSV.Rows.Add(dr1);

            DataRow dr2 = dtSV.NewRow();
            dr2["MSSV"] = "103";
            dr2["NameSV"] = "Phan Van Binh";
            dr2["Gender"] = true;
            dr2["NS"] = DateTime.Parse("20/10/2001");
            dr2["ID_Lop"] = 2;
            dtSV.Rows.Add(dr2);

            DataRow dr3 = dtSV.NewRow();
            dr3["MSSV"] = "104";
            dr3["NameSV"] = "Ngo Duc Khuong";
            dr3["Gender"] = true;
            dr3["NS"] = DateTime.Parse("05/07/2001");
            dr3["ID_Lop"] = 3;
            dtSV.Rows.Add(dr3);

            dtLop = new DataTable();
            dtLop.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("ID_Lop",typeof(int)),
                new DataColumn("NameLop", typeof(string)),
            });
            DataRow dr4 = dtLop.NewRow();
            dr4["ID_Lop"] = 1;
            dr4["NameLop"] = "19TCLC_DT6";
            dtLop.Rows.Add(dr4);

            DataRow dr5 = dtLop.NewRow();
            dr5["ID_Lop"] = 2;
            dr5["NameLop"] = "19TCLC_DT4";
            dtLop.Rows.Add(dr5);

            DataRow dr6 = dtLop.NewRow();
            dr6["ID_Lop"] = 3;
            dr6["NameLop"] = "19TCLC_DT3";
            dtLop.Rows.Add(dr6);
        }

        public void AddDataRowSV(SV s)
        {
            DataRow dr = dtSV.NewRow();
            dr["MSSV"] = s.MSSV;
            dr["NameSV"] = s.NameSV;
            dr["Gender"] = s.Gender;
            dr["NS"] = s.NS;
            dr["ID_Lop"] = s.ID_Lop;
            dtSV.Rows.Add(dr);
        }

        public void EditDataRowSV(SV s)
        {
            foreach (DataRow i in dtSV.Rows)
            {
                if( Convert.ToInt32(i["MSSV"].ToString()) == s.MSSV)
                {
                    CSDL.Instance.dtSV.Rows.Remove(i);
                    DataRow dr = dtSV.NewRow();
                    dr["MSSV"] = s.MSSV;
                    dr["NameSV"] = s.NameSV;
                    dr["Gender"] = s.Gender;
                    dr["NS"] = s.NS;
                    dr["ID_Lop"] = s.ID_Lop;
                    dtSV.Rows.Add(dr);
                    return;
                }
            }
        }

        public void DeleteDataRowSV(int MSSV)
        {
            foreach (DataRow i in dtSV.Rows)
            {
                if (Convert.ToInt32(i["MSSV"].ToString()) == MSSV)
                {
                    CSDL.Instance.dtSV.Rows.Remove(i);
                    return;
                }
            }
        }

        public void Sort(string s)
        {
            if (s == "Giam dan")
            {
                dtSV.DefaultView.Sort = "MSSV desc";
                dtSV = dtSV.DefaultView.ToTable();
            } else
            {
                dtSV.DefaultView.Sort = "MSSV asc";
                dtSV = dtSV.DefaultView.ToTable();
            }
        }
    }
}
