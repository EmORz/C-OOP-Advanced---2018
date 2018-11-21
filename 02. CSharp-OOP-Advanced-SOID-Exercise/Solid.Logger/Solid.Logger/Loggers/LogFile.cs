using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Solid.Logger.Loggers.Contracts;

namespace Solid.Logger.Loggers
{
    public class LogFile : ILogFile
    {
        public void Write(string message)
        {
            this.Size += message.Where(char.IsLetter).Sum(x => x);
        }

        public int Size { get; private set; }
    }
}
