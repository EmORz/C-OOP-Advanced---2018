using System;
using System.IO;
using FestivalManager.Core.IO.Contracts;

namespace FestivalManager.Core.IO
{
    public class FileReader : IReader
    {
        private string[] allLines;
        private const string path = @"E:\C-OOP-Advanced---2018\ExamPrepOOPAdvance\Structure_Skeleton_Festival\FestivalManager\Core\IO\Input.txt";
        private int pointer = 0;
        public FileReader()
        {
            this.allLines = File.ReadAllLines(path);
        }


        public string ReadLine()
        {
            string line = this.allLines[this.pointer++];

            return line;
        }
    }
}