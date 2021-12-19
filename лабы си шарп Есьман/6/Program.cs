using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Xml.Serialization;

namespace DOT_Net_Lab_5
{
    class Program
    {
        delegate int Average(Container records, int number, String str);
        static void Main(string[] args)
        {
            string path = @"C:\Users\admin\Desktop\records.txt";
            StringBuilder sb = new StringBuilder();
            var records = new Container();
            bool loop = true;
            string fio, facultet, spechialization;
            DateTime dateBirthday, datePost;
            int progress, number;
            char indexGroup;
            int choice;
            string text;


            while (loop)
            {
                Console.WriteLine(" 1 - Добавить данные про студента\n 2 - Вывести на экран данные\n  " +
                    "3 - Найти элемент по индексу\n 4 - Запись в файл\n 5 - Чтение с файла\n 6 - Удаление\n 7 - Редактирование\n " +
                    "8-Вывод для студента группы\n 9-Вывод для выбранного студента номера курса и семестра на текущий момент\n " +
                    "10-вывод для выбранного студента возраста на текущий момент\n " +
                    " 11 - Возраст студентов факультета\n 12 - Группы студентов факультета\n 13 - Курс студентов факультета\n 14 - Выход");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
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
                        records.Add(stud);
                        break;
                    case 2:
                        foreach (var student in records)
                        {
                            Console.WriteLine(student + " ");
                        }
                        break;

                    case 3:
                        Console.WriteLine("Номер студента, которого хотите найти: ");
                        number = int.Parse(Console.ReadLine());
                        records.Search(records, number);
                        break;
                    case 4:
                        try
                        {
                            using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.GetEncoding(866)))
                            {
                                sw.WriteLine("Студенты: ");
                            }
                            foreach (var student in records)
                            {
                                using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.GetEncoding(866)))
                                {
                                    sw.WriteLine(student);
                                }
                            }
                            Console.WriteLine("Запись выполнена");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case 5:
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
                                    stud = new Student(fio, dateBirthday, datePost, indexGroup, facultet, spechialization, progress);
                                    records.Add(stud);
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case 6:
                        Console.WriteLine("Номер студента, данные о котором хотите удалить: ");
                        number = int.Parse(Console.ReadLine());
                        records.Remove(records, number);
                        break;
                    case 7:
                        Console.WriteLine("Номер студента, данные о котором хотите отредактировать: ");
                        number = int.Parse(Console.ReadLine());
                        Console.WriteLine("Что хотите отредактировать? (1-ФИО, 2 - день рождения, 3 - дата поступления, " +
                                        "4 - индекс группы, 5 - факультет, 6 - специальность, 7 - успеваемость");
                        int n;
                        string str;
                        n = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите новые данные в соответствующем формате : ");
                        str = Console.ReadLine();
                        switch (n)
                        {
                            case 1:
                                records.Edit(records, number, "fio", str);
                                break;
                            case 2:
                                records.Edit(records, number, "birthday", str);
                                break;
                            case 3:
                                records.Edit(records, number, "date postyplenia", str);
                                break;
                            case 4:
                                records.Edit(records, number, "index group", str);
                                break;
                            case 5:
                                records.Edit(records, number, "facultet", str);
                                break;
                            case 6:
                                records.Edit(records, number, "specialnost", str);
                                break;
                            case 7:
                                records.Edit(records, number, "progress", str);
                                break;
                        }
                        break;
                    case 8:
                        Console.WriteLine("Выберите студента чью группу хотите узнать: ");
                        number = int.Parse(Console.ReadLine());
                        sb.Append(records.students[number - 1].facultet + " ");
                        sb.Append(records.students[number - 1].spechialization);
                        sb.Append("-");
                        sb.Append(records.students[number - 1].datePost.Year);
                        sb.Append(records.students[number - 1].indexGroup);
                        sb.AppendLine();
                        Console.WriteLine(sb.ToString());
                        break;
                    case 9:
                        Console.WriteLine("Номер студента, чей номер курса и семестра на текущий момент хотите узнать: ");
                        number = int.Parse(Console.ReadLine());
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
                        break;
                    case 10:
                        Console.WriteLine("Номер студента, чей текущий возраст хотите узнать: ");
                        number = int.Parse(Console.ReadLine());
                        DateTime today = DateTime.Today;
                        DateTime b = records.students[number - 1].dateBirthd;
                        TimeSpan old = today.Subtract(b);
                        var d = new DateTime(old.Ticks);
                        Console.WriteLine($"Возраст: {d.Year - 1} лет, {d.Month - 1} месяцев, {d.Day - 1} дней");
                        break;
                    case 11:
                        Console.WriteLine("Введите факультет, возраст студентов которого хотите узнать: ");
                        string str3 = Console.ReadLine();

                        var selectedItems = from t in records.students
                                            where t.facultet.Equals(str3)
                                            select t.dateBirthd.Year;
                        Console.WriteLine("Возраст студентов: ");
                        foreach (int y in selectedItems)
                            Console.Write(DateTime.Now.Year - y + "  ");
                        Console.WriteLine();
                        break;
                    case 12:
                        Console.WriteLine("Введите факультет, названия групп студентов которого хотите узнать: ");
                        string str4 = Console.ReadLine();
                        var selectedItems1 = from t in records.students
                                             where t.facultet.Equals(str4)
                                             select t.facultet + t.spechialization + "-" + t.datePost.Year + t.indexGroup;

                        Console.WriteLine("Группы студентов: ");
                        foreach (string s in selectedItems1)
                            Console.Write(s + "  ");
                        Console.WriteLine();
                        break;
                    case 13:
                        Console.WriteLine("Введите факультет, номер курса студентов которого хотите узнать: ");
                        string str5 = Console.ReadLine();
                        var selectedItems2 = from t in records.students
                                             where t.facultet.Equals(str5)
                                             select DateTime.Today.Year - t.datePost.Year;

                        Console.WriteLine("Курс студентов: ");
                        foreach (int s in selectedItems2)
                            Console.Write(s + "  ");
                        Console.WriteLine();
                        break;
                    case 14:
                        loop = false;
                        break;
                }
            }
        }
    }
}
    