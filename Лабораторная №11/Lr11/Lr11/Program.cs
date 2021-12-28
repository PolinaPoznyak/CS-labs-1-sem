using System;
using System.Collections.Generic;
using System.Linq;

namespace Lr11
{
    class Operatory
    {
        public string Name { get; set; }
        public string Mobileservice { get; set; }
    }
    class MobileService
    {
        public string Name { get; set; }
        public string Country { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string[] months = new string[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

            Console.WriteLine("Введите количество символов(n): ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("<---Последовательность месяцев с длиной строки равной n: --->");
            var selectedMonth1 = from m in months    // определяем каждый объект из teams как t
                                 where m.Length == n  //фильтрация по критерию
                                 select m;            // выбираем объект
            foreach (string s in selectedMonth1)
                Console.WriteLine(s);

            Console.WriteLine("<---Только летние и зимние месяцы: --->");
            IEnumerable<string> selectedMonth2 = months.Where(m => m.StartsWith("D") || m.StartsWith("J") || m.StartsWith("F") || m.StartsWith("Au"));
            foreach (string s in selectedMonth2)
                Console.WriteLine(s);

            Console.WriteLine("<---В алфавитном порядке: --->");
            var selectedMonth3 = from m in months   
                                orderby m       
                                select m;         
            foreach (string s in selectedMonth3)
                Console.WriteLine(s);

            Console.WriteLine("<---Запрос, считающий месяцы содержащие букву «u» и длиной имени не менее 4-х: --->");
            int index = 0;
            IEnumerable<string> selectedMonth4 = months.Where(m => m.Contains("u") && m.Length >= 4);
            foreach (string s in selectedMonth4)
            {
                Console.WriteLine(s);
                index++;
            }
            Console.WriteLine($"Количество таких месяцев - {index}");

            List<Phone> phonesList = new List<Phone>
            {
                new Phone {FirstName = "Иванов", Name = "Иван", SecondName = "Иванович", Adress = "г. Иваново", NumberOfCard = 12456, Debet = 400, Credit = 300, CityCallTime = 200, EntercityCallTime = 0},
                new Phone {FirstName = "Петрова", Name = "Инна", SecondName = "Николаевна", Adress = "г. Брест", NumberOfCard = 65484, Debet = 400, Credit = 500, CityCallTime = 500, EntercityCallTime = 50},
                new Phone {FirstName = "Романова", Name = "Елена", SecondName = "Константиновна", Adress = "г. Барановичи", NumberOfCard = 45648, Debet = 500, Credit = 200, CityCallTime = 0, EntercityCallTime = 100},
                new Phone {FirstName = "Минич", Name = "Артём", SecondName = "Эдуардович", Adress = "г. Минск", NumberOfCard = 21654, Debet = 800, Credit = 300, CityCallTime = 350, EntercityCallTime = 60},
                new Phone {FirstName = "Панютич", Name = "Кристина", SecondName = "Евгеньевна", Adress = "г. Бобруйск", NumberOfCard = 963148, Debet = 900, Credit = 300, CityCallTime = 700, EntercityCallTime = 90},
                new Phone {FirstName = "Вакульчик", Name = "Елизавета", SecondName = "Петровна", Adress = "г. Минск", NumberOfCard = 35794, Debet = 1000, Credit = 450, CityCallTime = 290, EntercityCallTime = 0},
                new Phone {FirstName = "Кизик", Name = "Роман", SecondName = "Николаевич", Adress = "г. Брест", NumberOfCard = 98456, Debet = 1050, Credit = 800, CityCallTime = 200, EntercityCallTime = 500},
                new Phone {FirstName = "Хотынюк", Name = "Юлианна", SecondName = "Ивановна", Adress = "г. Гомель", NumberOfCard = 222547, Debet = 500, Credit = 600, CityCallTime = 0, EntercityCallTime = 0},
                new Phone {FirstName = "Гринкевич", Name = "Степан", SecondName = "Олегович", Adress = "г. Несвиж", NumberOfCard = 65483, Debet = 490, Credit = 230, CityCallTime = 400, EntercityCallTime = 100},
                new Phone {FirstName = "Киричик", Name = "Карина", SecondName = "Максимовна", Adress = "г. Могилёв", NumberOfCard = 54189, Debet = 700, Credit = 100, CityCallTime = 600, EntercityCallTime = 0},
            };

            Console.WriteLine("<--Упорядоченный список абонентов по фамилии-->");
            var ph4 = from ph in phonesList
                      orderby ph.FirstName
                      select ph;
            foreach (Phone item in ph4)
            {
                Console.WriteLine($"{item.FirstName} {item.Name}");
            }

            Console.WriteLine("<---Сведения об абонентах, у которых время внутригородских разговоров превышает заданное--->");
            Console.WriteLine("Введите время внутригородских разговоров:");
            int checkCityCalltime = int.Parse(Console.ReadLine());
            var ph1 = from ph in phonesList
                      where ph.CityCallTime > checkCityCalltime
                      select ph;
            foreach (Phone ph in ph1)
            {
                Console.WriteLine($"{ph.FirstName} {ph.Name} - {ph.CityCallTime} минут");
            }

            Console.WriteLine("<---Сведения об абонентах, которые пользовались междугородной связью--->");
            var ph2 = phonesList.Where(ph => ph.EntercityCallTime != 0);
            foreach (Phone ph in ph2)
            {
                Console.WriteLine($"{ph.FirstName} {ph.Name} - {ph.EntercityCallTime} минут");
            }

            Console.WriteLine("<---Количество абонентов с заданным значением дебетамаксимального абонента(по вашему критерию)--->");
            Console.WriteLine("Задайте дебет: ");
            int choiceDebet = int.Parse(Console.ReadLine());
            var ph3 = phonesList.Where(ph => ph.Debet == choiceDebet).Count();
            Console.WriteLine($"Количество абонентов с заданным значением дебета - {ph3}");

            IEnumerable<Phone> events = (from i in phonesList
                                        orderby i.FirstName
                                        where i.EntercityCallTime != 0
                                        where i.Credit > 200
                                        where i.Adress.Length > 8
                                        select i);
            foreach (Phone item in events)
            {
                Console.WriteLine($"{item.FirstName} {item.Name}");
            }

            int min2 = phonesList.Min(n => n.Debet);             //Метод Aggregate
            Console.WriteLine($"Минимальный кредит равен - {min2}");

            //var phoneGroups = from phone in phonesList
            //                  group phone by phone.Debet;
            //Console.WriteLine("");
            //foreach (Phone item in phoneGroups)
            //{
            //    Console.WriteLine($"{item.FirstName} {item.Name}");
            //}

            Console.WriteLine("<---Мобильные сервисы и операторы--->");
            List<MobileService> oper = new List<MobileService>()
            {
                new MobileService { Name = "Tele2", Country ="Россия" },
                new MobileService { Name = "МТС", Country ="Беларусь" }
            };
            List<Operatory> mobile = new List<Operatory>()
            {
                new Operatory {Name="Оператор Кристина", Mobileservice="МТС"},
                new Operatory {Name="Оператор Вадим", Mobileservice="МТС"},
                new Operatory {Name="Оператор Егор", Mobileservice="Tele2"}
            };

            var result = from ms in mobile
                         join o in oper on ms.Mobileservice equals o.Name
                         select new { Name = ms.Name, Team = ms.Mobileservice, Country = o.Country };

            foreach (var item in result)
                Console.WriteLine($"{item.Name} - {item.Team} ({item.Country})");
        }
    }
}
