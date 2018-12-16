namespace FestivalManager.Entities.Factories
{
    using Contracts;
    using Entities.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class InstrumentFactory : IInstrumentFactory
	{
		public IInstrument CreateInstrument(string typeName)
		{
		    var type = Assembly.GetCallingAssembly()
		        .GetTypes()
		        .FirstOrDefault(x => x.Name == typeName);

		    IInstrument instrument = (IInstrument)Activator.CreateInstance(type);
		    return instrument;
        }
	}
}