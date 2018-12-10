using System;
using _03BarracksFactory.Contracts;
using _03BarracksFactory.CustomAttributes;

namespace _03BarracksFactory.Core.Command
{
    public class RetireCommand : Command
    {
        [Inject]
        private IRepository repository;

        public RetireCommand(string[] data) : base(data)
        {
          
        }

        public override string Execute()
        {
            var temp = Data[1];

            try
            {
                this.repository.RemoveUnit(temp);
                return $"{temp} retired!";
            }
            catch (ArgumentException e)
            {
                return e.Message;
            }
        }
    }
}
