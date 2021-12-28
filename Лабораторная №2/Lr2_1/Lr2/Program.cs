using System;

namespace Lr2
{
    class Program
    {
        static void Main(string[] args)
        {
            //переменные примитивных типов
            bool vBool = true;
            byte vByte = 255;
            sbyte vSbyte = 127;
            char vChar = 'P';
            decimal vDecimal = 50.0M; //что значит М?
            double vDouble = 180.10;
            float vFloat = 0.5f;
            int vInt = 10;
            uint vUint = 0b101;
            long vLong = 0b101;
            ulong vUlong = 0xFF;
            short vShort = 30000;
            ushort vUshort = 60000;

            //операции явного преобразования
            vByte = (byte)vSbyte;
            vUlong = (ulong)vUshort;
            vChar = (char)vInt;
            vInt = (int)vDouble;
            vInt = (int)vShort;

            //операции неявного преобразования
            vLong = vInt;
            vUlong = vUshort;
            vUint = vChar;
            vFloat = vUlong;
            vInt = vByte;

            //возможности класса Convert
            int a;
            double b;

            a = Convert.ToInt32('k');
            b = Convert.ToDouble(vBool);

            Console.WriteLine($"decimal={vDecimal} a={a}  c={b} ");

            //упаковка и распаковка значимых типов
            Int32 x = 5;
            Object o = x;               //упаковка
            byte bt = (byte)(int)o;     //распаковка и приведение к типу

            //работа с неявно типизированной переменной
            var mas1 = new[] { 1, 3, 5, 7, 9 };
            var mas2 = new[] { 'a', 'b', 'c', 'd', 'e' };
            var mas3 = new[] { 1, 1.11 };
            Console.WriteLine(mas1.GetType());
            Console.WriteLine(mas2.GetType());
            Console.WriteLine(mas3.GetType());

            //работа с Nullable переменной
            Nullable<int> n1 = null;
            int? n2 = 10;

            //изменение значения переменной типа var
            var anyVar = 5;
            anyVar = '5';
            Console.WriteLine(anyVar);

        }
    }
}
