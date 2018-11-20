using BLL;
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
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            BLL_ListeDepartements listeDept = new BLL_ListeDepartements();

            foreach (BLL_Departement item in listeDept.Departements)
            {
                comboBox1.Items.Add(new { Nom = item.Dname, Numero = item.Deptno });
            }
            comboBox1.ValueMember = "Numero";
            comboBox1.DisplayMember = "Nom";
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
