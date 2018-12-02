using _03BarracksFactory.Contracts;

namespace _03BarracksFactory.Core.Command
{
    public abstract class Command : IExecutable
    {
        private string[] data;
        private IRepository repository;
        private IUnitFactory unitFactory;

        protected Command(string[] data, IRepository repository, IUnitFactory unitFactory)
        {
            this.Data = data;
            this.Repository = repository;
            this.UnitFactory = unitFactory;
        }

        protected string[] Data { get => data; set => data = value; }
        protected IRepository Repository { get => repository; set => repository = value; }
        protected IUnitFactory UnitFactory { get => unitFactory; set => unitFactory = value; }

        public abstract string Execute();
    }
}
