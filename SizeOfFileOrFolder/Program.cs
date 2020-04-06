using System;
using System.IO;

namespace SizeOfFileOrFolder
{
    class Program
    {
        public static long folderSize = 0;
        static void Main(string[] args)
        {
            Console.WriteLine("File or folder:");
            string path = Console.ReadLine();
            if (File.Exists(path))
            {
                ProcessFile(path);
                Console.WriteLine("The size of the file is: {0} bytes.", folderSize);
            }
            else if (Directory.Exists(path))
            {
                ProcessDirectory(path);
                Console.WriteLine("The size of the folder is: {0} bytes.", folderSize);
            }
            else
            {
                Console.WriteLine("{0} is not a valid file or directory.", path);
            }
        }
        public static void ProcessDirectory(string targetDirectory)
        {
            string[] fileEntries = Directory.GetFiles(targetDirectory);
            foreach (string fileName in fileEntries)
                ProcessFile(fileName); 

            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subdirectoryEntries)
                ProcessDirectory(subdirectory);
        }

        public static void ProcessFile(string path)
        {
            FileInfo fi = new FileInfo(path);
            folderSize += fi.Length;
            //Console.WriteLine("Processed file '{0}', with size of {1} bytes, total size of files: {2} bytes.", path, fi.Length,folderSize);
        }
    }
}
