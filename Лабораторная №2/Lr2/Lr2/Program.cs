using System;
using System.Text;
using System.Linq;
namespace Lr2
{
    class Program
    {
        static void Main(string[] args)
        {
            //переменные примитивных типов
            bool vBool = true;
            byte vByte = 255;
            sbyte vSbyte = 127;
            char vChar = 'P';
            decimal vDecimal = 50.0M; //что значит М?
            double vDouble = 180.10;
            float vFloat = 0.5f;
            int vInt = 10;
            uint vUint = 0b101;
            long vLong = 0b101;
            ulong vUlong = 0xFF;
            short vShort = 30000;
            ushort vUshort = 60000;

            //операции явного преобразования
            vByte = (byte)vSbyte;
            vUlong = (ulong)vUshort;
            vChar = (char)vInt;
            vInt = (int)vDouble;
            vInt = (int)vShort;

            //операции неявного преобразования
            vLong = vInt;
            vUlong = vUshort;
            vUint = vChar;
            vFloat = vUlong;
            vInt = vByte;

            //возможности класса Convert
            int a;
            double b;

            a = Convert.ToInt32('k');
            b = Convert.ToDouble(vBool);

            Console.WriteLine($"decimal={vDecimal} a={a}  c={b} ");

            //упаковка и распаковка значимых типов
            Int32 x = 5;
            Object o = x;               //упаковка
            byte bt = (byte)(int)o;     //распаковка и приведение к типу

            //работа с неявно типизированной переменной
            var mas1 = new[] { 1, 3, 5, 7, 9 };
            var mas2 = new[] { 'a', 'b', 'c', 'd', 'e' };
            var mas3 = new[] { 1, 1.11 };
            Console.WriteLine(mas1.GetType());
            Console.WriteLine(mas2.GetType());
            Console.WriteLine(mas3.GetType());

            //работа с Nullable переменной
            int? i = null;
            Console.WriteLine(i == null); //true
            Console.WriteLine(i.HasValue);//false
            //Console.WriteLine(i.Value)

            var t = "Hello World";
            //t = 55;               //мы используем строгую типизацию, нельзя менять типы данных "налету", компилятор видит string t = "Hello World";


            String stL1 = "Hello world!";
            String stL2 = "Bonjour le monde";
            Console.WriteLine(ReferenceEquals(stL1, stL2));

            String st1 = "Hello";
            String st2 = "My";
            String st3 = "World";
            String phrase = "Do it for you";

            //сцеплени
            Console.WriteLine(String.Concat(st1, st2, st3));

            //копирование
            String st1copy = String.Copy(st1);
            Console.WriteLine(st1copy);

            //выделение подстроки
            Console.WriteLine(phrase.Substring(3, 2)); //начало и длина

            //разделение строки на слова
            string[] words = phrase.Split(' ');
            foreach (var word in words)
            {
                System.Console.WriteLine($"<{word}>");
            }

            //вставки подстроки в заданную позицию
            Console.WriteLine(st3.Insert(3, "-"));

            //удаление заданной подстроки
            Console.WriteLine(st3.Remove(3));

            //интерполяция строк
            Console.WriteLine($"1-st word: {st1}, 2-nd word: {st2}");

            /*Создайте пустую и null строку. Продемонстрируйте
            что еще можно выполнить с такими строками*/
            string stEmpty = ""; //пустая строка
            String stNull = null;

            /* Продемонстрируйте использование метода string.IsNullOrEmpty.*/
            bool TestForNullOrEmpty(string z)
            {
                bool result;
                result = z == null || z == string.Empty;
                return result;
            }
            Console.WriteLine(TestForNullOrEmpty(stEmpty));
            Console.WriteLine(TestForNullOrEmpty(stNull));


            //Создаём StringBuilder на 50 символов
            //Инициализируем строкой ABC
            StringBuilder sb = new StringBuilder("ABC", 50);
            Console.WriteLine(sb);

            //Удалите определенные позиции
            sb.Remove(1, 1);
            Console.WriteLine(sb);

            //добавьте новые символы
            //в начало
            sb.Insert(0, "Alphabet: ");
            Console.WriteLine(sb);

            //и конец строки
            sb.Append(new char[] { 'D', 'E', 'F' });
            Console.WriteLine(sb);

            //целый двумерный массив и выведите его на консоль в форматированном виде
            //тип_данных [,] имя_массиваss = 
            int[,] dbArray;
            dbArray = new int[3, 5]  //3 строки 5 колонок
                {
                    {12,45,12,51,20 },
                    {61,17,81,13,11 },
                    {11,5,65,78,13 },
                };  
            foreach(var item in dbArray)
            {
                Console.WriteLine(item); //элемены выведутся в столбец
            }


            int height = dbArray.GetLength(0); //кол-во элемментов в 1-ом измерении
            int width = dbArray.GetLength(1);
            
            for (int y = 0; y < height; y++)
            {
                for (int k = 0; k < width; k++)
                {
                    Console.Write(dbArray[y, k] + "\t");
                }
                Console.WriteLine();
            }

            //одномерный массив строк
            int position;
            String newString;
            String[] arrayStr = new string[] { "my", "new", "string", "array" };
            foreach (String n in arrayStr) Console.Write($"{n} ");

            int sizeMassStr = arrayStr.Length;
            Console.WriteLine($"Lenth: {sizeMassStr}");
            
            Console.WriteLine("Enter position: ");
            position = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter string: ");
            newString = Console.ReadLine();

            arrayStr[position] = newString;

            foreach (var item in arrayStr)
            {
                Console.WriteLine(item); 
            }
            /*
            //ступенчатый массив
            int[][] stepArray = new int[3][];
            stepArray[0] = new int[2];
            stepArray[1] = new int[3];
            stepArray[2] = new int[4];

            for (int y = 0; y < stepArray.Length; y++)
            {
                for (int k = 0; k < stepArray[y].Length; k++)
                {
                    stepArray[y][k] = Convert.ToInt32(Console.ReadLine());
                }
            }
            for (int y = 0; y < stepArray.Length; y++)
            {
                for (int k = 0; k < stepArray[y].Length; k++)
                {
                    Console.Write(stepArray[y][k] + "\t");
                }
                Console.WriteLine();
            }
            */
            //неявно типизированный массив строк
            var arr1 = new[] { "my", "new", "string", "array" };

            //кортеж из 5 элементов
            Tuple<int, string, char, string, ulong> Method()
            {
                return Tuple.Create(16, "Lena", 'b', "Ivanova", 20UL);
            }

            Console.WriteLine($"Full tuple: {Method().Item1}, {Method().Item2}, {Method().Item3}, {Method().Item4}, {Method().Item5}");
            Console.WriteLine($"Item 1: {Method().Item1}");
            Console.WriteLine($"Item 3: {Method().Item3}");
            Console.WriteLine($"Item 4: {Method().Item4}");

            var firstTuple = Tuple.Create(3, 9);
            var secondTuple = Tuple.Create(9, 3);
            ((IComparable)firstTuple).CompareTo(secondTuple);




            /*. Формальные параметры функции – массив
            целых и строка. Функция должна вернуть кортеж, содержащий:
            максимальный и минимальный элементы массива, сумму элементов
            массива и первую букву строки
            static void LocFun(int[] intArr, string str)
            {
                int lenArr = intArr.Length;
                int min = intArr[0];
                int max = intArr[0];
                int sum = 0;
                for (int i = 0; i < lenArr; i++)
                {
                    if (max < intArr[i])
                    {
                        max = intArr[i];
                    }
                    if (min > intArr[i])
                    {
                        min = intArr[i];
                    }
                }
                for (int i = 0; i < lenArr; i++)
                {
                    sum += intArr[i];
                }

                (int max, int min, int sum, string firstL)
                    CreateCortage(string name)
                {

                }

                return CreateCortage(string name);
            }
            */
            (int, string, char, string, ulong) kortej = (16, "Lena", 'b', "Ivanova", 20UL);
            int it1 = 1;
            string it2 = "wow";
            char it3 = 'o';
            string it4 = "ohoho";
            ulong it5 = 12;
            (it1, it2, it3, it4, it5) = kortej;

            (int, string, char, string, ulong) kortej1 = (1, "Stepa", 'b', "Korol", 19UL);
            if (kortej == kortej1)
            {
                Console.WriteLine("Кортежи равны!");
            }
            else
            {
                Console.WriteLine("Кортежи не равны!");
            }


            (int, int, int, char) localfunc(int[] massiv, string str)
            {
                int max = massiv.Max();
                int min = massiv.Min();
                int sum = massiv.Sum();
                char firstStr = str.First();
                return (max, min, sum, firstStr);
            }
            int[] massiv1 = { 1, 2, 5, 3, 4 };
            string stroka1 = "Do it for you!";
            Console.WriteLine(localfunc(massiv1, stroka1));

            int func_checked()
            {
                checked
                {
                    int q = int.MaxValue;
                    try
                    {
                        return q + 1;
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine("Переполнение");
                        return q;
                    }
                }
            }
            int func_unchecked()
            {
                unchecked
                {
                    int q = int.MaxValue;
                    try
                    {
                        return q + 1;
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine("Переполнение");
                        return q;
                    }
                }
            }
            Console.WriteLine(func_checked());
            Console.WriteLine(func_unchecked());
        }
    }
}
