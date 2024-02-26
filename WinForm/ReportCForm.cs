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
    public partial class ReportCForm : Form
    {
        public ReportCForm()
        {
            InitializeComponent();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void ReportCForm_Load(object sender, EventArgs e)
        {
            //  Найти филиалы, где количество сотрудников, работающих на одной должности,
            //  больше, чем необходимо

            int manager = 2; //среднее число менеджеров на 100т населения
            int accountant = 3; //среднее число бухгалтеров
            int worker = 10; //среднее число рабочих

            var collectionsBraches = DataAccess.GetStaff();
         
            CoutBrache listManager = new CoutBrache();
            CoutBrache listAccountant = new CoutBrache();
            CoutBrache listWorker = new CoutBrache();

         
            foreach (Staff item in collectionsBraches)
            {
                if (item.Post.ToString() == "Менеджер")
                {
                    if (!listManager.CheckCity(item.Branch.City))
                        listManager.Add(item.Branch.City, item.Branch.NumberInhabitants, item.Post.ToString());
                    listManager.Size++;
                }

                if (item.Post.ToString() == "Бухгалтер")
                {
                    
                    if (!listAccountant.CheckCity(item.Branch.City))
                        listAccountant.Add(item.Branch.City, item.Branch.NumberInhabitants, item.Post.ToString());
                        listAccountant.Size++;
                }

                if (item.Post.ToString() == "Рабочий")
                {
                    if (!listWorker.CheckCity(item.Branch.City))
                        listWorker.Add(item.Branch.City, item.Branch.NumberInhabitants, item.Post.ToString());
                    listWorker.Size++;
                }
            }

            FillData(listManager, manager);
            FillData(listAccountant, accountant);
            FillData(listWorker, worker);
        }

        private void FillData(CoutBrache list, int size)
        {
            //     if(list.Size>size)
            foreach (var item in list.Calculate(size))
            {
                InfoRich.AppendText(item+Environment.NewLine);
               
            }
        }

        /// <summary>
        /// Вспомогательный класс
        /// </summary>
        public class CoutBrache
        {
          public  Dictionary<string, int> collection = new Dictionary<string, int>();
          public int Size { get; set; }
          private string Name { get; set; }


            internal void Add(string city, int numberInhabitants, string name)
            {
                collection.Add(city, numberInhabitants);
                this.Name = name;
            }

            internal List<string> Calculate(int accountant)
            {
                List<string> ls = new List<string>();
                foreach (var item in collection)
                {
                    int average = item.Value / 100000;
                    if (average > accountant)
                    {
                        ls.Add($"В филиале города {item.Key} сотрудников на должности {Name} находится в норме\n");
                    }
                    else
                    {
                        ls.Add($"В филиале города {item.Key} сотрудников на должности {Name} превышает допустимую норму\n");

                    }
                }
                return ls;
            }

            internal bool CheckCity(string city)
            {
                return collection.ContainsKey(city); 
            }
        }
    }
}
