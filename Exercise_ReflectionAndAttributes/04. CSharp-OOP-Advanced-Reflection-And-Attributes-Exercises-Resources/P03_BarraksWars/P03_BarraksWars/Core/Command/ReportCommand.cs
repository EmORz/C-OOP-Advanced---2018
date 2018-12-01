using _03BarracksFactory.Contracts;

namespace _03BarracksFactory.Core.Command
{
    public class ReportCommand: _03BarracksFactory.Core.Command.Command
    {
        public ReportCommand(string[] data, IRepository repository, IUnitFactory unitFactory) : base(data, repository, unitFactory)
        {
        }

        public override string Execute()
        {
            string output = this.Repository.Statistics;
            return output;
        }
    }
}
