using System;
using System.Linq;
using System.Reflection;
using Travel.Entities.Airplanes.Contracts;

namespace Travel.Entities.Factories
{
	using Contracts;
	using Items;
	using Items.Contracts;

	public class ItemFactory : IItemFactory
	{
		public IItem CreateItem(string type)
		{
		    Type typeAir = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(x => x.Name == type);
		    var temp = (IItem)Activator.CreateInstance(typeAir);
		    return temp;

   //         switch (type)
			//{
			//	case "CellPhone":
			//		return new CellPhone();
			//	case "Colombian":
			//		return new Colombian();
			//	case "Jewelery":
			//		return new Jewelery();
			//	case "Laptop":
			//		return new Laptop();
			//	case "Toothbrush":
			//		return new Toothbrush();
			//	case "TravelKit":
			//		return new TravelKit();
			//	default:
			//		return null;
			//}
		}
	}
}
