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
        private BO_Departement RecordedDept=new BO_Departement();
        private BO_Employe RecordedEmploye=null;

        #region "Constructeurs"
        public Form1()
        {
            InitializeComponent();
        }
        #endregion "Constructeurs"

        #region "Méthodes evenementielles"
        private void Form1_Load(object sender, EventArgs e)
        {
            this.RemplissageComboBox();
            if (bindingSource2.Current != null)
            {
                RecordedDept = (BO_Departement)bindingSource2.Current;
            }
            this.RemplissageDataGridView(RecordedDept.Deptno, dataGridView1);

            //label4.Text = BLL_OAI.SqlMessage;
        }

        private void bindingSource2_CurrentItemChanged(object sender, EventArgs e)
        {
            if (bindingSource2.Current != null)
            {
                RecordedDept = (BO_Departement)bindingSource2.Current;
                int deptno = RecordedDept.Deptno;
                //RecordedDept = BLL_OAI.GetDeptByDeptno(deptno);
                if (deptno != 0)
                {
                    this.RemplissageDataGridView(deptno, dataGridView1);

                }

            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            RecordedDept = new BO_Departement();
            RemplissageDataGridView(RecordedDept.Deptno, dataGridView1);
            RecordedDept.Deptno =0;
        }

        private void bindingSource1_CurrentItemChanged(object sender, EventArgs e)
        {
            if (bindingSource1.Current != null)
            {
                RecordedEmploye = (BO_Employe)bindingSource1.Current;
                textBox1.Text = RecordedEmploye.Departement.Dname;
                textBox2.Text = RecordedEmploye.Nom;
                textBox3.Text = RecordedEmploye.Job;
                textBox4.Text = RecordedEmploye.Salaire.ToString();
                textBox2.Enabled = true;
                button2.Enabled = true;
            }
            else
            {
                RecordedEmploye = null;
                textBox1.Text = string.Empty;
                textBox2.Text = string.Empty;
                textBox3.Text = string.Empty;
                textBox4.Text = string.Empty;
                textBox2.Enabled = false;
                button2.Enabled = false;
                if (bindingSource2.Current != null)
                {
                    textBox1.Text = RecordedDept.Dname;
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RecordedEmploye = (BO_Employe)bindingSource1.Current;
            string oldName = RecordedEmploye.Nom;
            string newEname = textBox2.Text.ToUpper();
            BO_Nombre resultat= new BO_Nombre();
            RecordedEmploye.Nom= newEname;
            
            string message = $"{oldName} => {newEname}";
            
            DialogResult dialogResult = MessageBox.Show(message, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
            if (dialogResult == DialogResult.Yes)
            {
                resultat = BLL_OAI.UpdateEmp(RecordedEmploye);
            }

            if (resultat != null)
            {
                this.RemplissageDataGridView(RecordedDept.Deptno, dataGridView1);
            }
        }
        #endregion "Méthodes evenementielles"

        #region "Méthodes propres à la classe"
        private void RemplissageComboBox()
        {
            bindingSource2.DataSource = BLL_OAI.GetAllDept().Departements;
            comboBox1.DataSource = bindingSource2;
            comboBox1.ValueMember = "Deptno";
            comboBox1.DisplayMember = "Dname";
            //label4.Text = BLL_OAI.SqlMessage;
        }

        private void RemplissageDataGridView(int deptno, DataGridView datagridview)
        {
            BO_ListeEmployes employes;
            if (deptno != 0)
            {
                employes = BLL_OAI.GetEmpByDeptno(deptno);
                label2.Text = $"{BLL_OAI.GetDeptByDeptno(deptno).Dname}";
            }
            else
            {
                employes = BLL_OAI.GetAllEmp();
                label2.Text = $"TOUS";
            }
            employes.Employes.Sort();
            bindingSource1.DataSource = employes.Employes;
            datagridview.DataSource = bindingSource1;
            this.ModelingByDataGridView(datagridview);
            //label4.Text = BLL_OAI.SqlMessage;
        }


        private void ModelingByDataGridView(DataGridView datagridview)
        {
            datagridview.Columns["Departement"].Visible = false;
            //datagridview.Columns.Remove(dataGridView1.Columns["Departement"]);
            label3.Text = $"Nbre employé(s): {datagridview.RowCount}";
            datagridview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            int totalRowHeight = dataGridView1.ColumnHeadersHeight;

            foreach (DataGridViewRow row in datagridview.Rows)
            {
                totalRowHeight += row.Height;
            }

            dataGridView1.Height = totalRowHeight;
        }

        #endregion "Méthodes propres à la classe"


    }

}
