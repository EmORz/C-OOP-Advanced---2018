using System.IO;
using FestivalManager.Core.IO.Contracts;

namespace FestivalManager.Core.IO
{
    public class FileReader : IReader
    {
        private string[] allLines;
        private int counter;

        public FileReader()
        {
            this.counter = 0;
            this.allLines =
                File.ReadAllLines(
                    @"C:\Users\User\Desktop\ExamPrepFirst\01. Structure_Skeleton (.NET Core) (2)\FestivalManager\Core\IO\Input.txt");
        }
        public string ReadLine()
        {
            string line = this.allLines[counter++];

            return line;
        }
    }
}