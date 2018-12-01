using System;
using System.Collections.Generic;
using System.Text;
using Problem7InfernoInfinity.Contracts;

namespace Problem7InfernoInfinity.Core.Commands
{
    public class PrintCommand : Command
    {
        private IRepository repository;

        public PrintCommand(string[] data) : base(data)
        {
        }

        public override void Execute()
        {
            string result = this.repository.PrintWeapon(this.Data[0]);
            Console.WriteLine(result);
        }
    }
}
