using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lr5
{
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
    }
    class Candy : Confectioneries
    {
        public string Filling { get; set; }
        public Candy(string name, int price, string filling) : base(name, price)
        {
            Filling = filling;
        }
        public override void DisplayInfo()
        {
            Console.WriteLine($"Название конфеты: {Name} \nЦена конфет за кг(в BYN): {Price} \nНачинка конфеты: {Filling} \n");
        }
        public override string ToString()
        {
            return "Название: " + Name + "\nЦена: " + Price + "\nНачинка: " + Filling + "\n";
        }
    }
    class Cookie : Confectioneries
    {
        public bool IsNuts { get; set; }
        public Cookie(string name, int price, bool isNuts) : base(name, price)
        {
            IsNuts = isNuts;
        }
        public override void DisplayInfo()
        {
            Console.WriteLine($"Название печенья: {Name} \nЦена печенья за кг(в BYN): {Price}");
            if (IsNuts == true)
            {
                Console.WriteLine("Печенье содержит арахис \n");
            }
            else
            {
                Console.WriteLine("Печенье не содержит арахис \n");
            }
        }
        public override string ToString()
        {
            return "Название: " + Name + "\nЦена: " + Price + "\n";
        }
    }
    // класс ChocolateBar наследует от класса Confectioneries, но никакие классы не могут наследовать от класса ChocolateBar (из-за sealed)
    sealed class ChocolateBar : Confectioneries
    {
        public string WhiteOrMilk { get; set; }
        public ChocolateBar(string name, int price, string whiteOrMilk) : base(name, price)
        {
            WhiteOrMilk = whiteOrMilk;
        }
        // переопределение ToString()
        public override string ToString()
        {
            return "Шоколадка: " + Name + "\nЦена за плитку(в BYN): " + Price + "\n" + WhiteOrMilk + " шоколад" + "\n";
        }
    }

    class Printer
    {
        public static void IAmPrinting(IBoxing iboxing)
        {
            Console.WriteLine(iboxing.ToString());
        }
    }

}
