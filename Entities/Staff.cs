using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Отдел_кадров.Entities
{
    /// <summary>
    /// Класс сотрудники
    /// </summary>
    public class Staff
    {
        /// <summary>
        /// ID номера табеля
        /// </summary>
        public int ServiceNumber { get; set; }//номер табеля

        /// <summary>
        /// Фамилия Имя Отчество
        /// </summary>
        public string NameFIO { get; set; }//ФИО

        /// <summary>
        /// Дата начала работы
        /// </summary>
        public DateTime DateAcceptance { get; set; }//Дата начала робы

        /// <summary>
        /// Должность ссылка на таблицу Positions
        /// </summary>
        public Positions Post { get; set; } //Должность

        /// <summary>
        /// Филиал ссылку на таблицу Branches
        /// </summary>
        public Branches Branch { get; set; }//Филиал

        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime DateBirth { get; set; }//дата рождения

        /// <summary>
        /// Дата увольнения
        /// </summary>
        public DateTime? DateDismissal { get; set; } //дата увольнения

        /// <summary>
        /// Стаж числом
        /// </summary>
        public int Experience { get; set; } //Стаж

        /// <summary>
        /// Название Отдела
        /// </summary>
        public string Department { get; set; }// Отдел

        /// <summary>
        /// Адрес прописки
        /// </summary>
        public string AddressResidence { get; set; } //адресс прописки

        /// <summary>
        /// Образование
        /// </summary>
        public string Education { get; set; }// образование

        /// <summary>
        /// Название города по прописке
        /// </summary>
        public string CityResidence { get; set; }//город прописки

        /// <summary>
        /// Возвращаем ФИО
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.NameFIO;
        }

        /// <summary>
        /// ID сервиса сравниваем
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            bool flag = obj is Staff;
            bool result;
            if (flag)
            {
                result = ((obj as Staff).ServiceNumber == this.ServiceNumber);
            }
            else
            {
                result = base.Equals(obj);
            }
            return result;
        }

        /// <summary>
        /// Возвращаем ID Сервиса
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return this.ServiceNumber;
        }

    }
}
