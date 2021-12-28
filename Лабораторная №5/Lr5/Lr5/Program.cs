using System;

namespace Lr5
{
    interface IHasInfo
    {
        void DisplayInfo();
    }
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer1 = new Customer();
            Candy candy1 = new Candy("Красная шапочка", 10, "карамель");
            Cookie cookie1 = new Cookie("Мария", 5, false);
            ChocolateBar choco1 = new ChocolateBar("Алёнка", 1, "Молочный");

            Console.Write("Вызов метода у класса: ");
            customer1.Boxing(true);                     // вызов метода у класса
            Console.Write("Вызов метода у интерфейса: ");
            ((IBoxing)customer1).Boxing(true);         // вызов метода у интерфейса

            Confectioneries[] shopping = { candy1, cookie1, choco1 };
            foreach(var item in shopping)
            {
                customer1.CheckInfo(item);
                Console.WriteLine();
            }

            Console.WriteLine("Перераспределение ToString():");
            Console.WriteLine(candy1);
            Console.WriteLine(cookie1);
            Console.WriteLine(choco1);

            Confectioneries candy2 = new Confectioneries("Степ", 3);
            Candy can2 = candy2 as Candy;
            if(can2 == null)
            {
                Console.WriteLine("Преобразование прошло неудачно");            //явно не является, поэтому false
            }
            else
            {
                Console.WriteLine(can2.Filling);
            }

            Confectioneries candy3 = new Confectioneries("Столичные", 2);
            if (candy3 is Candy can3)
            {
                Console.WriteLine(can3.Filling);            
            }
            else
            {
                Console.WriteLine("Преобразование прошло неудачно");
            }

            Printer iboxing = new Printer();
            //iboxing.IAmPrinting();
        }
    }
}
