using System;
using System.Collections.Generic;
using System.Text;

namespace Problem7InfernoInfinity.Contracts
{
    public interface IGemFactory
    {
        IGem GreateGem(string clarity, string gemType);
    }
}
