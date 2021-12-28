using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lr10
{
    class Furniture 
    {
        public string name { get; set; }
        public int price { get; set; }
        public string madeOf { get; set; }
        public bool inStock;
        public bool InStock
        {
            set 
            { 
                if (value == true)
                {
                    Console.WriteLine("в наличии");
                }
                else
                {
                    Console.WriteLine("нет в наличии");
                }
            }
            get { return inStock; }
        }

        public override string ToString()
        {
            return $"\n{name} \nЦена: {price} \nНаличие: {inStock} \nМатериал: {madeOf}";
        }
        public void Information()
        {
            
        }
    }

}
