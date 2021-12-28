using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace Lr7
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

            try
            {
                new Candy("Красная шапочка", 10, 0, 1, "карамель");
                try
                {
                    new Candy("Краснаааая шапочка", 10, 0, 10, "карамель");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                new Candy("Красная шапочка", 10, 500, -5, "карамель");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                new Candy("Красная шапочка", 10, 500, 5, "кар");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            try
            {
                new Cookie("Мария", 5, 00, 5, false);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            try
            {
                new Cookie("Мария", 5, 100, -5, false);
            }
            catch (Exception ex)
            {
                Logger.FileLogger(ex.ToString());
                Logger.ConsoleLogger(ex.Message);
            }
            finally
            {
                Console.WriteLine("Finally block");
            }
            Cookie cookie1 = new Cookie("Мария", 5, 1000, 5, false);
            ChocolateBar choco1 = new ChocolateBar("Алёнка", 1, 250, 50, "Молочный");
            Candy candy3 = new Candy("Черёмушка", 8, 200, 10, "шоколад");

            

        }
    }
}