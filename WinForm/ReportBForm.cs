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
    public partial class ReportBForm : Form
    {
        public ReportBForm()
        {
            InitializeComponent();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            base.Close();
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
                this.InfoGrid.Columns["CityResidence"].HeaderText = "Город прописки" ;
            }
        }

        private void ReportBFormcs_Load(object sender, EventArgs e)
        {
            //  B.Найти сотрудников, которые работают не в том же городе, в котором прописаны.
            var collectionsStaff = DataAccess.GetStaff();
            List<Staff> list= new List<Staff>();
          

            foreach (var item in collectionsStaff)
            {
                if (item.CityResidence!=item.Branch.City)
                {
                    list.Add(item);
                }
            }
            InfoGrid.DataSource = list;
        }
    }
}
