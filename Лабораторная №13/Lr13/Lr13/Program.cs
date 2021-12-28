using System;
using System.IO;

namespace Lr13
{
    class Program
    {
        static void Main(string[] args)
        {
            DriveInfo[] drives = DriveInfo.GetDrives();

            foreach (DriveInfo drive in drives)
            {
                PPPLog.PPPDiskInfo.AllDiskInfo(drive);
                PPPLog.PPPDiskInfo.FileSystemInfo(drive);
                PPPLog.PPPDiskInfo.FreeSpaceInfo(drive);
                Console.WriteLine();
            }

            Console.WriteLine("\nВведите путь к файлу, о котором необходимо получить информацию:");
            string path1 = Console.ReadLine();
            PPPLog.PPPFileInfo.SizeExtensionNameInfo(path1);
            PPPLog.PPPFileInfo.FullPathInfo(path1);
            PPPLog.PPPFileInfo.CreationDateInfo(path1);

            Console.WriteLine("\nВведите путь к директории, о которой необходимо получить информацию:");
            string path2 = Console.ReadLine();
            PPPLog.PPPDirInfo.NumberOfFiles(path2);
            PPPLog.PPPDirInfo.CreationTimeInfo(path2);
            PPPLog.PPPDirInfo.NumberOfSubdir(path2);
            PPPLog.PPPDirInfo.ListOfParentDir(path2);

            Console.WriteLine("\nВведите имя диска, с которого хотите прочитать список папок и файлов:");
            string path3 = Console.ReadLine();
            PPPLog.PPPFileManager.ListOfFilesAndFolders(path3);
            PPPLog.PPPFileManager.CreateDir();
            PPPLog.PPPFileManager.CreateFile(path3);
            PPPLog.PPPFileManager.CreateCopyAndRename();

            Console.WriteLine("\nВведите путь к папке, из которой необходимо скопировать все файлы с расширением .docx в новую папку PPPFiles:");
            string path4 = Console.ReadLine();
            PPPLog.PPPFileManager.CreateAnotherDir(path4);
            PPPLog.PPPFileManager.CompressionFile();

            PPPLog.PPPFileManager.CheckedInfo.CheckedActions();
        }
    }
}
