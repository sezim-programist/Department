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
    public partial class AddEditPositionsForm : Form
    {
        public Positions CurrentPositions { get; }

        public AddEditPositionsForm()
        {
            InitializeComponent();
        }

        public AddEditPositionsForm(Positions positions)
        {
            InitializeComponent();
            CurrentPositions = positions;
        }

        /// <summary>
        /// Сохраняем изменения в сотруднике
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSave_Click(object sender, EventArgs e)
        {
            bool flag = this.CurrentPositions != null;
            if (flag)
            {
                bool flag2 = this.txtPost.Text.Length > 0;

                if (flag2)
                {
                    this.CurrentPositions.Post = this.txtPost.Text;
                    this.CurrentPositions.ExperienceEquirements = (int)this.numericExp.Value;
                    this.CurrentPositions.AdditionalVacation = (int)this.numericDays.Value;

                    int num = DataAccess.UpdatePost(this.CurrentPositions);
                    bool flag3 = num > 0;
                    if (flag3)
                    {
                        base.Close();
                    }
                }
            }
            else
            {
                bool flag4 = this.txtPost.Text.Length > 0;
                if (flag4)
                {
                    Positions newPost = new Positions
                    {
                      Post = this.txtPost.Text,
                      ExperienceEquirements = (int)this.numericExp.Value,
                      AdditionalVacation = (int)this.numericDays.Value
                };
                    int num2 = DataAccess.InsertPost(newPost);
                    bool flag5 = num2 > 0;
                    if (flag5)
                    {
                        MessageBox.Show("Должность добавлена!");
                        base.Close();
                    }
                }
            }
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
        /// загружаем данные в поля
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddEditPositionsForm_Load(object sender, EventArgs e)
        {
            bool flag = this.CurrentPositions != null;
            if (flag)
            {
                this.txtPost.Text= this.CurrentPositions.Post;
                this.numericExp.Value= this.CurrentPositions.ExperienceEquirements;
                this.numericDays.Value = this.CurrentPositions.AdditionalVacation;
            }
        }
    }
}
