using System;
using _03BarracksFactory.Contracts;

namespace _03BarracksFactory.Core.Factories
{
    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            //TODO: implement for Problem 3
            Type classType= Type.GetType("_03BarracksFactory.Models.Units." + unitType);
            var newUnit = (IUnit) Activator.CreateInstance(classType);
            return newUnit;
        }
    }
}
