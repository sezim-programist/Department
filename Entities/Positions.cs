using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Отдел_кадров.Entities
{
    /// <summary>
	/// Класс Должности
	/// </summary>
    public class Positions
    {
		/// <summary>
		/// ID Должности
		/// </summary>
        public int IDPost { get; set; }
	
		/// <summary>
		/// Название должности
		/// </summary>
        public string Post { get; set; }

		/// <summary>
		/// Стаж
		/// </summary>
        public int ExperienceEquirements { get; set; }

		/// <summary>
		/// Дополнительные дни к отпуску
		/// </summary>
        public int AdditionalVacation { get; set; }

		/// <summary>
		/// Возвращаем название должности
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return this.Post;
		}

		/// <summary>
		/// Сравниваем по ID
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public override bool Equals(object obj)
		{
			bool flag = obj is Positions;
			bool result;
			if (flag)
			{
				result = ((obj as Positions).IDPost == this.IDPost);
			}
			else
			{
				result = base.Equals(obj);
			}
			return result;
		}


		/// <summary>
		/// Возвращаем ID должности
		/// </summary>
		/// <returns></returns>
		public override int GetHashCode()
		{
			return this.IDPost;
		}
	}
}
