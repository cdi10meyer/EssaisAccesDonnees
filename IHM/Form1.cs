using BLL;
using BO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IHM
{
    public partial class Form1 : Form
    {

        public BLL_Departements ListeDept { get; private set; }

        public BLL_Employes ListeEmployes { get; private set; }
        public Form1()
        {
            InitializeComponent();
            this.ListeDept = new BLL_Departements();
            this.ListeEmployes = new BLL_Employes();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.RemplissageComboBox();
            this.RemplissageDataGridView((int)comboBox1.SelectedValue);

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue != null)
            {
                if (comboBox1.SelectedValue is int)
                {
                    int dept = (int)comboBox1.SelectedValue;
                    if (dept != 0)
                        this.RemplissageDataGridView(dept);
                }
            }
        }
        private void RemplissageComboBox()
        {
            comboBox1.DataSource = this.ListeDept.Departements;
            comboBox1.ValueMember = "Deptno";
            comboBox1.DisplayMember = "Dname";
        }

        private void RemplissageDataGridView()
        {
            this.ListeEmployes = new BLL_Employes();
            dataGridView1.DataSource = this.ListeEmployes.Employes;
        }
        private void RemplissageDataGridView(int dept)
        {
            this.ListeEmployes = new BLL_Employes(dept);
            dataGridView1.DataSource = this.ListeEmployes.Employes;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RemplissageDataGridView();
        }
    }
}
