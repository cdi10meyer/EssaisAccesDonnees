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
        private BO_Departement _RecordedDept;
        private BO_Employe _RecordedEmploye;

        #region "Constructeurs"
        public Form1()
        {
            InitializeComponent();
            label4.Text = string.Empty;
            _RecordedDept = new BO_Departement();
            _RecordedEmploye = new BO_Employe();

            this.FillingComboBox();
            if (bindingSourceDept.Current != null)
            {
                _RecordedDept = (BO_Departement)bindingSourceDept.Current;
            }
            this.FillingDataGridView(_RecordedDept.Deptno);
        }
        #endregion "Constructeurs"

        #region "Méthodes propres à la classe"
        private void FillingComboBox()
        {
            bindingSourceDept.DataSource = BLL_OAI.GetAllDept();
            comboBoxDept.DataSource = bindingSourceDept;
            comboBoxDept.ValueMember = "Deptno";
            comboBoxDept.DisplayMember = "Dname";
        }

        private void FillingDataGridView(int deptno)
        {
            List<BO_Employe> employes;
            string titre = string.Empty;
            if (deptno != 0)
            {
                employes = BLL_OAI.GetEmpByDeptno(deptno);
                titre = BLL_OAI.GetDeptByDeptno(deptno).Dname;
            }
            else
            {
                employes = BLL_OAI.GetAllEmp();
                titre = "TOUS";
            }
            label2.Text = titre;
            employes.Sort();
            bindingSourceEmp.DataSource = employes;
            dataGridViewEmp.DataSource = bindingSourceEmp;
            this.ModelingByDataGridView();
        }


        private void ModelingByDataGridView()
        {
            dataGridViewEmp.Columns["Deptno"].Visible = false;
            dataGridViewEmp.Columns["Empno"].Visible = false;
            label3.Text = $"Nbre employé(s): {dataGridViewEmp.RowCount}";
            dataGridViewEmp.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            int totalRowHeight = dataGridViewEmp.ColumnHeadersHeight;

            foreach (DataGridViewRow row in dataGridViewEmp.Rows)
            {
                totalRowHeight += row.Height;
            }

            dataGridViewEmp.Height = totalRowHeight;
        }

        #endregion "Méthodes propres à la classe"

        #region "Méthodes evenementielles"

        private void bindingSourceDept_CurrentItemChanged(object sender, EventArgs e)
        {
            if (bindingSourceDept.Current != null)
            {
                _RecordedDept = (BO_Departement)bindingSourceDept.Current;

                this.FillingDataGridView(_RecordedDept.Deptno);
            }

        }
        private void buttonGetAllDept_Click(object sender, EventArgs e)
        {
            _RecordedDept = new BO_Departement();
            FillingDataGridView(_RecordedDept.Deptno);
        }

        private void bindingSourceEmp_CurrentItemChanged(object sender, EventArgs e)
        {
            if (bindingSourceEmp.Current != null)
            {
                _RecordedEmploye = (BO_Employe)bindingSourceEmp.Current;
                textBox1.Text = _RecordedDept.Dname;
                textBox2.Text = _RecordedEmploye.Nom;
                textBox3.Text = _RecordedEmploye.Job;
                textBox4.Text = _RecordedEmploye.Salaire.ToString();
                textBox2.Enabled = true;
                buttonUpdateEmp.Enabled = true;
            }
            else
            {
                _RecordedEmploye = null;
                textBox1.Text = string.Empty;
                textBox2.Text = string.Empty;
                textBox3.Text = string.Empty;
                textBox4.Text = string.Empty;
                textBox2.Enabled = false;
                buttonUpdateEmp.Enabled = false;
                if (bindingSourceDept.Current != null)
                {
                    textBox1.Text = _RecordedDept.Dname;
                }

            }
        }


        private void buttonUpdateEmp_Click(object sender, EventArgs e)
        {
            if (bindingSourceEmp.Current != null)
            {
                _RecordedEmploye = (BO_Employe)bindingSourceEmp.Current;
                string oldName = _RecordedEmploye.Nom;
                string newName = textBox2.Text.ToUpper();
                int resultat = 0;
                _RecordedEmploye.Nom = newName;

                string message = $"{oldName} => {newName}";

                DialogResult dialogResult = MessageBox.Show(message, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                if (dialogResult == DialogResult.Yes)
                {
                    resultat = BLL_OAI.UpdateEmp(_RecordedEmploye);
                }

                if (resultat != 0)
                {
                    this.FillingDataGridView(_RecordedDept.Deptno);
                }

            }
        }
        #endregion "Méthodes evenementielles"

    }

}
