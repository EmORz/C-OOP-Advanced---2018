using System;
using System.Collections.Generic;
using System.Text;
using Problem7InfernoInfinity.Models.Enum;

namespace Problem7InfernoInfinity.Models.Gems
{
    public class Ruby : Gem
    {
        public Ruby(GemClarity gemClarity) : base(gemClarity, 7, 2, 5)
        {
        }
    }
}
