using System;
using System.Collections.Generic;

namespace Lr6
{
    abstract class Confectioneries : IHasInfo
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        public int Sugar { get; set; }
        public Confectioneries(string name, int price)
        {
            Name = name;
            Price = price;        
        }
        public Confectioneries(string name, int price, int weight)
        {
            Name = name;
            Price = price;
            Weight = weight;
        }
        public Confectioneries(string name, int price, int weight, int sugar)
        {
            Name = name;
            Price = price;
            Weight = weight;
            Sugar = sugar;
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
        public Candy(string name, int price, int weight, int sugar, string filling) : base(name, price, weight, sugar)
        {
            Filling = filling;
        }
        public override void DisplayInfo()
        {
            Console.WriteLine($"Название конфеты: {Name} \nЦена конфет за кг(в BYN): {Price} \nНачинка конфеты: {Filling} \n");
        }
        public override string ToString()
        {
            return "Название: " + Name + "\nЦена(в BYN): " + Price + "\nСодержание сахара(г): " + Sugar + "\n";
        }
    }
    class Cookie : Confectioneries
    {
        public bool IsNuts { get; set; }
        public Cookie(string name, int price, int weight, int sugar, bool isNuts) : base(name, price, weight, sugar)
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
            return "Название: " + Name + "\nЦена(в BYN): " + Price + "\nСодержание сахара(г): " + Sugar + "\n";
        }
    }
    // класс ChocolateBar наследует от класса Confectioneries, но никакие классы не могут наследовать от класса ChocolateBar (из-за sealed)
    sealed class ChocolateBar : Confectioneries
    {
        public string WhiteOrMilk { get; set; }
        public ChocolateBar(string name, int price, int weight, int sugar, string whiteOrMilk) : base(name, price, weight, sugar)
        {
            WhiteOrMilk = whiteOrMilk;
        }
        public override string ToString()
        {
            return "Название: " + Name + "\nЦена(в BYN): " + Price + "\nСодержание сахара(г): " + Sugar + "\n";
        }
    }
    class Printer
    {
        public static void IAmPrinting(IBoxing iboxing)
        {
            Console.WriteLine(iboxing.ToString());
        }
    }
    struct StructPrinter
    {
        public static void IAmPrinting(IBoxing iboxing)
        {
            Console.WriteLine(iboxing.ToString());
        }
    }

    partial class Present
    {
        public int WeightCount()
        {
            int fullWeight = 0;
            foreach (var item in Candies)
            {
                fullWeight += item.Weight;
            }
            return fullWeight;
        }
        public void PriceSort()
        {
            for (int i = 0; i < Candies.Count; i++)
            {
                for (int j = i; j < Candies.Count; j++)
                {
                    if (Candies[i].Price > Candies[j].Price)
                    {
                        int tmp = Candies[j].Price;
                        Candies[j].Price = Candies[i].Price;
                        Candies[i].Price = tmp;
                    }
                }
            }
        }
        public void SearchForSugar(int x, int y)
        {
            foreach (var item in Candies)
            {
                if((item.Sugar > x) && (item.Sugar < y))
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }
    }
}
