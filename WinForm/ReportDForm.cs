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
    public partial class ReportDForm : Form
    {
        public ReportDForm()
        {
            InitializeComponent();
        }

        private void ReportDForm_Load(object sender, EventArgs e)
        {
            // Установите строку пользовательского формата.
            dateTimePicker1.CustomFormat = "MMMM yyyy";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;

            // Установите флажок и отобразите элемент управления как элемент управления вверх-вниз.
            dateTimePicker1.ShowUpDown = true;
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            //D.Подсчитать сколько было принято сотрудников на работу в каждом месяце года,
            //заданного пользователем.

            List<Staff> collection = DataAccess.GetStaff();

            List<Staff> ls = new List<Staff>();

            foreach (Staff item in collection)
            {
                if ((dateTimePicker1.Value.Year == item.DateAcceptance.Year) &&
                     dateTimePicker1.Value.Month == item.DateAcceptance.Month)
                {
                    ls.Add(item);
                }
            }

            InfoGrid.DataSource = ls;
        }

        private void InfoGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (this.InfoGrid.Columns["ServiceNumber"] != null)
            {
                this.InfoGrid.Columns["ServiceNumber"].Visible = false;
            }

            if (this.InfoGrid.Columns["Experience"] != null)
            {
                this.InfoGrid.Columns["Experience"].Visible = false;
            }

            if (this.InfoGrid.Columns["DateAcceptance"] != null)
            {
                this.InfoGrid.Columns["DateAcceptance"].Visible = false;
            }

            if (this.InfoGrid.Columns["DateDismissal"] != null)
            {
                this.InfoGrid.Columns["DateDismissal"].Visible = false;
            }

            if (this.InfoGrid.Columns["NameFIO"] != null)
            {
                this.InfoGrid.Columns["NameFIO"].HeaderText = "Ф.И.О";
            }

            if (this.InfoGrid.Columns["Post"] != null)
            {
                this.InfoGrid.Columns["Post"].HeaderText = "Должность";
            }

            if (this.InfoGrid.Columns["Branch"] != null)
            {
                this.InfoGrid.Columns["Branch"].HeaderText = "Филиал";
            }

            if (this.InfoGrid.Columns["DateBirth"] != null)
            {
                this.InfoGrid.Columns["DateBirth"].HeaderText = "День Рождения";
            }

            if (this.InfoGrid.Columns["Department"] != null)
            {
                this.InfoGrid.Columns["Department"].HeaderText = "Отдел";
            }

            if (this.InfoGrid.Columns["AddressResidence"] != null)
            {
                this.InfoGrid.Columns["AddressResidence"].Visible = false; ;
            }

            if (this.InfoGrid.Columns["Education"] != null)
            {
                this.InfoGrid.Columns["Education"].Visible = false;
            }

            if (this.InfoGrid.Columns["CityResidence"] != null)
            {
                this.InfoGrid.Columns["CityResidence"].Visible = false;
            }
        }
    }
}
