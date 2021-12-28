using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lr7
{
    static class Logger
    {
        public static void ConsoleLogger(string msg)
        {
            Console.WriteLine($"Date: {DateTime.Now}\nMessage: {msg}");
        }
        public static void FileLogger(string msg)
        {
            string path = @"D:\LoggerFile.txt";
            using (StreamWriter sr = new StreamWriter(path, true))
            {
                sr.WriteLine($"Date: {DateTime.Now}\n {msg}");
            }
        }
    }
}
