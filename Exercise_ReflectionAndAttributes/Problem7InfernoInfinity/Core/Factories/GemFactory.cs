using Problem7InfernoInfinity.Contracts;
using Problem7InfernoInfinity.Models.Enum;
using System;

namespace Problem7InfernoInfinity.Core.Factories
{
    public class GemFactory: IGemFactory
    {
        public IGem GreateGem(string clarity, string gemType)
        {
            var gemClarity = (GemClarity)Enum.Parse(typeof(GemClarity), clarity);

            Type classType = Type.GetType(gemType);

            var instance = (IGem)Activator.CreateInstance(classType, new object[] { gemClarity});
            return instance;
        }
    }
}
