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
    public partial class ReportAForm : Form
    {
        public ReportAForm()
        {
            InitializeComponent();
        }

        private void ReportAForm_Load(object sender, EventArgs e)
        {
            var collectionsStaff = DataAccess.GetStaff();
            List<Staff> listDirector = new List<Staff>();
            List<Staff> listChif = new List<Staff>();

            foreach (var item in collectionsStaff)
            {
                if ((DateTime.Now.Year - item.DateAcceptance.Year) >= 5)
                {
                    listDirector.Add(item);
                }

                if ((DateTime.Now.Year - item.DateAcceptance.Year) >= 3)
                {
                    listChif.Add(item);
                }
            }
            InfoDirectorGrid.DataSource = listDirector;
            InfoChifGrid.DataSource = listChif;
        }

        private void InfoDirectorGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (this.InfoDirectorGrid.Columns["ServiceNumber"] != null)
            {
                this.InfoDirectorGrid.Columns["ServiceNumber"].Visible = false;
            }

            if (this.InfoDirectorGrid.Columns["Experience"] != null)
            {
                this.InfoDirectorGrid.Columns["Experience"].Visible = false;
            }

            if (this.InfoDirectorGrid.Columns["DateAcceptance"] != null)
            {
                this.InfoDirectorGrid.Columns["DateAcceptance"].Visible = false;
            }

            if (this.InfoDirectorGrid.Columns["DateDismissal"] != null)
            {
                this.InfoDirectorGrid.Columns["DateDismissal"].Visible = false;
            }

            if (this.InfoDirectorGrid.Columns["NameFIO"] != null)
            {
                this.InfoDirectorGrid.Columns["NameFIO"].HeaderText = "Ф.И.О";
            }

            if (this.InfoDirectorGrid.Columns["Post"] != null)
            {
                this.InfoDirectorGrid.Columns["Post"].HeaderText = "Должность";
            }

            if (this.InfoDirectorGrid.Columns["Branch"] != null)
            {
                this.InfoDirectorGrid.Columns["Branch"].HeaderText = "Филиал";
            }

            if (this.InfoDirectorGrid.Columns["DateBirth"] != null)
            {
                this.InfoDirectorGrid.Columns["DateBirth"].HeaderText = "День Рождения";
            }

            if (this.InfoDirectorGrid.Columns["Department"] != null)
            {
                this.InfoDirectorGrid.Columns["Department"].HeaderText = "Отдел";
            }

            if (this.InfoDirectorGrid.Columns["AddressResidence"] != null)
            {
                this.InfoDirectorGrid.Columns["AddressResidence"].Visible = false; ;
            }

            if (this.InfoDirectorGrid.Columns["Education"] != null)
            {
                this.InfoDirectorGrid.Columns["Education"].Visible = false;
            }

            if (this.InfoDirectorGrid.Columns["CityResidence"] != null)
            {
                this.InfoDirectorGrid.Columns["CityResidence"].Visible = false;
            }
        }

        private void InfoChifGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (this.InfoChifGrid.Columns["ServiceNumber"] != null)
            {
                this.InfoChifGrid.Columns["ServiceNumber"].Visible = false;
            }

            if (this.InfoChifGrid.Columns["Experience"] != null)
            {
                this.InfoChifGrid.Columns["Experience"].Visible = false;
            }

            if (this.InfoChifGrid.Columns["DateAcceptance"] != null)
            {
                this.InfoChifGrid.Columns["DateAcceptance"].Visible = false;
            }

            if (this.InfoChifGrid.Columns["DateDismissal"] != null)
            {
                this.InfoChifGrid.Columns["DateDismissal"].Visible = false;
            }

            if (this.InfoChifGrid.Columns["NameFIO"] != null)
            {
                this.InfoChifGrid.Columns["NameFIO"].HeaderText = "Ф.И.О";
            }

            if (this.InfoChifGrid.Columns["Post"] != null)
            {
                this.InfoChifGrid.Columns["Post"].HeaderText = "Должность";
            }

            if (this.InfoChifGrid.Columns["Branch"] != null)
            {
                this.InfoChifGrid.Columns["Branch"].HeaderText = "Филиал";
            }

            if (this.InfoChifGrid.Columns["DateBirth"] != null)
            {
                this.InfoChifGrid.Columns["DateBirth"].HeaderText = "День Рождения";
            }

            if (this.InfoChifGrid.Columns["Department"] != null)
            {
                this.InfoChifGrid.Columns["Department"].HeaderText = "Отдел";
            }

            if (this.InfoChifGrid.Columns["AddressResidence"] != null)
            {
                this.InfoChifGrid.Columns["AddressResidence"].Visible = false; ;
            }

            if (this.InfoChifGrid.Columns["Education"] != null)
            {
                this.InfoChifGrid.Columns["Education"].Visible = false;
            }

            if (this.InfoChifGrid.Columns["CityResidence"] != null)
            {
                this.InfoChifGrid.Columns["CityResidence"].Visible = false;
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            base.Close();
        }
    }
}
