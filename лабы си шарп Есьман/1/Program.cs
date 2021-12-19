using System;
using System.Text.RegularExpressions;

namespace DOT_Net_Lab_1
{
    class Student
    {
        public string fio { get; set; }
        public string date_birthd { get; set; }
        public string date_post { get; set; }
        public char index_group { get; set; }
        public string f_t { get; set; }
        public string spechialization { get; set; }
        public int progress { get; set; }
        public Student()
        {
        }

        public Student(string fio, string date_birthd, string date_post, char index_group, string f_t, string spechialization, int progress)
        {
            this.fio = fio;
            this.date_birthd = date_birthd;
            this.date_post = date_post;
            this.index_group = index_group;
            this.f_t = f_t;
            this.spechialization = spechialization;
            this.progress = progress;
        }

        public override string ToString()
        {
            return $" Фио: {fio}\n День рождения: {date_birthd}\n Дата поступления: {date_post}\n Индекс группы: {index_group}\n Факультет: {f_t}\n Специальность: {spechialization}\n Успеваемость: {progress}\n \n";
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Student[] students = new Student[2];
            for (int i = 0; i < 2; i++)
            {
                students[i] = initStudent();
                Console.WriteLine(students[i].ToString());
            }
            Console.ReadLine();
        }

        private static Student initStudent()
        {
                Console.WriteLine("Введите фио:");
                string fio = Console.ReadLine();
                while (Regex.IsMatch(fio, "^[А-Я][a-я]+") == false)
                {
                    Console.WriteLine("Введите даные еще раз:");
                    fio = Console.ReadLine();
                }

                DateTime dt;
                Console.WriteLine("Введите дату рождения:");
                string date_birthd = Console.ReadLine();
                {
                    Console.WriteLine("Введите даные еще раз:");
                    date_birthd = Console.ReadLine();
                }

                Console.WriteLine("Введите дату поступления:");
                string date_post = Console.ReadLine();
                while (DateTime.TryParse(date_post, out dt) == false)
                {
                    Console.WriteLine("Введите даные еще раз:");
                    date_post = Console.ReadLine();
                }

                Console.WriteLine("Введите индекс группы:");
                string index_group = Console.ReadLine();
                char c = char.Parse(index_group);
                while (Regex.IsMatch(index_group, "[а-в]") == false)
                {
                    Console.WriteLine("Введите даные еще раз:");
                    index_group = Console.ReadLine();
                    c = char.Parse(index_group);
                }

                Console.WriteLine("Введите факультет:");
                string f_t = Console.ReadLine();
                while (Regex.IsMatch(f_t, "[^А-Я]+") == false)
                {
                    Console.WriteLine("Введите даные еще раз:");
                    f_t = Console.ReadLine();
                }

                Console.WriteLine("Введите специальность:");
                string spechialization = Console.ReadLine();
                while (Regex.IsMatch(spechialization, "[^А-Яа-я]+") == false)
                {
                    Console.WriteLine("Введите даные еще раз:");
                    spechialization = Console.ReadLine();
                }

                Console.WriteLine("Введите прогресс в % (не больше 100):");
                string progress = Console.ReadLine();
                int intValue = Convert.ToInt32(progress);
                while (intValue > 100)
                {
                    Console.WriteLine("Введите даные еще раз:");
                    progress = Console.ReadLine();
                    intValue = Convert.ToInt32(progress);
                }
                //  students[i].progress = intValue;
                return new Student(fio, date_birthd, date_post, c, f_t, spechialization, intValue);
            }
        }
    }



