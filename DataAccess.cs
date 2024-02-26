using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Отдел_кадров.DBDataSetTableAdapters;
using Отдел_кадров.Entities;

namespace Отдел_кадров
{
	class DataAccess
	{
		private static readonly DBDataSet dset = new DBDataSet();

		private static ДолжностиTableAdapter Post { get; set; }
		private static СотрудникиTableAdapter Staff { get; set; }
		private static ФилиалыTableAdapter Branches { get; set; }

		private static readonly DBDataSet.ДолжностиDataTable PostTable = dset.Должности;
		private static readonly DBDataSet.СотрудникиDataTable StaffTable = dset.Сотрудники;
		private static readonly DBDataSet.ФилиалыDataTable BranchesTable = dset.Филиалы;

		public static Branches CurrentBranch {get; set;}

		/// <summary>
		/// Инициализация класса
		/// </summary>
		static DataAccess()
		{
			Post = new ДолжностиTableAdapter();
			Staff = new СотрудникиTableAdapter();
			Branches = new ФилиалыTableAdapter();

			Post.Fill(PostTable);
			Staff.Fill(StaffTable);
			Branches.Fill(BranchesTable);
		}



		/// <summary>
		/// редактирование данных должностей
		/// </summary>
		/// <param name="currentPositions"></param>
		/// <returns></returns>
		public static int UpdatePost(Positions currentPositions)
		{
			int result = Post.UpdateQuery(currentPositions.Post, currentPositions.ExperienceEquirements, currentPositions.AdditionalVacation, currentPositions.IDPost);
			Post.Fill(PostTable);
			return result;
		}

		/// <summary>
		/// Редактирование данных филиалов
		/// </summary>
		/// <param name="currentBranches"></param>
		/// <returns></returns>

		public static int UpdateBranches(Branches currentBranches)
		{ 
            int result = Branches.UpdateQuery(currentBranches.City, currentBranches.LegalAddress, currentBranches.Email, currentBranches.NumberInhabitants, currentBranches.IDBranch);
            Branches.Fill(BranchesTable);
            return result;
        }

		/// <summary>
		/// Редактирование данных о сотрудниках
		/// </summary>
		/// <param name="currentStaff"></param>
		/// <returns></returns>
		public static int UpdateStaff(Staff currentStaff)
		{
			int result = Staff.UpdateQuery(currentStaff.NameFIO, currentStaff.DateAcceptance,currentStaff.Post.IDPost,
				currentStaff.Branch.IDBranch,currentStaff.DateBirth,currentStaff.DateDismissal,
				currentStaff.Department,currentStaff.AddressResidence,currentStaff.Education,currentStaff.CityResidence,
				currentStaff.ServiceNumber);
			Staff.Fill(StaffTable);
			return result;
		}



		/// <summary>
		/// Добавить должность
		/// </summary>
		/// <param name="currentPositions"></param>
		/// <returns></returns>
		public static int InsertPost(Positions currentPositions)
		{
			int result = Post.InsertQuery(currentPositions.Post, currentPositions.ExperienceEquirements, currentPositions.AdditionalVacation);
			Post.Fill(PostTable);
			return result;
		}

		/// <summary>
		/// Добавить сотрудника
		/// </summary>
		/// <param name="currentStaff"></param>
		/// <returns></returns>
		public static int InsertStaff(Staff currentStaff)
		{
			                                           // (ФИО,               ДатаПринятия,             Должность,                  Филиал,              ДатаРождения,              ДатаУвольнения,          Стаж,   Отдел,              АдресПрописки,             Образование,                  ГородПрописки)
			int result = Staff.InsertQuery(currentStaff.NameFIO,currentStaff.DateAcceptance,currentStaff.Post.IDPost, currentStaff.Branch.IDBranch, currentStaff.DateBirth, currentStaff.DateDismissal, currentStaff.Department,currentStaff.AddressResidence,currentStaff.Education,currentStaff.CityResidence);
			Staff.Fill(StaffTable);
			return result;
		}

		/// <summary>
		/// Добавить филиал
		/// </summary>
		/// <param name="currentBranches"></param>
		/// <returns></returns>
		public static int InsertBranches(Branches currentBranches)
		{
			int result = Branches.InsertQuery(currentBranches.City, currentBranches.LegalAddress, currentBranches.Email, currentBranches.NumberInhabitants);
			Branches.Fill(BranchesTable);
			return result;
		}



