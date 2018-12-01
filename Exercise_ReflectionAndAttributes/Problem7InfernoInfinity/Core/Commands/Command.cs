using Problem7InfernoInfinity.Contracts;

namespace Problem7InfernoInfinity.Core.Commands
{
    public abstract class Command : IExecutable
    {
        private string[] data;

        public Command(string[] data)
        {
            this.data = data;
        }
        protected string[] Data => this.data;
        public abstract void Execute();
    }
}
