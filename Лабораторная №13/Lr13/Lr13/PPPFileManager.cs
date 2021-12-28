﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;

namespace Lr13
{
    partial class PPPLog
    {
        public static class PPPFileManager
        {
            public static void ListOfFilesAndFolders(string path)
            {
                if (Directory.Exists(path))
                {
                    Console.WriteLine("Папки: ");
                    string[] dirs = Directory.GetDirectories(path);
                    foreach (string s in dirs)
                    {
                        Console.WriteLine(s);
                    }
                    Console.WriteLine();
                    Console.WriteLine("Файлы: ");
                    string[] files = Directory.GetFiles(path);
                    foreach (string s in files)
                    {
                        Console.WriteLine(s);
                    }
                }
                Checked($"Пользователь прочитал список файлов и папок заданного диска с помощью метода ListOfFilesAndFolders");
            }
            public static void CreateDir()
            {
                string path = @"D:\ООП\Лабораторная №13\PPPInspect";
                DirectoryInfo newDir = new DirectoryInfo(path);
                if (!newDir.Exists)
                {
                    newDir.Create();
                    Console.WriteLine("Новая папка успешно создана");
                }
                Checked($"Пользователь создал новую папку {newDir.FullName} с помощью метода CreateDir");
            }
            public static void CreateFile(string path)
            {
                string path1 = @"D:\ООП\Лабораторная №13\PPPInspect\pppdirinfo.txt";
                try
                {
                    string[] dirs = Directory.GetDirectories(path);
                    string[] files = Directory.GetFiles(path);
                    using (StreamWriter sw = new StreamWriter(path1, true, Encoding.Default))
                    {
                        sw.WriteLine($"Информация о диске: "); ;
                        sw.WriteLine("Папки: ");
                        foreach (string s in dirs)
                        {
                            sw.WriteLine(s);
                        }
                        sw.WriteLine("Файлы: ");
                        foreach (string s in files)
                        {
                            sw.WriteLine(s);
                        }
                    }
                    Console.WriteLine("Запись выполнена");
                }

                catch (Exception e)
                {
                    Console.WriteLine($"Возникло исключение: {e.Message}");
                }
                Checked($"Пользователь создал новый файл и записал в него информацию о диске с помощью метода CreateFile");
            }
            public static void CreateCopyAndRename()
            {
                string path = @"D:\ООП\Лабораторная №13\PPPInspect\pppdirinfo.txt";
                string copyPath = @"D:\ООП\Лабораторная №13\PPPInspect\pppdirinfoRenamed.txt";
                FileInfo file = new FileInfo(path);
                if (file.Exists)
                {
                    file.CopyTo(copyPath);
                    file.Delete();
                    Console.WriteLine("Файл скопирован и удалён");
                }
                Checked($"Пользователь создал копию файла, переименовал её, а старый файл удалил с помощью метода CreateCopyAndRename");
            }
            public static void CreateAnotherDir(string path)
            {
                string newPath = @"D:\ООП\Лабораторная №13\PPPFiles";
                string destDirName = @"D:\ООП\Лабораторная №13\PPPInspectNew\";
                DirectoryInfo newDir = new DirectoryInfo(newPath);
                if (!newDir.Exists)
                {
                    newDir.Create();
                    Console.WriteLine("Новая папка успешно создана");
                }

                DirectoryInfo dir = new DirectoryInfo(path);

                if (dir.Exists)
                {
                    foreach (FileInfo item in dir.GetFiles())
                    {
                        if (item.Name.Contains(".docx"))
                        {
                            item.CopyTo($@"D:\ООП\Лабораторная №13\PPPFiles\{item.Name}");
                        }

                    }
                }
                DirectoryInfo directory = new DirectoryInfo(newPath);

                if (directory.Exists && Directory.Exists(destDirName) == false)
                {
                    directory.MoveTo(destDirName);
                    Console.WriteLine("Перемещение прошло успешно");
                }
                Checked($"Пользователь создал новую папку, куда отобрал файлы с расширением .docx, а затем переместил папку в другую с помощью метода CreateAnotherDir");
            }
            public static void CompressionFile()
            {
                string targetFolder = @"D:\ООП\Лабораторная №13";
                string zipFile = @"D:\ООП\Лабораторная №13\PPPFiles.zip";
                string sourceFolder = @"D:\ООП\Лабораторная №13\PPPInspectNew\";

                ZipFile.CreateFromDirectory(sourceFolder, zipFile);
                Console.WriteLine($"Папка {sourceFolder} архивирована в файл {zipFile}");

                ZipFile.ExtractToDirectory(zipFile, targetFolder);
                Console.WriteLine($"Файл {zipFile} распакован в папку {targetFolder}");

                Checked($"Пользователь создал архив из файлов директория PPPFiles, а затем разархивировал его в другой директорий с помощью метода CompressionFile");
            }
            public static class CheckedInfo
            {
                private const string path = @"D:\ООП\Лабораторная №13\ppplogfile.txt";
                public static void CheckedActions()
                {
                    try
                    {
                        using (StreamReader sr = new StreamReader(path, Encoding.Default))
                        {
                            int count = 0;
                            Console.WriteLine("Введите ключевое слово для поиска: ");
                            string word = Console.ReadLine();
                            string line;
                            while ((line = sr.ReadLine()) != null)
                            {
                                if (line.Contains(word))
                                {
                                    Console.WriteLine("Найдена запись: ");
                                    Console.WriteLine(line);
                                    count++;
                                }
                            }
                            Console.WriteLine($"Количество записей: {count}");
                        }
                        using (StreamReader sr = new StreamReader(path, Encoding.Default))
                        {
                            int count = 0;
                            Console.WriteLine("\nВведите дату слово для поиска: ");
                            string date = Console.ReadLine();
                            string line;
                            while ((line = sr.ReadLine()) != null)
                            {
                                if (line.Contains(date))
                                {
                                    Console.WriteLine("Найдена запись: ");
                                    Console.WriteLine(line);
                                    count++;
                                }
                            }
                            Console.WriteLine($"Количество записей: {count}");
                        }
                    }
                    catch (Exception e)
                    {

                        Console.WriteLine(e.Message);
                    }
                }
            }
        }
    }
}
