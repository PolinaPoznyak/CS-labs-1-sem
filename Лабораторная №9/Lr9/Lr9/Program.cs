using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lr9
{
    //class Writer
    //{
    //    public delegate void AccountHandler(string message);
    //    public event AccountHandler Delete;
    //    public event AccountHandler Modify;
    //    public event AccountHandler Vvod;
    //    public event AccountHandler Upper;
    //    public event AccountHandler Lower;
    //    public Writer()
    //    {
    //        Console.WriteLine("Введите слово:");
    //    }
    //    public string Slovo { get; private set; }
    //    public void Put(string slovo)
    //    {
    //        Slovo = slovo;
    //        Vvod.Invoke($"Введенное слово: {slovo}");
    //    }
    //    public void Del(string slovo)
    //    {
    //        slovo = slovo.Remove(0, 1);
    //        Delete.Invoke($"Удаление: {slovo}");
    //    }
    //    public void Mut(string slovo)
    //    {
    //        slovo = slovo.Replace("S", "A");
    //        Modify.Invoke($"Замена S на А: {slovo}");
    //    }
    //    public void ToUpper(string slovo)
    //    {
    //        slovo = slovo.ToUpper();
    //        Upper.Invoke($"В верхний регистр: {slovo}");
    //    }
    //    public void ToLower(string slovo)
    //    {
    //        slovo = slovo.ToLower();
    //        Upper.Invoke($"В нижний регистр: {slovo}");
    //    }
    //}
    class Program
    {
        static void Main(string[] args)
        {
            
            Boss obj1 = new Boss("Сири", 100, true, 1);
            Boss obj2 = new Boss("Алиса", 1500, false, 5);
            Boss obj3 = new Boss("Карина", 100, true, 0);

            //obj1.UpgradeState(new Upgrade(Display));
            //obj2.UpgradeState(Display);
            //obj3.UpgradeState(Display);

            obj1.Upgraded += new Upgrade(Display);       //регистрация обработчики события
            obj2.Upgraded += Display;
            obj3.Upgraded += Display;

            obj1.Upgrading(5);
            obj2.Upgrading(3);
            obj3.Upgrading(0);

            
            obj1.Turned += Display;
            obj2.Turned += Display;
            obj3.Turned += Display;

            obj1.Turning_on(true);
            obj2.Turning_on(false);
            obj3.Turning_on(true);

            //Writer str = new Writer();
            //str.Vvod += Display; //добавление обработчика события
            //str.Delete += Display;
            //str.Modify += Display;
            //str.Upper += Display;
            //str.Lower += Display;
            //str.Put(Console.ReadLine());
            //str.ToUpper(str.Slovo);
            //str.ToLower(str.Slovo);
            //str.Del(str.Slovo);
            //str.Mut(str.Slovo);

            string slovo1 = "Hello world ";
            string slovo2 = "How are you?";

            Action<string> del;
            del = (string str1) => { Console.WriteLine($"Удаление: {str1 = str1.Remove(0, 1)}"); };
            Del(slovo1, del);

            Action<string, string> con;
            con = (string str1, string str2) => { Console.WriteLine($"Конкантенация: {str1 = str1 + str2}"); };
            Con(slovo1, slovo2, con);

            Action<string> mut;
            mut = (string str1) => { Console.WriteLine($"Замена l на L: {str1 = str1.Replace("l", "L")}"); };
            Mut(slovo1, mut);

            Action<string> toUpper;
            toUpper = (string str1) => { Console.WriteLine($"В верхнем регистре: {str1 = str1.ToUpper()}"); };
            ToUpper(slovo1, toUpper);

            Action<string> toLower;
            toLower = (string str1) => { Console.WriteLine($"В нижнем регистре: {str1 = str1.ToLower()}"); };
            ToLower(slovo1, toLower);

            Console.Read();
        }
        static void Con(string slovo1, string slovo2, Action<string, string> con) => con(slovo1, slovo2);
        static void Del(string slovo, Action<string> del) => del(slovo);
        static void Mut(string slovo, Action<string> mut) => mut(slovo);
        static void ToUpper(string slovo, Action<string> toUpper) => toUpper(slovo);
        static void ToLower(string slovo, Action<string> toLower) => toLower(slovo); 
        
        static void Display(string message)   //Display соответствует делегату Upgrade
        {
            Console.WriteLine(message);
        }
    }
}
