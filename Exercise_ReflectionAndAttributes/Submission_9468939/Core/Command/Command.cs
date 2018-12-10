using _03BarracksFactory.Contracts;

namespace _03BarracksFactory.Core.Command
{
    public abstract class Command : IExecutable
    {
        private string[] data;

        protected Command(string[] data)
        {
            this.Data = data;
        }

        protected string[] Data { get => data; set => data = value; }

        public abstract string Execute();
    }
}
