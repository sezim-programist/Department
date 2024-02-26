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
    public partial class AddEditStaffForm : Form
    {
        public AddEditStaffForm()
        {
            InitializeComponent();
            dtDismiss.Enabled = false;
        }

        public AddEditStaffForm(Staff staff)
        {
            InitializeComponent();
            CurrentStaff = staff;
        }

        public Staff CurrentStaff { get; set; }

        /// <summary>
        /// инициализировать box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddEditStaffForm_Load(object sender, EventArgs e)
        {
            List<Branches> branches = DataAccess.GetBranches();
            this.comboBranches.DataSource = branches;
            this.comboBranches.AutoCompleteSource = AutoCompleteSource.CustomSource;
            this.comboBranches.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            AutoCompleteStringCollection autoCompleteStringCollection = new AutoCompleteStringCollection();
            foreach (Branches branches2 in branches)
            {
                autoCompleteStringCollection.Add(branches2.ToString());
            }
            this.comboBranches.AutoCompleteCustomSource = autoCompleteStringCollection;


            List<Positions> positions = DataAccess.GetPositions();
            this.comboPosition.DataSource = positions;
            this.comboPosition.AutoCompleteSource = AutoCompleteSource.CustomSource;
            this.comboPosition.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            AutoCompleteStringCollection autoCompleteStringCollection2 = new AutoCompleteStringCollection();
            foreach (Positions positions2 in positions)
            {
                autoCompleteStringCollection2.Add(positions2.ToString());
            }
            this.comboPosition.AutoCompleteCustomSource = autoCompleteStringCollection2;


            bool flag = this.CurrentStaff != null;
            if (flag)
            {
                this.txtFIO.Text = this.CurrentStaff.NameFIO;
                this.txtDepartment.Text = this.CurrentStaff.Department;
                this.txtRegistrationAdress.Text = this.CurrentStaff.AddressResidence;
                this.txtEducation.Text = this.CurrentStaff.Education;
                this.txtRegistrationCity.Text = this.CurrentStaff.CityResidence;
                this.comboBranches.SelectedItem = this.CurrentStaff.Branch;
                this.comboPosition.SelectedItem = this.CurrentStaff.Post;

                this.dtHire.Value = this.CurrentStaff.DateAcceptance;

                //так как у нас поле уволенния может быть пустым делаем грабли
                if (this.CurrentStaff.DateDismissal !=null)
                {
                    this.dtDismiss.Value = (DateTime)this.CurrentStaff.DateDismissal;
                }
                else
                {
                    dtDismiss.Format = DateTimePickerFormat.Custom;
                    dtDismiss.CustomFormat = " ";
                }

                this.dtBrith.Value = this.CurrentStaff.DateBirth;
            }
            else
            {
                this.comboBranches.SelectedItem = null;
                this.comboPosition.SelectedItem = null;
            }
        }

        /// <summary>
        /// Сохранить добавленого сотрудника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSave_Click(object sender, EventArgs e)
        {
            bool flag = this.CurrentStaff != null;
            if (flag)
            {
                bool flag2 = this.txtFIO.Text.Length > 0 &&
                    this.txtDepartment.Text.Length > 0 && txtRegistrationAdress.Text.Length > 0 &&
                    this.txtEducation.Text.Length > 0 && txtRegistrationCity.Text.Length > 0 &&
                    this.comboBranches.SelectedItem != null && this.comboPosition.SelectedItem != null;

                if (flag2)
                {
                    if(ChechYearDirector()) return;
                    if (ChechYearChief()) return;
                    
                    this.CurrentStaff.NameFIO = this.txtFIO.Text;
                    this.CurrentStaff.Department = this.txtDepartment.Text;
                    this.CurrentStaff.AddressResidence = this.txtRegistrationAdress.Text;
                    this.CurrentStaff.Education = this.txtEducation.Text;
                    this.CurrentStaff.CityResidence = this.txtRegistrationCity.Text;


                    this.CurrentStaff.Branch = (this.comboBranches.SelectedItem as Branches);
                    this.CurrentStaff.Post = (this.comboPosition.SelectedItem as Positions);

                    if(dtDismiss.Format== DateTimePickerFormat.Long)
                    {
                        CurrentStaff.DateDismissal = dtDismiss.Value;
                    }
                  
                    int num = DataAccess.UpdateStaff(this.CurrentStaff);
                    bool flag3 = num > 0;
                    if (flag3)
                    {
                        MessageBox.Show("Изменения в данные сотрудника успешно внесены!");
                        base.Close();
                    }
                }
            }
            else
            {

                bool flag4 = this.txtFIO.Text.Length > 0 &&
                    this.txtDepartment.Text.Length > 0 && txtRegistrationAdress.Text.Length > 0 &&
                    this.txtEducation.Text.Length > 0 && txtRegistrationCity.Text.Length > 0 &&
                    this.comboBranches.SelectedItem != null && this.comboPosition.SelectedItem != null;

                if (flag4)
                {
                    if(CheckAddDirector()) return;
                    if (CheckAddChief()) return;

                    Staff newStaff = new Staff
                    {
                        NameFIO = this.txtFIO.Text,
                        Department = this.txtDepartment.Text,
                        AddressResidence = this.txtRegistrationAdress.Text,
                        Education = this.txtEducation.Text,
                        CityResidence = this.txtRegistrationCity.Text,
                        Branch = (this.comboBranches.SelectedItem as Branches),
                        Post = (this.comboPosition.SelectedItem as Positions),
                        DateAcceptance = this.dtHire.Value,
                        DateBirth = this.dtBrith.Value,
                        DateDismissal = null
                    };
                    int num2 = DataAccess.InsertStaff(newStaff);
                    bool flag5 = num2 > 0;
                    if (flag5)
                    {
                        MessageBox.Show("Сотрудник добавлен!");
                        base.Close();
                    }
                }
            }
        }

        /// <summary>
        /// Метод проверки не является ли новым сотрудником в качестве директора
        /// </summary>
        /// <returns></returns>
        private bool CheckAddDirector()
        {
            Positions post = (this.comboPosition.SelectedItem as Positions);
            if (post.ToString() == "Директор")
            {
                MessageBox.Show("Вы не можете поставить нового сотрудника на должность директора, он должен отработать в фирме не менее 5 лет!");
                 return true;
            }
            return false;
        }

        /// <summary>
        /// Метод определения минимального стажа на должность директора
        /// </summary>
        /// <returns></returns>
        private bool ChechYearDirector()
        {
            Positions post = (this.comboPosition.SelectedItem as Positions);
            if (post.ToString() == "Директор")
            {
       
                if ((DateTime.Now.Year - CurrentStaff.DateAcceptance.Year) < post.ExperienceEquirements)
                {
                    MessageBox.Show($"Стаж на должность директора должен быть не мение {post.ExperienceEquirements} лет!");
                     return true;
                }
            }
            return false;
        }


        /// <summary>
        /// Метод проверки не является ли новым сотрудником в качестве начальника отдела
        /// </summary>
        /// <returns></returns>
        private bool CheckAddChief()
        {
            Positions post = (this.comboPosition.SelectedItem as Positions);
            if (post.ToString() == "Начальник отдела")
            {
                MessageBox.Show("Вы не можете поставить нового сотрудника на должность начальника отдела, он должен отработать в фирме не менее 3 лет!");
                return true;
            }
            return false;
        }


        /// <summary>
        /// Метод определения минимального стажа на должность начальника отдела
        /// </summary>
        /// <returns></returns>
        private bool ChechYearChief()
        {
            Positions post = (this.comboPosition.SelectedItem as Positions);
            if (post.ToString() == "Начальник отдела")
            {
                if ((DateTime.Now.Year - CurrentStaff.DateAcceptance.Year) >= 3)
                {
                    MessageBox.Show("Стаж на должность начальника отдела должен быть более 3 лет!");
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
        private void BtnExit_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void dtDismiss_MouseDown(object sender, MouseEventArgs e)
        {
            dtDismiss.Format = DateTimePickerFormat.Long;
        }
    }
}
