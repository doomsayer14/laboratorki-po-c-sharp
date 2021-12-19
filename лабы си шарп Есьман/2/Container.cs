using System;
using System.Collections;

namespace DOT_Net_Lab_2
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

          
        }
    }

