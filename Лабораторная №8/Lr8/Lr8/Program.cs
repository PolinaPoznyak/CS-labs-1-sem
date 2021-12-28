using System;
using System.Collections.Generic;
using System.IO;

namespace Lr8
{
    interface IGeneric<T>
    {
        void Add(T item);
        T Delete(int item);
        void Viewing();
    }

    public class CollectionType<T> : IGeneric<T> where T : class
    {
        public List<T> sets = new List<T>();
        public void Add(T item)
        {
            sets.Add(item);
        }

        public T Delete(int item)
        {
            T value = sets[item];
            sets.RemoveAt(item);
            return value;
        }

        public void Viewing()
        {
            int count = 0;
            foreach (T item in sets)
            {
                count++;
                Console.WriteLine($"Элемент множества под номером {count} относится к типу {item.GetType()}");
            }
        }

        public void WriteTextFile()
        {
            string path = @"D:\TextFileLr8.txt";
            foreach (var item in sets)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))
                    {
                        sw.WriteLine(item.ToString());
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        public void ReadTextFile()
        {
            string path = @"D:\TextFileLr8.txt";
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }
        public void FileInfo()
        {
            string path = @"D:\TextFileLr8.txt";
            FileInfo fileInf = new FileInfo(path);
            if (fileInf.Exists)
            {
                Console.WriteLine("Имя файла: {0}", fileInf.Name);
                Console.WriteLine("Время создания: {0}", fileInf.CreationTime);
                Console.WriteLine("Размер: {0}", fileInf.Length);
            }
        }
    }
    public class StandartTypes<T1, T2, T3, T4> 
        where T1 : struct 
        where T2 : struct 
        where T3 : struct 
        where T4 : struct
    {
        public T1 obj1 { get; set; }
        public T2 obj2 { get; set; }
        public T3 obj3 { get; set; }
        public T4 obj4 { get; set; }

        public StandartTypes(T1 obj1,  T2 obj2, T3 obj3, T4 obj4)
        {
            this.obj1 = obj1;
            this.obj2 = obj2;
            this.obj3 = obj3;
            this.obj4 = obj4;
        }
        public void ShowingTypes()
        {
            Console.WriteLine($"" +
                $"Переменная первого типа {obj1.GetType()} имеет значение {obj1}\n" +
                $"Переменная второго типа {obj2.GetType()} имеет значение {obj2}\n" +
                $"Переменная третьего типа {obj3.GetType()} имеет значение {obj3}\n" +
                $"Переменная четвёртого типа {obj4.GetType()} имеет значение {obj4}\n" +
                $"");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Set set1 = new Set();
            Console.WriteLine("Задайте первое множество: ");
            set1.Mnojestvo = Console.ReadLine();

            Set set2 = new Set();
            Console.WriteLine("Задайте второе множество: ");
            set2.Mnojestvo = Console.ReadLine();

            Set set3 = new Set();
            Console.WriteLine("Задайте третье множество: ");
            set3.Mnojestvo = Console.ReadLine();

            CollectionType<Set> listOfSets = new CollectionType<Set>();
            listOfSets.Add(set1);
            listOfSets.Add(set2);
            listOfSets.Add(set3);
            listOfSets.Viewing();

            bool exeption1 = false;
            bool exeption2 = false;

            try
            {
                Set delSet = listOfSets.Delete(2);
                Console.WriteLine($"Удаленное множество {delSet.Mnojestvo}");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Ошибка:{ex.Message}\n{ex.Source}");
                exeption1 = true;
            }
            finally
            {
                if (exeption1)
                {
                    Console.WriteLine("В ходе выполнения сработало исключение и было обработано");
                }
                else
                {
                    Console.WriteLine("В ходе выполнения исключение НЕ произошло");
                    Console.WriteLine($"Коллекция множеств после удаления:");
                    listOfSets.Viewing();
                }
            }
            try
            {
                StandartTypes<int, double, byte, decimal> listOfTypes = new StandartTypes<int, double, byte, decimal>(1810, 111.5, 8, 12.333m);
                listOfTypes.ShowingTypes();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка:{ex.Message}\n{ex.Source}");
                exeption1 = true;
            }
            finally
            {
                if (exeption2)
                {
                    Console.WriteLine("В ходе выполнения сработало исключение и было обработано");
                }
                else
                {
                    Console.WriteLine("В ходе выполнения исключение НЕ произошло");
                }
            }
            listOfSets.WriteTextFile();
            listOfSets.ReadTextFile();
            listOfSets.FileInfo();
        }

    }

    public class Set
    {
        string mnojestvo;
        public string Mnojestvo
        {
            get { return mnojestvo; }
            set { mnojestvo = value; }
        }
        public string this[string str]
        {
            set
            {
                mnojestvo = value;
            }
            get
            {
                return mnojestvo;
            }
        }
  

        // перегрузки

        public static bool operator >(Set a, int check) // проверка на принадлежность элемента множеству А
        {
            int flag = 0;
            for (int i = 0; i < a.mnojestvo.Length; i++)
            {
                if (a.mnojestvo[i] == check)
                    flag++;
            }
            if (flag != 0) return true;
            else return false;
        }

        public static bool operator <(Set a, int check)
        {
            return false;
        }

        public static bool operator *(Set a, Set b)
        {
            int counter = 0;
            for (int i = 0; i < a.mnojestvo.Length; i++)
            {
                for (int j = 0; j < b.mnojestvo.Length; j++)
                {
                    if (a.mnojestvo[i] == b.mnojestvo[j])
                    {
                        counter++;
                    }
                }
            }
            if (counter != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator +(Set a, int[] podset)
        {
            int counter = 0;
            for (int i = 0; i < a.mnojestvo.Length; i++)
            {
                for (int j = 0; j < podset.Length; j++)
                {
                    if (a.mnojestvo[i] == podset[j])
                    {
                        counter++;
                    }
                }
            }
            if (counter == 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

}

