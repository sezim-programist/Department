using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Отдел_кадров.Entities;

namespace Отдел_кадров.WinForm
{
    public partial class BranchesForm : Form
    {
        public BranchesForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Поиск по критерию
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSearch_Click(object sender, EventArgs e)
        {

            string txtBranch = "";
            if (boxBranches.SelectedItem != null)
                txtBranch = boxBranches.SelectedItem.ToString();
            this.InfoBranchesGrid.DataSource = DataAccess.GetBranches(txtBranch, txtEmail.Text);

        }

        /// <summary>
        /// Добавить филиал открываем форму
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            AddEditBranchesForm branchesForm = new AddEditBranchesForm();
            branchesForm.FormClosing += BranchesForm_FormClosing;
            branchesForm.ShowDialog();
        }

        /// <summary>
        /// при закрытии одной из форм обновится датагрид при событии
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BranchesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            BtnSearch_Click(null,null);
        }

        /// <summary>
        /// открываем форму изменить данные
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            bool flag = this.InfoBranchesGrid.SelectedRows.Count > 0;
            if (flag)
            {
                Branches branches = this.InfoBranchesGrid.SelectedRows[0].DataBoundItem as Branches;
                AddEditBranchesForm branchesForm = new AddEditBranchesForm(branches);
                branchesForm.FormClosing += BranchesForm_FormClosing;
                branchesForm.ShowDialog();
            }
        }

        /// <summary>
        /// Закрыть форму
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnExit_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        /// <summary>
        /// Производим инициализацию box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BranchesForm_Load(object sender, EventArgs e)
        {
            this.InfoBranchesGrid.DataSource = DataAccess.GetBranches();
          
            List<Branches> branch = DataAccess.GetBranches();
            this.boxBranches.DataSource = branch;
            this.boxBranches.SelectedItem = null;
            this.boxBranches.AutoCompleteSource = AutoCompleteSource.CustomSource;
            this.boxBranches.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            AutoCompleteStringCollection autoCompleteStringCollection = new AutoCompleteStringCollection();
            foreach (Branches branch1 in branch)
            {
                autoCompleteStringCollection.Add(branch1.ToString());
            }
            this.boxBranches.AutoCompleteCustomSource = autoCompleteStringCollection;
        }

        /// <summary>
        /// Скрываем не нужные колонки и переименновываем те что остались на русский
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InfoBranchesGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (this.InfoBranchesGrid.Columns["IDBranch"] != null)
            {
                this.InfoBranchesGrid.Columns["IDBranch"].Visible = false;
            }

            if (this.InfoBranchesGrid.Columns["City"] != null)
            {
                this.InfoBranchesGrid.Columns["City"].HeaderText = "Город";
            }

            if (this.InfoBranchesGrid.Columns["LegalAddress"] != null)
            {
                this.InfoBranchesGrid.Columns["LegalAddress"].HeaderText = "Юридический адрес";
            }

            if (this.InfoBranchesGrid.Columns["NumberInhabitants"] != null)
            {
                this.InfoBranchesGrid.Columns["NumberInhabitants"].HeaderText = "Число жителей";
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            bool flag = this.InfoBranchesGrid.SelectedRows.Count > 0;
            if (flag)
            {
                DialogResult res = MessageBox.Show("Будет удален филиал и все его сотрудники вы уверены?","Внимание!",MessageBoxButtons.OKCancel);
                if (res==DialogResult.OK)
                {


                    Branches branches = this.InfoBranchesGrid.SelectedRows[0].DataBoundItem as Branches;
                    List<Staff> staff = DataAccess.GetStaff();

                    foreach (var item in staff)
                    {
                        if (item.Branch.City == branches.City)
                        {
                            DataAccess.DeleteStaff(item);
                        }
                    }
                    DataAccess.DeleteBranches(branches);
                    MessageBox.Show("Успешно удалили филиал и его сотрудников!");
                }
            }
            BranchesForm_Load(null,null);
        }
    }
}
