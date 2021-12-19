using System;
using System.IO;
using System.Text;

namespace DOT_Net_Lab_7
{
        class Methods
        {
            public static void Menu()
            {
                Console.WriteLine("Что Вы хотите сделать?\n 1 - Добавить данные про студента\n 2 - Вывести на экран данные\n 3 - Записать данные в файл" +
                       "\n 4 - Прочитать данные из файла\n 5 - Найти элемент по индексу\n 6 - Удалить данные о студенте\n 7 - Редактировать данные студента" +
                       "\n 8 - Вывести название группы студента\n 9 - Вывести текущий курс и семестр студента\n 10 - Вывести текущий возраст студента" +
                       "\n 11 - Возраст студентов факультета\n 12 - Группы студентов факультета\n 13 - Курс студентов факультета\n 14 - Вывести студентов старше 20 лет" +
                       "\n 15 - Найти минимальный возраст студента на факультете \n 16 - Выход");
            }
            public static void AddStud(Container records)
            {
            string fio, facultet, spechialization;
            DateTime dateBirthday, datePost;
            int progress;
            char indexGroup;
            Console.WriteLine("Фио: ");
            fio = Console.ReadLine();

            Console.WriteLine("День рождения: ");
            dateBirthday = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Дата поступления: ");
            datePost = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Индекс группы: ");
            indexGroup = char.Parse(Console.ReadLine());
            Console.WriteLine("Факультет: ");
            facultet = Console.ReadLine();
            Console.WriteLine("Специальность: ");
            spechialization = Console.ReadLine();
            Console.WriteLine("Успеваемость: ");
            progress = int.Parse(Console.ReadLine());
            var stud = new Student(fio, dateBirthday, datePost, indexGroup, facultet, spechialization, progress);
        }
            public static void ReadFile(Container records, string path)
            {
            string fio, facultet, spechialization,text;
            DateTime dateBirthday, datePost;
            int progress;
            char indexGroup;
            try
                {
                using (StreamReader sr = new StreamReader(path, Encoding.GetEncoding(1251)))
                {
                    text = sr.ReadToEnd();

                    string[] separatingStrings = { " ", "\r", "\n", ":", "00:00:00", "\t", "Студенты", "Фио", "День рождения",
                                    "Дата поступления", "Индекс группы", "Факультет", "Специальность", "Успеваемость"};
                    string[] words = text.Split(separatingStrings, System.StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < words.Length / 9; i++)
                    {
                        fio = words[0] + " " + words[1] + " " + words[2];
                        dateBirthday = DateTime.Parse(words[3]);
                        datePost = DateTime.Parse(words[4]);
                        indexGroup = char.Parse(words[5]);
                        facultet = words[6];
                        spechialization = words[7] + " " + words[8];
                        progress = int.Parse(words[9]);
                        var stud = new Student(fio, dateBirthday, datePost, indexGroup, facultet, spechialization, progress);
                        records.Add(stud);
                    }
                }
            }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            public static void WriteFile(Container records, string path)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
                    {
                        sw.WriteLine("Студенты: ");
                    }
                    foreach (var student in records)
                    {
                        /*using*/
                        StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default);
                        sw.WriteLine(student);
                    }
                    Console.WriteLine("Запись выполнена");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            public static void Course(Container records, int number)
            {
                int course, semester;
                course = DateTime.Today.Year - records.students[number - 1].datePost.Year;
                if (DateTime.Today.Month >= 7 && DateTime.Today.Month <= 12)
                {
                    semester = course * 2 - 1;
                }
                else
                {
                    semester = course * 2;
                }
                Console.WriteLine($"Курс : {course}, семестр : {semester}");
            }

            public static void Group(Container records, int number)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(records.students[number - 1].facultet);
                sb.Append(records.students[number - 1].spechialization);
                sb.Append("-");
                sb.Append(records.students[number - 1].datePost.Year);
                sb.Append(records.students[number - 1].indexGroup);
                sb.AppendLine();
                Console.WriteLine(sb.ToString());
            }
        }
    }
