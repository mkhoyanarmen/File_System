using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace File_System
{
    internal class FileWorker
    {
        public delegate void FileCreationHandler(string message);
        public event FileCreationHandler Notify;
        private FileStream fileWriter { get; set; }
        private StreamReader fileReader { get; set; }
        private string Text { get; set; }
        private string Path { get; set; }
        public FileWorker(string path)
        {
            Path = path;
        }
        public FileStream CreateFile()
        {
            fileWriter = new FileStream(Path, FileMode.Create, FileAccess.Write);
            return fileWriter;
        }
        public void WriteIntoFile(string text)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(text);
            fileWriter.Write(buffer, 0, buffer.Length);
            Notify?.Invoke($"{text} was written in the file");
            fileWriter.Close();
        }
        public void ReadFromFile()
        {
            fileReader = new StreamReader(Path);
            Text = fileReader.ReadToEnd();
            Notify?.Invoke($"{Text} was read from the file");
            fileReader.Close();
        }
    }
}
