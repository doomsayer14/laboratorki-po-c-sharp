using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace DOT_Net_Lab_7
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\admin\Desktop\records.txt";
            StringBuilder sb = new StringBuilder();
            var records = new Container();
            bool loop = true;
            int  number, choice;

            while (loop)
            {
                Methods.Menu();
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Methods.AddStud(records);
                        break;
                    case 2:
                        foreach (var student in records)
                        {
                            Console.WriteLine(student + " ");
                        }
                        break;
                    case 3:
                        Methods.WriteFile(records, path);
                        break;
                    case 4:
                        Methods.ReadFile(records, path);
                        break;
                    case 5:
                        Console.WriteLine("Номер студента, которого хотите найти: ");
                        number = int.Parse(Console.ReadLine());
                        records.Search(records, number);
                        break;
                    case 6:
                        Console.WriteLine("Номер студента, данные о котором хотите удалить: ");
                        number = int.Parse(Console.ReadLine());
                        records.Remove(records, number);
                        break;
                    case 7:
                        Console.WriteLine("Номер студента, данные о котором хотите отредактировать: ");
                        number = int.Parse(Console.ReadLine());
                        Console.WriteLine("Что хотите отредактировать? (1-фио, 2 - день рождения, 3 - дата поступления, " +
                                        "4 - индекс группы, 5 - факультет, 6 - специальность, 7 - успеваемость");
                        int n;
                        string str;
                        n = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите новые данные в соответствующем формате : ");
                        str = Console.ReadLine();
                        records.Edit(records, number, n, str);
                        break;
                    case 8:
                        Console.WriteLine("Номер студента, чью группу хотите узнать: ");
                        number = int.Parse(Console.ReadLine());
                        Methods.Group(records, number);
                        break;
                    case 9:
                        Console.WriteLine("Номер студента, чей номер курса и семестра на текущий момент хотите узнать: ");
                        number = int.Parse(Console.ReadLine());
                        Methods.Course(records, number);
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
                            Console.Write(y + "  ");
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

                        List<int> selectedItems2 =
                            (from t in records.students
                             where t.facultet.Equals(str5)
                             select DateTime.Today.Year - t.datePost.Year).ToList();

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
