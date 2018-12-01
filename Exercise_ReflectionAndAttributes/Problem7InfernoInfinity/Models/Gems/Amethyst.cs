using System;
using System.Collections.Generic;
using System.Text;
using Problem7InfernoInfinity.Models.Enum;

namespace Problem7InfernoInfinity.Models.Gems
{
    public class Amethyst : Gem
    {
        public Amethyst(GemClarity gemClarity) : base(gemClarity, 2, 8, 4)
        {
        }
    }
}
