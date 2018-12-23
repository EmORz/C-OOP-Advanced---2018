using System;

using System.Linq;
using System.Reflection;





namespace FestivalManager.Entities.Factories
{
    using Contracts;
    using Entities.Contracts;

    public class SetFactory : ISetFactory
	{
		public ISet CreateSet(string name, string type)
		{
		    Type typeN = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(x => x.Name == type);
		    ISet set = (ISet)Activator.CreateInstance(typeN, name);
			//if (type == "Short")
			//{
			//	return new Short(name);
			//}
			//else if (type == "Medium")
			//{
			//	return new Medium(name);
			//}
			//else if (type == "Long")
			//{
			//	return new Long(name);
			//}
		    return set;
		}
	}




}
