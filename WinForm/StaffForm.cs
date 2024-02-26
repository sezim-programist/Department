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
    public partial class StaffForm : Form
    {
        public StaffForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Производим инициализацию всех box и Grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StaffForm_Load(object sender, EventArgs e)
        {
            this.InfoStaffGrid.DataSource = DataAccess.GetStaff();
            List<Positions> post1 = DataAccess.GetPositions();
            this.boxPositions.DataSource = post1;
            this.boxPositions.SelectedItem = null;
            this.boxPositions.AutoCompleteSource = AutoCompleteSource.CustomSource;
            this.boxPositions.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            AutoCompleteStringCollection autoCompleteStringCollection = new AutoCompleteStringCollection();
            foreach (Positions post2 in post1)
            {
                autoCompleteStringCollection.Add(post2.ToString());
            }
            this.boxPositions.AutoCompleteCustomSource = autoCompleteStringCollection;


            List<Branches> branch = DataAccess.GetBranches();
            this.boxBranches.DataSource = branch;
            this.boxBranches.SelectedItem = null;
            this.boxBranches.AutoCompleteSource = AutoCompleteSource.CustomSource;
            this.boxBranches.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            AutoCompleteStringCollection autoCompleteStringCollection2 = new AutoCompleteStringCollection();
            foreach (Branches branch1 in branch)
            {
                autoCompleteStringCollection2.Add(branch1.ToString());
            }
            this.boxBranches.AutoCompleteCustomSource = autoCompleteStringCollection2;



        }

        /// <summary>
        /// Найти сотрудника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string txtPost = "";
            if (boxPositions.SelectedItem!=null)
                txtPost =  boxPositions.SelectedItem.ToString();
            string txtBranches = "";
            if (boxBranches.SelectedItem != null)
                 txtBranches = boxBranches.SelectedItem.ToString();
            this.InfoStaffGrid.DataSource = DataAccess.GetStaff(txtFIO.Text, txtPost, txtBranches);
        }

        /// <summary>
        /// Добавить сотрудника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            AddEditStaffForm staffForm = new AddEditStaffForm();
            staffForm.FormClosing += StaffForm_FormClosing;
            staffForm.ShowDialog();
        }

        private void StaffForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            BtnSearch_Click(null,null);
        }
    

        /// <summary>
        /// Редактировать сотрудника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            bool flag = this.InfoStaffGrid.SelectedRows.Count > 0;
            if (flag)
            {
                Staff staff = this.InfoStaffGrid.SelectedRows[0].DataBoundItem as Staff;
                AddEditStaffForm staffForm = new AddEditStaffForm(staff);
                staffForm.FormClosing += StaffForm_FormClosing;
                staffForm.ShowDialog();
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
        /// Скрываем не нужные колонки и переименновываем те что остались на русский
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InfoStaffGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (this.InfoStaffGrid.Columns["ServiceNumber"] != null)
            {
                this.InfoStaffGrid.Columns["ServiceNumber"].Visible = false;
            }

            if (this.InfoStaffGrid.Columns["Experience"] != null)
            {
                this.InfoStaffGrid.Columns["Experience"].Visible = false;
            }

            if (this.InfoStaffGrid.Columns["DateAcceptance"] != null)
            {
                this.InfoStaffGrid.Columns["DateAcceptance"].Visible = false;
            }

            if (this.InfoStaffGrid.Columns["DateDismissal"] != null)
            {
                this.InfoStaffGrid.Columns["DateDismissal"].HeaderText = "Дата увольнения";
            }

            if (this.InfoStaffGrid.Columns["NameFIO"] != null)
            {
                this.InfoStaffGrid.Columns["NameFIO"].HeaderText = "Ф.И.О";
            }

            if (this.InfoStaffGrid.Columns["Post"] != null)
            {
                this.InfoStaffGrid.Columns["Post"].HeaderText = "Должность";
            }

            if (this.InfoStaffGrid.Columns["Branch"] != null)
            {
                this.InfoStaffGrid.Columns["Branch"].HeaderText = "Филиал";
            }

            if (this.InfoStaffGrid.Columns["DateBirth"] != null)
            {
                this.InfoStaffGrid.Columns["DateBirth"].HeaderText = "День Рождения";
            }

            if (this.InfoStaffGrid.Columns["Department"] != null)
            {
                this.InfoStaffGrid.Columns["Department"].HeaderText = "Отдел";
            }

            if (this.InfoStaffGrid.Columns["AddressResidence"] != null)
            {
                this.InfoStaffGrid.Columns["AddressResidence"].Visible = false; ;
            }

            if (this.InfoStaffGrid.Columns["Education"] != null)
            {
                this.InfoStaffGrid.Columns["Education"].Visible = false;
            }

            if (this.InfoStaffGrid.Columns["CityResidence"] != null)
            {
                this.InfoStaffGrid.Columns["CityResidence"].Visible = false;
            }
        }

        /// <summary>
        /// Удаление сотрудника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            bool flag = this.InfoStaffGrid.SelectedRows.Count > 0;
            if (flag)
            {
             
                Staff staff = this.InfoStaffGrid.SelectedRows[0].DataBoundItem as Staff;
                DataAccess.DeleteStaff(staff);
                MessageBox.Show("Успешно удалили сотрудника!");
            }

            StaffForm_Load(null, null);
        }
    }
}
