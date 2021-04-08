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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SetCBB();
            comboBox1.SelectedIndex = 0;
            dataGridView1.DataSource= CSDL_OOP.Instance.GetListSV(0,"");
        }


        private void btnShow_Click(object sender, EventArgs e)
        {
            Show(((CBBItem)comboBox1.SelectedItem).Value, textBox1.Text);
        }
        private void btnsearch_Click(object sender, EventArgs e)
        {
            Show(((CBBItem)comboBox1.SelectedItem).Value, textBox1.Text);
        }

        public void SetCBB()
        {
            comboBox1.Items.Add(new CBBItem { Value = 0, Text = "All" });
            foreach (LSH i in CSDL_OOP.Instance.GetAllLSH())
            {
                comboBox1.Items.Add(new CBBItem
                {
                    Value = i.ID_Lop,
                    Text = i.NameLop
                });
            }
        }

        public void Show(int ID_Lop, string Name)
        {
            dataGridView1.DataSource = CSDL_OOP.Instance.GetListSV(ID_Lop, Name);
        }



        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2(0);
            f.d += new Form2.MyDel(Show);
            f.SetCBB();
            f.Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                int mssv = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["MSSV"].Value.ToString());
                Form2 f = new Form2(mssv);
                f.d += new Form2.MyDel(Show);
                f.SetCBB();

                f.Show();
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                int mssv = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["MSSV"].Value.ToString());
                CSDL.Instance.DeleteDataRowSV(mssv);
                Show(0,"");
            }
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            CSDL.Instance.Sort(comboBox2.SelectedItem.ToString());
            Show(0, "");
        }
    }
}