		/// <summary>
		/// удалить должность
		/// </summary>
		/// <param name="currentPositions"></param>
		public static void DeletePost(Positions currentPositions)
		{
			Post.DeleteQuery(currentPositions.IDPost);
			Post.Fill(PostTable);
		}

		/// <summary>
		/// удалить филиал
		/// </summary>
		/// <param name="currentBranches"></param>
		public static void DeleteBranches(Branches currentBranches)
		{
			Branches.DeleteQuery(currentBranches.IDBranch);
			Branches.Fill(BranchesTable);
		}

		/// <summary>
		/// удалить сотрудника
		/// </summary>
		/// <param name="currentStaff"></param>
		public static void DeleteStaff(Staff currentStaff)
		{
			Staff.DeleteQuery(currentStaff.ServiceNumber);
			Staff.Fill(StaffTable);
		}



		/// <summary>
		/// Получаем список филиалов по критерию выборки
		/// </summary>
		/// <param name="city"></param>
		/// <param name="email"></param>
		/// <param name="numberInhabitants"></param>
		/// <param name="legalAddress"></param>
		/// <returns></returns>
        public static List<Branches> GetBranches(string city, string email)
        {
            IEnumerable<Branches> source = GetBranches();
            bool flag = city.Length > 0;
            if (flag)
            {
                source = from x in source
                         where (x.City).ToLower().Contains(city.Trim().ToLower())
                         select x;
            }
            bool flag2 = email.Length > 0;
            if (flag2)
            {
                source = from x in source
                         where x.Email.ToLower().Contains(email.Trim().ToLower())
                         select x;
            }
          
            return source.ToList<Branches>();
        }

		/// <summary>
		/// Формируем список филиалов
		/// </summary>
		/// <returns></returns>
        public static List<Branches> GetBranches()
        {
            return (from x in BranchesTable
					select new Branches
					{
		             	Email = x["Email"] != System.DBNull.Value? x["Email"].ToString():null,
						IDBranch = x.IDФилиал,
						City = x["Город"] != System.DBNull.Value ? x["Город"].ToString() : null,
						NumberInhabitants = x["КолЖителей"] != System.DBNull.Value ? (int)x["КолЖителей"] : 0,
						LegalAddress = x["ЮрАдрес"] != System.DBNull.Value ? x["ЮрАдрес"].ToString() : null,
                    }).ToList<Branches>();
        }



		/// <summary>
		/// Получаем список должностей по критерию выборки
		/// </summary>
		/// <param name="post"></param>
		/// <param name="experienceEquirements"></param>
		/// <param name="additionalVacation"></param>
		/// <returns></returns>
		public static List<Positions> GetPositions(string post, int experienceEquirements, int additionalVacation)
		{
			IEnumerable<Positions> source = GetPositions();
			bool flag = post.Length > 0;
			if (flag)
			{
				source = from x in source
						 where (x.Post).ToLower().Contains(post.Trim().ToLower())
						 select x;
			}
			bool flag2 = experienceEquirements > 0;
			if (flag2)
			{
				source = from x in source
						 where x.ExperienceEquirements==experienceEquirements
						 select x;
			}
			bool flag3 = additionalVacation > 0;
			if (flag3)
			{
				return source.Select(x => x).Where(x => x.AdditionalVacation == additionalVacation).ToList();
			}
			return source.ToList<Positions>();
		}

		/// <summary>
		/// Формируем список должностей
		/// </summary>
		/// <returns></returns>
		public static List<Positions> GetPositions()
		{
			return (from x in PostTable
					select new Positions
					{
						IDPost = x.IDДолжность,
						Post = x.Должность,
						ExperienceEquirements = x.ТребованияСтажа,
						AdditionalVacation = x.ДополнительныйОтпуск,
					}).ToList<Positions>();
		}



