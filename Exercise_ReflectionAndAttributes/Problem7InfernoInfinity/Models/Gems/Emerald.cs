using System;
using System.Collections.Generic;
using System.Text;
using Problem7InfernoInfinity.Models.Enum;

namespace Problem7InfernoInfinity.Models.Gems
{
    public class Emerald : Gem
    {
        public Emerald(GemClarity gemClarity) : base(gemClarity, 1, 4, 9)
        {
        }
    }
}
