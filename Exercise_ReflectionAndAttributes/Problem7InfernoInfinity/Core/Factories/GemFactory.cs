using System;

public class GemFactory : IGemFactory
{
    public IGem GreateGem(string clarity, string gemType)
    {
        var gemClarity = (GemClarity)Enum.Parse(typeof(GemClarity), clarity);

        Type classType = Type.GetType(gemType);

        var instance = (IGem)Activator.CreateInstance(classType, new object[] { gemClarity });
        return instance;
    }
}

