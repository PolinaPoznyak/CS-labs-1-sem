using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace Lr6
{
    interface IHasInfo
    {
        void DisplayInfo();
    }
    enum InStock
    {
        Cookies,
        BubbleGum,
        Candies,
        ChocolateBars,
        Lollipops,
        Cakes
    }
    class Program
    {
        static async Task Main(string[] args)
        {
            Customer customer1 = new Customer();
            Candy candy1 = new Candy("Красная шапочка", 10, 500, 10, "карамель");
            Cookie cookie1 = new Cookie("Мария", 5, 1000, 5, false);
            ChocolateBar choco1 = new ChocolateBar("Алёнка", 1, 250, 50,"Молочный");
            Candy candy3 = new Candy("Черёмушка", 8, 200, 10, "шоколад");

            Console.WriteLine("<------Sweets in stock:------>");
            var values = Enum.GetValues(typeof(InStock));
            foreach (var item in values)
            {
                Console.WriteLine(item);
            }


            /*
            Console.Write("Вызов метода у класса: ");
            customer1.Boxing(true);                     // вызов метода у класса
            Console.Write("Вызов метода у интерфейса: ");
            ((IBoxing)customer1).Boxing(true);         // вызов метода у интерфейса

            Confectioneries[] shopping = { candy1, cookie1, choco1 };
            foreach (var item in shopping)
            {
                customer1.CheckInfo(item);
                Console.WriteLine();
            }

            Console.WriteLine("Перераспределение ToString():");
            Console.WriteLine(candy1);
            Console.WriteLine(cookie1);
            Console.WriteLine(choco1);
            */

            var present = new Present(new List<Confectioneries> { candy1, cookie1, choco1 });
            
            Console.WriteLine("<------Список конфет, содержащихся в подарке ДО сортировки по цене: ------>");
            present.ShowList();
            Console.WriteLine("<------Список конфет, содержащихся в подарке ПОСЛЕ сортировки по цене: ------>");
            present.PriceSort();
            present.ShowList();

            Console.WriteLine("<------Поиск кондитерского изделия в подарке, соответствующего заданному диапазону содержания сахара (от 3 до 20 гр): ------>");
            present.SearchForSugar(3, 20);

            present.DelCandy();
            Console.WriteLine("<------Список конфет, содержащихся в подарке ПОСЛЕ удаления кондитерсого изделия: ------>");
            present.ShowList();
            present.AddCandy(candy3);
            Console.WriteLine("<------Список конфет, содержащихся в подарке ПОСЛЕ добавления ещё одного кондитерсого изделия: ------>");
            present.ShowList();

            Console.WriteLine("<------------------------------------------------------------------------------------------->");
            present.WriteTextFile();
            present.ReadTextFile();
            Console.WriteLine("<------------------------------------------------------------------------------------------->");


            // сохранение данных
            using (FileStream fs = new FileStream(@"D:\JsonFile.json", FileMode.OpenOrCreate))
            {
                await JsonSerializer.SerializeAsync<Candy>(fs, candy3);
                Console.WriteLine("Информация сохранена в файл json ");
            }
            // чтение данных
            using (FileStream fs = new FileStream(@"D:\JsonFile.json", FileMode.OpenOrCreate))
            {
                Candy restoredCandy = await JsonSerializer.DeserializeAsync<Candy>(fs);
                Console.WriteLine($"Название: {restoredCandy.Name}  Цена: {restoredCandy.Price}");
            }

        }
    }
}