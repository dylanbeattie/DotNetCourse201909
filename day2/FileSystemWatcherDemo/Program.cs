using System;
using System.IO;
using System.Threading;

namespace FileSystemWatcherDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Environment.CurrentDirectory);
            var watcher = new FileSystemWatcher(".", "*.txt");
            watcher.Created += FileCreated;
            watcher.Changed += FileChanged;
            watcher.EnableRaisingEvents = true;
            while(true) { Thread.Sleep(100); }
        }

        static void FileCreated(object sender, FileSystemEventArgs e) {
            Console.WriteLine($"Created {e.FullPath}");
        }

        static void FileChanged(object sender, FileSystemEventArgs e) {
            Console.WriteLine($"Changed {e.FullPath}");
        }
    }
}
