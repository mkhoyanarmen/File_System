using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FileWorker file = new FileWorker("fileName.txt");
            file.Notify += DisplayMessage;
            file.CreateFile();
            file.WriteIntoFile("Hello, Armenia!");
            file.ReadFromFile();
        }
        static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
