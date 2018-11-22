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
        #region "Propriétés d'instance"
        public BLL_Departements ListeDept { get; private set; }

        public BLL_Employes ListeEmployes { get; private set; }
        #endregion "Propriétés d'instance"

        #region "Constructeurs"
        public Form1()
        {
            InitializeComponent();
            this.ListeDept = new BLL_Departements();
            this.ListeEmployes = new BLL_Employes();
        }
        #endregion "Constructeurs"

        #region "Méthodes evenementielles"
        private void Form1_Load(object sender, EventArgs e)
        {
            this.RemplissageComboBox();
            this.RemplissageDataGridView((int)comboBox1.SelectedValue);

            label4.Text = BLL_Connection.SqlMessage;

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue != null)
            {
                if (comboBox1.SelectedValue is int)
                {
                    int dept = (int)comboBox1.SelectedValue;
                    if (dept != 0)
                    {
                        this.RemplissageDataGridView(dept);
                    }
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            RemplissageDataGridView();
        }
        //private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        //{
        //    if (dataGridView1.CurrentRow != null)
        //    {
        //        DataGridViewRow employeSelectionne = dataGridView1.CurrentRow;
        //        textBox2.Text = employeSelectionne.Cells["Nom"].Value.ToString();
        //        textBox3.Text = employeSelectionne.Cells["Job"].Value.ToString();
        //        textBox4.Text = employeSelectionne.Cells["Salaire"].Value.ToString();
        //    }
        //}

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            if(bindingSource1.Current!=null)
            {
                BO_Employe employeSelectionne = (BO_Employe)bindingSource1.Current;
                BO_Departement departement = this.ListeDept.Departements.Find(x => x.Deptno == employeSelectionne.Deptno);
                textBox1.Text = departement.Dname;
                textBox2.Text = employeSelectionne.Nom;
                textBox3.Text = employeSelectionne.Job;
                textBox4.Text = employeSelectionne.Salaire.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int resultat = 0;
            BO_Employe employeSelectionne = (BO_Employe)bindingSource1.Current;
            if(textBox2.Text != employeSelectionne.Nom)
            {
                int empno = employeSelectionne.Empno;
                string newEname = textBox2.Text.ToUpper();
                resultat = ListeEmployes.UpdateEmp(empno, newEname);
                label9.Text = $"{resultat} modification";
                
            }
        }
        #endregion "Méthodes evenementielles"

        #region "Méthodes propres à la classe"
        private void RemplissageComboBox()
        {
            comboBox1.DataSource = this.ListeDept.Departements;
            comboBox1.ValueMember = "Deptno";
            comboBox1.DisplayMember = "Dname";
        }
        private void RemplissageDataGridView()
        {
            this.ListeEmployes = new BLL_Employes();
            ListeEmployes.Employes.Sort();
            bindingSource1.DataSource = this.ListeEmployes.Employes;
            dataGridView1.DataSource = bindingSource1;
            this.ModelingByDataGridView();
            
            label2.Text = $"TOUS";
        }
        private void RemplissageDataGridView(int dept)
        {
            this.ListeEmployes = new BLL_Employes(dept);
            ListeEmployes.Employes.Sort();
            bindingSource1.DataSource = this.ListeEmployes.Employes;
            dataGridView1.DataSource = bindingSource1;
            this.ModelingByDataGridView();
            BO_Departement departement = this.ListeDept.Departements.Find(x => x.Deptno == dept);
            label2.Text = $"{departement.Dname}";
        }


        private void ModelingByDataGridView()
        {
            dataGridView1.Columns.Remove(dataGridView1.Columns["Deptno"]);
            label3.Text = $"Nbre employé(s): {this.ListeEmployes.Employes.Count}";
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            int totalRowHeight = dataGridView1.ColumnHeadersHeight;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                totalRowHeight += row.Height;
            }

            dataGridView1.Height = totalRowHeight;
        }



        #endregion "Méthodes propres à la classe"

      
    }

}
