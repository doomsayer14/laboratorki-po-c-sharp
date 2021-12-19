using System;

namespace DOT_Net_Lab_2
{
    class Student
    {
        public string fio { get; set; }
        public DateTime date_birthd { get; set; }
        public DateTime date_post { get; set; }
        public char index_group { get; set; }
        public string f_t { get; set; }
        public string spechialization { get; set; }
        public int progress { get; set; }
        public Student()
        {
        }

        public Student(string fio_con, DateTime date_birthd_con, DateTime date_post_con, char index_group_con, string f_t_con, string spechialization_con, int progress_con)
        {
            fio = fio_con;
            date_birthd = date_birthd_con;
            date_post = date_post_con;
            index_group = index_group_con;
            f_t = f_t_con;
            spechialization = spechialization_con;
            progress = progress_con;
        }

        public override string ToString()
        {
            return $" Фио: {fio}\n День рождения: {date_birthd}\n Дата поступления: {date_post}\n Индекс группы: {index_group}\n Факультет: {f_t}\n Специальность: {spechialization}\n Успеваемость: {progress}\n \n";
        }
    }
}
