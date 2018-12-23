using System;
using System.Linq;
using System.Reflection;
using Travel.Entities.Airplanes;

namespace Travel.Entities.Factories
{
	using Contracts;
	using Airplanes.Contracts;

	public class AirplaneFactory : IAirplaneFactory
	{
		public IAirplane CreateAirplane(string type)
		{
		    Type typeAir = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(x => x.Name == type);
		    var temp = (IAirplane)Activator.CreateInstance(typeAir);
            return temp;

            //switch (type)
            //{
            //	case "LightAirplane":
            //		return new LightAirplane();
            //	case "MediumAirplane":
            //		return new MediumAirplane();
            //	default:
            //		return null;
            //}
        }
	}
}