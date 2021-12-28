using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Lr4
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размер множеств:");               //задаём размерность множеств
            int n = int.Parse(Console.ReadLine());

            int[] a = new int[n];                                           //создаём множество А
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Введите {i + 1}-й элемент множества А: ");
                a[i] = int.Parse(Console.ReadLine());
            }
            Set mnojA = new Set(a);

            Console.WriteLine("");

            int[] b = new int[n];                                            //создаём множество В
            Console.WriteLine($"Задайте множество B для определения пересечения с множеством А");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Введите {i + 1}-й элемент множества А: ");
                b[i] = int.Parse(Console.ReadLine());
            }
            Set mnojB = new Set(b);

            Console.WriteLine("");

            int check;
            Console.WriteLine("Введите элемент(число), которое хотите найти в множестве А: "); // проверяем принадлежность элемента в множестве А
            check = int.Parse(Console.ReadLine());
            if (mnojA > check)
            {
                Console.WriteLine("Элемент принадлежит множеству А :)");
            }
            else
            {
                Console.WriteLine("Элемент НЕ принадлежит множеству А :(");
            }

            Console.WriteLine("");

            Console.WriteLine("Проверим, пересекаются ли множества А и В: ");                            // Проверка на пересечение множеств А и B
            bool peresechenie;
            peresechenie = mnojA * mnojB;
            Console.WriteLine(peresechenie);

            Console.WriteLine("Проверим, является лм множество {1,2} подмножеством А: ");                            // Проверка на пересечение множеств А и B
            bool podsetRez;
            int[] podset = { 1, 2 };
            podsetRez = mnojA + podset;
            Console.WriteLine(podsetRez);

            Console.WriteLine("<-----Методы расширения. Задание №4----->");
            int sum = StatisticOperation.Summa(mnojA);
            Console.WriteLine($"Сумма элементов множества равна: {sum}");

            int maxminDif = StatisticOperation.MaxMinDif(mnojA);
            Console.WriteLine($"Разница между максимальным и минимальным элементами множеств равна: {maxminDif}");

            int count = StatisticOperation.Counter(mnojA);
            Console.WriteLine($"Подсчёт кол-ва элементов: {count}");

            Console.WriteLine("<-----Методы расширения. Задание №5----->");
            string str = "Строка, в которой где7-то должно быть число";
            char[] s = StatisticOperation.FindNum(str);
            Console.WriteLine($"Выделение первого числа, содержащегося в строке: {new String(s)}");

            int[] c = new int[n];
            c = StatisticOperation.DelPlus(mnojA);
            Console.WriteLine("Обнуление положительных элементов множества: ");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"{c[i]} ");
            }

            Console.ReadKey();
        }

    }

    public class Set
    {
        Owner owner = new Owner(04102021, "Polina", "BSTU");

        public int[] mnojestvoA;
        public int[] mnojestvoB;
        public Set(int[] a, int[] b)
        {
            mnojestvoA = a;
            mnojestvoB = b;
        }
        public Set(int[] a)
        {
            mnojestvoA = a;
        }
        
        // перегрузки

        public static bool operator >(Set a, int check) // проверка на принадлежность элемента множеству А
        {
            int flag = 0;
            for (int i = 0; i < a.mnojestvoA.Length; i++)
            {
                if (a.mnojestvoA[i] == check)
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
            for(int i = 0; i < a.mnojestvoA.Length; i++)
            {
                for (int j = 0; j < b.mnojestvoA.Length; j++)
                {
                    if (a.mnojestvoA[i] == b.mnojestvoA[j])
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
        /*
         public static int[] operator *(Set a, Set b) 
         {
             int size = 0;
             int[] rez = new int[size];
             for (int i = 0; i < a.mnojestvoA.Length; i++)
             {
                 for(int j = 0; j < b.mnojestvoA.Length; j++)
                 {
                     if (a.mnojestvoA[i] == b.mnojestvoA[j])
                     {
                         rez[size] = a.mnojestvoA[i];
                         size++;
                     }
                 }
             }

             return rez;
         }*/

        public static bool operator +(Set a, int[]podset)
        {
            int counter = 0;
            for (int i = 0; i < a.mnojestvoA.Length; i++)
            {
                for (int j = 0; j < podset.Length; j++)
                {
                    if (a.mnojestvoA[i] == podset[j])
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

    public class Owner                                                                 //вложенный класс Owner 
    {
        public int id;
        public string name;
        public string org;

        public Owner(int id, string name, string org)
        {
            this.id = id;
            this.name = name;
            this.org = org;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Org
        {
            get { return org; }
            set { org = value; }
        }

        public void getInfo()
        {
            Console.WriteLine($"ID: {Id}\nИмя: {Name}\nОрганизация: {Org}");
        }
    }

    public class Date                                                           //вложенный класс Date
    {
        private int day;
        private int month;
        private int year;
        public Date(int day, int month, int year)
        {
            this.day = day;
            this.month = month;
            this.year = year;
        }
        public void getDate()
        {
            Console.WriteLine($"Год: {year}\nМесяц: {month}\nДень: {day}\n");
        }
    }
        
    public static class StatisticOperation
    {
               
        public static int Summa(Set a)                                      // сумма элементов
        {
            int sum = 0;
            for (int i = 0; i < a.mnojestvoA.Length; i++)
            {
                sum = sum + a.mnojestvoA[i];
            }
            return sum;
        }
        public static int MaxMinDif(Set a)                                  //поиск разницы между максимальным и минимальным эл-ми множества
        {
            int dif = 0;
            int max = a.mnojestvoA[0];
            int min = a.mnojestvoA[0];
            for (int i = 0; i < a.mnojestvoA.Length; i++)
            {
                if (a.mnojestvoA[i] > max)
                {
                    max = a.mnojestvoA[i];
                }
            }
            for (int i = 0; i < a.mnojestvoA.Length; i++)
            {
                if (a.mnojestvoA[i] < min)
                {
                    min = a.mnojestvoA[i];
                }
            }
            dif = max - min;
            return dif;
        }
        public static int Counter(this Set a)                                      // подсчёт элементов
        {
            int count = 0;
            for (int i = 0; i < a.mnojestvoA.Length; i++)
            {
                count++;
            }
            return count;
        }
        
        public static char[] FindNum(this string str) //поиск первого числа в строке
        {
            // Получаем индекс первой цифры в строке
            int firstIndex = str.IndexOf(str.Where(x => Char.IsDigit(x)).First());

            int counter = 1;
            int value;

            // Считаем количество индексов до первого неудачного TryParse
            for (int i = firstIndex + 1; i < str.LastIndexOf(str.Last()); i++)
            {
                if (int.TryParse(str[i].ToString(), out value))
                {
                    counter++;
                }
                else break;
            }

            // Массив для числа
            char[] result = new char[counter];

            // Закидываем первое чило посимвольно в строку
            for (int i = 0; i < counter; i++)
            {
                result[i] = str[firstIndex + i];
            }

            return result;
        }

        public static int[] DelPlus(Set a)                                      // обнуление положительных
        {
            int size = a.mnojestvoA.Length;
            int[] newArray = new int[size];
            for (int i = 0; i < size; i++)
            {
                if (a.mnojestvoA[i] > 0)
                {
                    a.mnojestvoA[i] = 0;
                    newArray[i] = a.mnojestvoA[i];
                }
                else
                {
                    newArray[i] = a.mnojestvoA[i];
                }

            }
            return newArray;
        }
        
    }



}

