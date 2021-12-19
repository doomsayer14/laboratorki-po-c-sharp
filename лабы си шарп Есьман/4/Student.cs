using System;

namespace DOT_Net_Lab_4
{
    class Student
    {
        public string fio { get; set; }
        public DateTime dateBirthd { get; set; }
        public DateTime datePost { get; set; }
        public char indexGroup { get; set; }
        public string facultet { get; set; }
        public string spechialization { get; set; }
        public int progress { get; set; }
        public Student()
        {
        }

        public Student(string fioCon, DateTime dateBirthdCon, DateTime datePostCon, char indexGroupCon, string facultetCon, string spechializationCon, int progressCon)
        {
            fio = fioCon;
            dateBirthd = dateBirthdCon;
            datePost = datePostCon;
            indexGroup = indexGroupCon;
            facultet = facultetCon;
            spechialization = spechializationCon;
            progress = progressCon;
        }

        public override string ToString()
        {
            return $" Фио: {fio}\n День рождения: {dateBirthd}\n Дата поступления: {datePost}\n Индекс группы: {indexGroup}\n Факультет: {facultet}\n Специальность: {spechialization}\n Успеваемость: {progress}\n \n";
        }
    }
}

