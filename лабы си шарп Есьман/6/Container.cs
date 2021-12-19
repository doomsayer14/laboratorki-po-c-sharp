using System;
using System.Collections;
using System.Text;

namespace DOT_Net_Lab_5
{
    class Container : IEnumerable, IEnumerator
    {
        static int size = 1;
        public Student[] students = new Student[size];

        int index = -1;
        int currentSize = 0;

        // Реализуем интерфейс IEnumerable
        public IEnumerator GetEnumerator()
        {
            return this;
        }

        // Реализуем интерфейс IEnumerator
        public bool MoveNext()
        {
            if (index == students.Length - 1)
            {
                Reset();
                return false;
            }

            index++;
            return true;
        }
        public void Add(Student student)
        {
            currentSize = NewSize();
            if (currentSize < size)
            {
                students[currentSize] = student;
            }

            else
            {
                size = currentSize + 1;
                Array.Resize(ref students, size);
                students[size - 1] = student;
            }
        }

        public void Reset()
        {
            index = -1;
        }

        public object Current
        {
            get
            {
                return students[index];
            }
        }

        int NewSize()
        {
            currentSize = 0;
            for (int i = 0; i < students.Length; i++)
            {
                if (students[i] != null)
                    currentSize++;
            }
            return currentSize;
        }

        public void Search(Container records, int number)
        {
            Console.WriteLine("Студент по индексу :");
            Console.Write(records.students[number - 1] + " ");
        }
        public void Remove(Container records, int number)
        {
            currentSize = NewSize();
            students[number - 1] = null;
            for (int i = number; i < currentSize; i++)
            {
                if (students[i] != null)
                {
                    students[i - 1] = students[i];
                }
            }
            Array.Resize(ref students, currentSize - 1);
            Console.WriteLine("Измененный список студентов :");
            foreach (var student in records)
            {
                Console.WriteLine(student + " ");
            }
        }
        public void Edit(Container records, int number, string s, string str)
        {
            switch (s)
            {
                case "fio":
                    records.students[number - 1].fio = str;
                    break;
                case "dateBirthday":
                    records.students[number - 1].dateBirthd = DateTime.Parse(str);
                    break;
                case "datePost":
                    records.students[number - 1].datePost = DateTime.Parse(str);
                    break;
                case "indexGroup":
                    records.students[number - 1].indexGroup = char.Parse(str);
                    break;
                case "facultet":
                    records.students[number - 1].facultet = str;
                    break;
                case "specialization":
                    records.students[number - 1].spechialization = str;
                    break;
                case "progress":
                    records.students[number - 1].progress = int.Parse(str);
                    break;
            }

            Console.WriteLine("Измененный список студентов :");
            foreach (var student in records)
            {
                Console.WriteLine(student + " ");
            }
        }
        public string Group(Container records, int number)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(records.students[number - 1].facultet);
            sb.Append(records.students[number - 1].spechialization);
            sb.Append("-");
            sb.Append(records.students[number - 1].datePost.Year);
            sb.Append(records.students[number - 1].indexGroup);
            sb.AppendLine();
            return sb.ToString();
        }

        public void GrRemove(Container records, int number, String str)
        {
            switch (number)
            {
                case 1:
                    for (int i = 0; i < NewSize(); i++)
                    {
                        if (Group(records, i + 1).Equals(str + "\r\n"))
                        {
                            records.Remove(records, i + 1);
                        }
                    }
                    break;
                case 2:
                    int spec = int.Parse(str);
                    for (int i = 0; i < NewSize(); i++)
                    {
                        if (records.students[i].spechialization.Equals(spec))
                        {
                            records.Remove(records, i + 1);
                        }
                    }
                    break;
                case 3:
                    for (int i = 0; i < NewSize(); i++)
                    {
                        if (records.students[i].facultet.Equals(str))
                        {
                            records.Remove(records, i + 1);
                            i--;
                        }
                    }
                    break;
            }
        }

    }

}


