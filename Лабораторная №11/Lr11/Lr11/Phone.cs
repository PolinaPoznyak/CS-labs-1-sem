using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lr11
{
    class Phone
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

        public void PrintInfoDB()
        {
            Console.WriteLine($"Фамилия: {firstName}\n" +
                $"Имя: {name}\n" +
                $"Отчество: {secondName}\n" +
                $"Адрес: {adress}\n" +
                $"Номер банковской карты: {numberOfCard}\n");
        }
    }
}
