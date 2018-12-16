namespace FestivalManager.Entities.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;
    using Entities.Contracts;

    public class SetFactory : ISetFactory
	{
		public ISet CreateSet(string name, string typeName)
		{
		    var type = Assembly.GetCallingAssembly()
		        .GetTypes()
		        .FirstOrDefault(x => x.Name == typeName);

		    ISet set = (ISet)Activator.CreateInstance(type, name);
		    return set;
        }
	}
}
