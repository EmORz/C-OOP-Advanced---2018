using System.IO;
using CosmosX.IO.Contracts;

namespace CosmosX.IO
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string output)
        {
            File.AppendAllText("sekretenDokuemntNeGoPipai.txt", output);
        }
    }
}