using System;
using System.IO;
using System.Text;
using vyesman.Models;

namespace WebApplication2
{
    public class Load
    {
        public static Container<Student> students = ReadFile();
        public static Container<Student> ReadFile()
        {
            Container<Student> temp = new Container<Student>();
            string fio, facultet, spechialization, text;
            DateTime dateBirthday, datePost;
            int progress;
            char indexGroup;
            string path = @"C:\Users\admin\Desktop\records.txt";
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
                        temp.Add(stud);
                        Console.WriteLine(temp);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return temp;
        }


    }
}

