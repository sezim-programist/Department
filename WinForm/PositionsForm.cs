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
    public partial class PositionsForm : Form
    {
        public PositionsForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Инициализация box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PositionsForm_Load(object sender, EventArgs e)
        {
            this.InfoPositionsGrid.DataSource = DataAccess.GetPositions();

            List<Positions> positions = DataAccess.GetPositions();
            this.boxPositions.DataSource = positions;
            this.boxPositions.SelectedItem = null;
            this.boxPositions.AutoCompleteSource = AutoCompleteSource.CustomSource;
            this.boxPositions.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            AutoCompleteStringCollection autoCompleteStringCollection = new AutoCompleteStringCollection();
            foreach (Positions post in positions)
            {
                autoCompleteStringCollection.Add(post.ToString());
            }
            this.boxPositions.AutoCompleteCustomSource = autoCompleteStringCollection;
        }

        /// <summary>
        /// Поиск по критерию 0 0 это задел на будущее
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string txtPost = "";
            if (boxPositions.SelectedItem != null)
                txtPost = boxPositions.SelectedItem.ToString();
            this.InfoPositionsGrid.DataSource = DataAccess.GetPositions(txtPost, 0, 0);
        }

        /// <summary>
        /// Добавляем должность
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            AddEditPositionsForm positionsForm = new AddEditPositionsForm();
            positionsForm.FormClosing += PositionsForm_FormClosing;
            positionsForm.ShowDialog();
        }

        /// <summary>
        /// События возникающие при закрытии формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PositionsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            BtnSearch_Click(null, null);
        }

        /// <summary>
        /// Редактируем должность
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            bool flag = this.InfoPositionsGrid.SelectedRows.Count > 0;
            if (flag)
            {
                Positions positions = this.InfoPositionsGrid.SelectedRows[0].DataBoundItem as Positions;
                AddEditPositionsForm positionsForm = new AddEditPositionsForm(positions);
                positionsForm.FormClosing += PositionsForm_FormClosing;
                positionsForm.ShowDialog();
            }
        }

        /// <summary>
        /// Завершение работы с формой
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnExit_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void InfoPositionsGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (this.InfoPositionsGrid.Columns["IDPost"] != null)
            {
                this.InfoPositionsGrid.Columns["IDPost"].Visible = false;
            }

            if (this.InfoPositionsGrid.Columns["ExperienceEquirements"] != null)
            {
                this.InfoPositionsGrid.Columns["ExperienceEquirements"].HeaderText = "Необходимый стаж";
            }
            if (this.InfoPositionsGrid.Columns["Post"] != null)
            {
                this.InfoPositionsGrid.Columns["Post"].HeaderText = "Название должности";
            }
            if (this.InfoPositionsGrid.Columns["AdditionalVacation"] != null)
            {
                this.InfoPositionsGrid.Columns["AdditionalVacation"].HeaderText = "Доп. дни к отпуску";
            }
            
        }

        /// <summary>
        /// Удаляем должность
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            bool flag = this.InfoPositionsGrid.SelectedRows.Count > 0;
            if (flag)
            {
                DialogResult res = MessageBox.Show("Будет удалена должность и все сотрудники имеющие эту должность, вы уверены?", "Внимание!", MessageBoxButtons.OKCancel);
                if (res == DialogResult.OK)
                {


                    Positions positions = this.InfoPositionsGrid.SelectedRows[0].DataBoundItem as Positions;
                    List<Staff> staff = DataAccess.GetStaff();

                    foreach (Staff item in staff)
                    {
                        if (item.Post.Post == positions.Post)
                        {
                            DataAccess.DeleteStaff(item);
                        }
                    }
                    DataAccess.DeletePost(positions);
                    MessageBox.Show("Успешно удалили должность и сотрудников с этой должности!");
                }
            }
            PositionsForm_Load(null, null);
        }
    }
}
