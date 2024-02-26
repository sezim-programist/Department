using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Отдел_кадров.Entities
{
    /// <summary>
	/// Класс Филиалы
	/// </summary>
	public class Branches
    {
		/// <summary>
		/// ID филиала
		/// </summary>
		public int IDBranch { get; set; }

		/// <summary>
		/// Название Города
		/// </summary>
		public string City { get; set; }

		/// <summary>
		/// Юридический адрес
		/// </summary>
		public string LegalAddress { get; set; }

		/// <summary>
		/// Email
		/// </summary>
		public string Email { get; set; }

		/// <summary>
		/// Количество жителей
		/// </summary>
		public int NumberInhabitants { get; set; } 

		/// <summary>
		/// Возвращаем название города
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return this.City;
		}

		/// <summary>
		/// Сравниваем id Филиала
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public override bool Equals(object obj)
		{
			bool flag = obj is Branches;
			bool result;
			if (flag)
			{
				result = ((obj as Branches).IDBranch == this.IDBranch);
			}
			else
			{
				result = base.Equals(obj);
			}
			return result;
		}

		/// <summary>
		/// Возвращаем ID Филиала
		/// </summary>
		/// <returns></returns>
		public override int GetHashCode()
		{
			return this.IDBranch;
		}
	}
}