		/// <summary>
		/// Формируем список сотрудников
		/// </summary>
		/// <returns></returns>
		public static List<Staff> GetStaffDismiss()
		{
			List<Staff> lsStaff = new List<Staff>();
            foreach (var item in StaffTable)
            {
				if (item.IsNull("ДатаУвольнения")) 
				{
					Staff staff = new Staff
					{
						AddressResidence = item.АдресПрописки,
						CityResidence = item.ГородПрописки,
						DateAcceptance = item.ДатаПринятия,
						DateBirth = item.ДатаРождения
					};

					//	if (DBNull.Value.Equals(x))
					if (!item.IsNull("ДатаУвольнения"))
						staff.DateDismissal = item.ДатаУвольнения;

					staff.Department = item.Отдел;
					staff.Education = item.Образование;

					if (!item.IsNull("Стаж"))
						staff.Experience = (int)item.Стаж;

					staff.NameFIO = item.ФИО;
					staff.ServiceNumber = item.IDСотрудник;

					staff.Branch = new Branches
					{
						Email = item.ФилиалыRow.Email,
						IDBranch = item.ФилиалыRow.IDФилиал,
						City = item.ФилиалыRow.Город,
						NumberInhabitants = item.ФилиалыRow.КолЖителей,
						LegalAddress = item.ФилиалыRow.ЮрАдрес
					};
					staff.Post = new Positions
					{
						IDPost = item.ДолжностиRow.IDДолжность,
						Post = item.ДолжностиRow.Должность,
						ExperienceEquirements = item.ДолжностиRow.ТребованияСтажа,
						AdditionalVacation = item.ДолжностиRow.ДополнительныйОтпуск,
					};
					lsStaff.Add(staff);
				}
			}
			return lsStaff;
		}

		/// <summary>
		/// Формируем список сотрудников
		/// </summary>
		/// <returns></returns>
		public static List<Staff> GetStaff()
		{
			return StaffTable.Select(delegate (DBDataSet.СотрудникиRow x)
			{
                Staff staff = new Staff
                {
                    AddressResidence = x.АдресПрописки,
                    CityResidence = x.ГородПрописки,
                    DateAcceptance = x.ДатаПринятия,
                    DateBirth = x.ДатаРождения
                };



                //	if (DBNull.Value.Equals(x))
                if (!x.IsNull("ДатаУвольнения"))
					staff.DateDismissal =x.ДатаУвольнения;

				staff.Department =x.Отдел;
				staff.Education =x.Образование;

				if (!x.IsNull("Стаж"))
					staff.Experience =(int)x.Стаж;

				staff.NameFIO =x.ФИО;
				staff.ServiceNumber =x.IDСотрудник;
				
				staff.Branch = new Branches
				{
					Email = x.ФилиалыRow.Email,
					IDBranch = x.ФилиалыRow.IDФилиал,
					City = x.ФилиалыRow.Город,
					NumberInhabitants = x.ФилиалыRow.КолЖителей,
					LegalAddress = x.ФилиалыRow.ЮрАдрес 
				};
				staff.Post = new Positions
				{
					IDPost = x.ДолжностиRow.IDДолжность,
					Post = x.ДолжностиRow.Должность,
					ExperienceEquirements = x.ДолжностиRow.ТребованияСтажа,
					AdditionalVacation = x.ДолжностиRow.ДополнительныйОтпуск,
				};
				return staff;
			}).ToList<Staff>();
		}
		public static List<Staff> GetStaffDismiss(string txtFIO, string txtPost, string txtBranches)
		{
			IEnumerable<Staff> source = GetStaffDismiss();
			bool flag = txtFIO.Length > 0;
			if (flag)
			{
				source = from x in source
						 where (x.NameFIO).ToLower().Contains(txtFIO.Trim().ToLower())
						 select x;
			}
			bool flag2 = txtPost.Length > 0;
			if (flag2)
			{
				source = from x in source
						 where (x.Post.ToString()).ToLower().Contains(txtPost.Trim().ToLower())
						 select x;
			}
			bool flag3 = txtBranches.Length > 0;
			if (flag3)
			{
				source = from x in source
						 where (x.Branch.ToString()).ToLower().Contains(txtBranches.Trim().ToLower())
						 select x;
			}
			return source.ToList<Staff>();
		}

		public static List<Staff> GetStaff(string txtFIO, string txtPost, string txtBranches)
		{
			IEnumerable<Staff> source = GetStaff();
			bool flag = txtFIO.Length > 0;
			if (flag)
			{
				source = from x in source
						 where (x.NameFIO).ToLower().Contains(txtFIO.Trim().ToLower())
						 select x;
			}
			bool flag2 = txtPost.Length > 0;
			if (flag2)
			{
				source = from x in source
						 where (x.Post.ToString()).ToLower().Contains(txtPost.Trim().ToLower())
						 select x;
			}
			bool flag3 = txtBranches.Length > 0;
			if (flag3)
			{
				source = from x in source
						 where (x.Branch.ToString()).ToLower().Contains(txtBranches.Trim().ToLower())
						 select x;
			}
			return source.ToList<Staff>();
		}

	}
}
