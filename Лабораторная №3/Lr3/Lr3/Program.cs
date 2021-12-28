using System;

namespace Lr3
{
    partial class Phone
    {
        private readonly int id;   //уникальный номер каждого человека
        private string firstName;
        private string name; // поле имени                         (поля, методы и события)
        private string secondName;
        private string adress;
        private int numberOfCard;
        private int debet;  
        private int credit;
        private int cityCallTime;
        private int intercityCallTime;

        public int Id                                // get/set - методы для реализации инкапсуляции
        {
            get
            {
                if (id > 0) return id;
                else return 0;
            }                                       //ограничено по set
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
        public int NumberOfCard { get; set; }                   //авоматическое свойство
        public int Debet { get; set; }
        public int Credit { get; set; }
        public int CityCallTime { get; set; }
        public int EntercityCallTime { get; set; }

        //конструктор по умолчанию - конструктор, который не имеет параметов и не имеет тела, создаётся автоматически средой разработки, если в классе не определено ни одного конструктора

        public Phone()
        {

        }

        public Phone(string fistName, string name, string secondName, string adress, int numberOfCard,
                        int debet, int credit, int cityCallTime, int intercityCallTime)
        {
            this.firstName = firstName;              //с помощью this обращаемся к той переменной, которая является полем класса
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
        /**/

        private static int numberOfObj;  //статическое поле, хранящее количество созданных объектов
        static void classInfo()          //статический метод вывода информации о классе
        {
            Console.WriteLine(numberOfObj);
        }
        static Phone()                   //статический конструктор
        {
            Console.WriteLine("Cтатический конструктор");
            numberOfObj = 0;
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
    class Program
    {

        //функция в ООП не может сущ-ть без класса
        //функции, которые принадлежат классу, принято называть МЕТОДОМ

        //метод расчет баланса на текущий момент
        private static int Balance(out int result, int sum, int debet, int credit) => result = sum + debet - credit;
        static void Main(string[] args)
        {
            Console.WriteLine("Задайте количество абонентов: ");
            int numberOfUsers = int.Parse(Console.ReadLine());

            Phone[] DB = new Phone[numberOfUsers];          //создаём массив классов с БД о пользователях
            
            Console.WriteLine();

            for (int i = 0; i < numberOfUsers; i++)
            {
                DB[i] = new Phone();

                Console.WriteLine("Введите фамилию: ");
                DB[i].FirstName = Console.ReadLine();

                Console.WriteLine("Введите имя: ");
                DB[i].Name = Console.ReadLine();

                Console.WriteLine("Введите отчество: ");
                DB[i].SecondName = Console.ReadLine();

                Console.WriteLine("Введите адресс: ");
                DB[i].Adress = Console.ReadLine();

                Console.WriteLine("Введите номер банковской карты: ");
                DB[i].NumberOfCard = int.Parse(Console.ReadLine());

                Console.WriteLine("Введите дебет: ");
                DB[i].Debet = int.Parse(Console.ReadLine());

                Console.WriteLine("Введите номер кредит: ");
                DB[i].Credit = int.Parse(Console.ReadLine());

                Console.WriteLine("Введите время городских разговоров(кол-во мин.): ");
                DB[i].CityCallTime = int.Parse(Console.ReadLine());

                Console.WriteLine("Введите номер междугородных разговоров(кол-во мин.): ");
                DB[i].EntercityCallTime = int.Parse(Console.ReadLine());

                Console.WriteLine();
            }

            //a) сведения об абонентах, у которых время внутригородских разговоров превышает заданное;

            Console.WriteLine("Введите время внутригородских разговоров для сравнения: ");
            int checkCityCallTime = int.Parse(Console.ReadLine());
            for (int j = 0; j < numberOfUsers; j++)
            {
                if (DB[j].CityCallTime > checkCityCallTime)
                {
                    Console.WriteLine($"Найден абонент, у которого время внутригородских разговоров превышает заданное\n" +
                        $"{DB[j].FirstName} {DB[j].Name}. Продолжительность внутригородских разговоров: {DB[j].CityCallTime} минут");
                }
            }

            Console.WriteLine();

            //b) сведения об абонентах, которые пользовались междугородной связью;

            for (int j = 0; j < numberOfUsers; j++)
            {
                if (DB[j].EntercityCallTime > 0)
                {
                    Console.WriteLine($"Найден абонент, который пользовался междугородной связью\n" +
                        $"{DB[j].FirstName} {DB[j].Name}. Общая продолжительность междугородних разговоров: {DB[j].EntercityCallTime} минут");
                }
            }

            Console.WriteLine();

            //расчёт баланса всех абонентов
            const int sum = Phone.sum;
            int result;
            for (int j = 0; j < numberOfUsers; j++)
            {
                int balance = Balance(out result, sum, DB[j].Debet, DB[j].Credit);
                Console.WriteLine($"Баланс {DB[j].FirstName} {DB[j].Name} составляет {balance}");
            }

            Phone person1 = new Phone("Иванов", "Иван", "Иванович", "г. Минск", 1111, 50, 20, 500, 0);
            Phone person2 = new Phone("Иванова", "Инна", "Ивановна", "г. Минск", 2222, 50, 20, 500, 0);

            Console.WriteLine(person1.GetHashCode());               //для алгоритма вычисления хэша руководствуйтесь стандартными рекомендациями
            Console.WriteLine(person1.ToString());                  //вывода строки – информации об объекте
            Console.WriteLine(person1.Equals(person2));             //для сравнения объектов

            Console.WriteLine(person1.GetType());                   //проверьте тип созданного объекта

            var user = new { FirstName = "Иванов", Name = "Кирилл", NumberOfCard = 1757 }; // анонимный тип = var + инициализатор объекта (создание объекта без определения класса)
            Console.WriteLine($"Объект, созданный без определения класса(анонимный тип): {user.FirstName} {user.Name} с номером банковской карточки {user.NumberOfCard}");

            Console.ReadKey();
        }
    }
}
