using System;
using System.IO;

namespace Lr12
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\ООП\Лабораторная №12\FileInfo.txt";

            Console.WriteLine("Имя сборки, в которой определен класс: ");
            Reflector.GetNameOfAssembly("Lr12.Phone");

            Console.WriteLine("\nЕсть ли публичные конструкторы: ");
            Reflector.IsPublicConstructor("Lr12.Phone");

            Console.WriteLine("\nВсе общедоступные публичные методы класса: ");
            foreach (var item in Reflector.AllPublicMethods("Lr12.Phone"))
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\nВсе поля и свойства класса: ");
            foreach (var item in Reflector.AllFieldsAndProperties("Lr12.Phone"))
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\nВсе реализованные классом интерфейсы: ");
            foreach (var item in Reflector.ImplementedInterfaces("Lr12.Confectioneries"))
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\nИмена методов, которые содержат заданный тип параметра: ");
            foreach (var item in Reflector.MethodWithParameter("Lr12.Confectioneries", "price"))
            {
                Console.WriteLine(item);
            }
            
            Reflector.gMethod();

        }
    }
}

