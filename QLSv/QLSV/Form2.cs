using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV
{
    public partial class Form2 : Form
    {
        private string mSSV;

        public delegate void MyDel(int id, string name);
        public MyDel d { get; set; }
        public int MSSV { get; set; }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SV s = new SV()
            {
                MSSV = Convert.ToInt32(textBox1.Text),
                NameSV = textBox2.Text,
                Gender = radioButton1.Checked,
                NS = dateTimePicker1.Value,
                ID_Lop =((CBBItem)comboBox1.SelectedItem).Value
            };
            CSDL_OOP.Instance.ExecuteDB(s);
            d(0, "");
            this.Dispose();
        }
        public Form2(int m)
        {
            InitializeComponent();
            MSSV = m;
            setGUI();

            radioButton1.Checked = true;
        }

        public Form2(string mSSV)
        {
            this.mSSV = mSSV;
        }

        public void setGUI()
        {
            SV s = CSDL_OOP.Instance.GetSVByMSSV(MSSV);
            if(s.MSSV != 0)
            {
                //lay thong tin len giao dien
                textBox1.Text = s.MSSV.ToString();
                 textBox2.Text = s.NameSV;
              //  comboBox1.SelectedIndex = 0;
                dateTimePicker1.Value = s.NS;
               radioButton1.Checked = s.Gender;
            }
        }

        public void SetCBB()
        {
            //comboBox1.Items.Add(new CBBItem { Value = 0, Text = "All" });
            foreach (LSH i in CSDL_OOP.Instance.GetAllLSH())
            {
                comboBox1.Items.Add(new CBBItem
                {
                    Value = i.ID_Lop,
                    Text = i.NameLop
                });
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
    

    }

