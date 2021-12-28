using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Lr12
{
    class Person
    {
        public void Output(string str)
        {
            Console.WriteLine(str);
        }
    }
    class Configuration
    {
        public string funcname { get; set; }
        public string className { get; set; }
        public string param { get; set; }
    }
    static class Reflector
    {
        public static void GetNameOfAssembly(string nameOfClass)                                        //Определение имени сборки, в которой определен класс
        {
            Assembly assem = Type.GetType(nameOfClass).Assembly;
            Console.WriteLine($"Assembly Full Name: {assem.FullName}");
        }
        public static void IsPublicConstructor(string nameOfClass)                                      //есть ли публичные конструкторы
        {
            bool assem = Type.GetType(nameOfClass).GetConstructors().Length != 0;
            if (assem)
            {
                Console.WriteLine("Type has public constructors");
            }
            else
            {
                Console.WriteLine("Type hasn't public constructors");
            }
        }
        public static IEnumerable<string> AllPublicMethods(string nameOfClass)                          //извлекает все общедоступные публичные методы класса
        {
            return Type.GetType(nameOfClass).GetMethods(BindingFlags.Public)
                .Select(item => item.Name);
        }
        public static IEnumerable<string> AllFieldsAndProperties(string nameOfClass)                    //получает информацию о полях и свойствах класса
        {
            return Type.GetType(nameOfClass).GetFields().Select(item => item.Name)
                .Concat(Type.GetType(nameOfClass).GetProperties().Select(item => item.Name));
        }
        public static IEnumerable<string> ImplementedInterfaces(string nameOfClass)                     //получает все реализованные классом интерфейсы
        {
            return Type.GetType(nameOfClass).GetInterfaces()
                .Select(item => item.Name);
        }
        public static IEnumerable<string> MethodWithParameter(string nameOfClass, string prop)          //выводит по имени класса имена методов, которые содержат заданный тип параметра
        {
            return Type.GetType(nameOfClass).GetMethods().Where(item => item.GetParameters().Any(item => item.Name == prop))
                .Select(item => item.Name);
        }
        public static void gMethod()
        {
            Configuration conf;
            using (var stream = new StreamReader("InfoFile.json"))
            {
                var cont = stream.ReadToEnd();
                conf = JsonSerializer.Deserialize<Configuration>(cont);
            }
            var obj = new Person();
            Type.GetType($"Lr12.{conf.className}").GetMethod(conf.funcname).Invoke(obj, new object[] { conf.param });
        }
        
        public static object CreareObj(string name)
            => Activator.CreateInstance(Type.GetType(name));

    }


    class Phone
    {
        private readonly int id;  
        private string firstName;
        private string name;                    
        private string secondName;
        private string adress;
        private int numberOfCard;
        private int debet;
        private int credit;
        private int cityCallTime;
        private int intercityCallTime;

        public int Id                        
        {
            get
            {
                if (id > 0) return id;
                else return 0;
            }                     
        }
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string SecondName
        {
            get { return secondName; }
            set { secondName = value; }
        }
        public string Adress
        {
            get { return adress; }
            set { adress = value; }
        }
        public int NumberOfCard { get; set; }                  
        public int Debet { get; set; }
        public int Credit { get; set; }
        public int CityCallTime { get; set; }
        public int EntercityCallTime { get; set; }

        public Phone()
        {

        }

        public Phone(string fistName, string name, string secondName, string adress, int numberOfCard,
                        int debet, int credit, int cityCallTime, int intercityCallTime)
        {
            this.firstName = firstName;
            this.name = name;
            this.secondName = secondName;
            this.adress = adress;
            this.numberOfCard = numberOfCard;
            this.debet = debet;
            this.credit = credit;
            this.cityCallTime = cityCallTime;
            this.intercityCallTime = intercityCallTime;
            numberOfObj++;
        }

        public const int sum = 100;

        public int Sum
        {
            get { return sum; }
        }

        private Phone(int sum)
        {
            Console.WriteLine($"Стартовая сумма: {sum}");
        }

        private static int numberOfObj;
        static void classInfo()
        {
            Console.WriteLine(numberOfObj);
        }

        public void PrintInfoDB()
        {
            Console.WriteLine($"Фамилия: {firstName}\n" +
                $"Имя: {name}\n" +
                $"Отчество: {secondName}\n" +
                $"Адрес: {adress}\n" +
                $"Номер банковской карты: {numberOfCard}\n");
        }
    }
    class Confectioneries : IHasInfo
    {
        public string Name { get; set; }
        public Confectioneries(string name, int price)
        {
            Name = name;
            Price = price;
        }
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Название товара: {Name} \nЦена товара за кг(в BYN): {Price}");
        }
        public int Price { get; set; }
        public Confectioneries(int price)
        {
            Price = price;
        }
        public static void CheckPrice(int price)
        {
            Console.WriteLine($"Price: {price}");
        }
    }
    
    interface IHasInfo
    {
        void DisplayInfo();
    }
}
