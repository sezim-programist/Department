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
    public partial class AddEditBranchesForm : Form
    {
        public Branches CurrentBranches { get; set; }

        public AddEditBranchesForm()
        {
            InitializeComponent();
        }

        public AddEditBranchesForm(Branches branches)
        {
            InitializeComponent();
            CurrentBranches = branches;
        }

        /// <summary>
        /// Сохранить добавленный филиал
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSave_Click(object sender, EventArgs e)
        {
            bool flag = this.CurrentBranches != null;
            if (flag)
            {
                bool flag2 = this.txtCity.Text.Length > 0 &&
                    this.txtEmail.Text.Length > 0 && txtRegistration.Text.Length > 0 ;

                if (flag2)
                {
                    this.CurrentBranches.City = this.txtCity.Text;
                    this.CurrentBranches.Email = this.txtEmail.Text;
                    this.CurrentBranches.LegalAddress = this.txtRegistration.Text;
                    this.CurrentBranches.NumberInhabitants = (int) this.numericPopulation.Value;

                    int num = DataAccess.UpdateBranches(this.CurrentBranches);
                    bool flag3 = num > 0;
                    if (flag3)
                    {
                        base.Close();
                    }
                }
            }
            else
            {
                //проверка на существование в городе  филиала

               if(CheckCityBranche()) return;

                bool flag4 = this.txtCity.Text.Length > 0 &&
                    this.txtEmail.Text.Length > 0 && txtRegistration.Text.Length > 0;
                if (flag4)
                {
                    Branches newBranche = new Branches
                    {
                        City = this.txtCity.Text,
                        Email = this.txtEmail.Text,
                        LegalAddress = this.txtRegistration.Text,
                        NumberInhabitants = (int)this.numericPopulation.Value
                    };
                    int num2 = DataAccess.InsertBranches(newBranche);
                    bool flag5 = num2 > 0;
                    if (flag5)
                    {
                        MessageBox.Show("Филиал добавлен!");
                        base.Close();
                    }
                }
            }
        }

        /// <summary>
        /// Метод проверки на существования филиала в городе
        /// </summary>
        /// <returns></returns>
        private bool CheckCityBranche()
        {
            List<Branches> tmpBranch = DataAccess.GetBranches();
            foreach (var item in tmpBranch)
            {
                if (item.City == this.txtCity.Text)
                {
                    MessageBox.Show("Филиал в этом городе уже существует! Измените город");
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// закрываем форму
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnClose_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        /// <summary>
        /// инициализация данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddEditBranchesForm_Load(object sender, EventArgs e)
        {
            bool flag = this.CurrentBranches != null;
            if (flag)
            {
                this.txtCity.Text = this.CurrentBranches.City;
                this.txtRegistration.Text = this.CurrentBranches.LegalAddress;
                this.txtEmail.Text = this.CurrentBranches.Email;
                this.numericPopulation.Value = this.CurrentBranches.NumberInhabitants;
            }
        }
    }
}
