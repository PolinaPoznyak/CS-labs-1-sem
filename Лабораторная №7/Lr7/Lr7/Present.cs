using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Lr7
{
    partial class Present
    {
        public Present(List<Confectioneries> candies)
        {
            Candies = candies;
        }
        public List<Confectioneries> Candies { get; set; } = new List<Confectioneries>();
        public void AddCandy(Confectioneries confectioneries)
        {
            Candies.Add(confectioneries);
        }
        public void DelCandy()
        {
            Candies.RemoveAt(Candies.Count - 1);
        }
        public void ShowList()
        {
            foreach (var item in Candies)
            {
                Console.WriteLine(item.ToString());
            }
        }
        public void WriteTextFile()
        {
            string path = @"D:\TextFile.txt";
            foreach (var item in Candies)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))
                    {
                        sw.WriteLine(item);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    Console.WriteLine("Коллекция записана в файл");
                }
            }
        }
        public void ReadTextFile()
        {
            string path = @"D:\TextFile.txt";
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }
    }
}
