using System;
using System.Collections.Generic;
using System.Text;
using Solid.Logger.Layouts.Contracts;

namespace Solid.Logger.Layouts.Factory.Contracts
{
    public interface ILayoutFactory
    {
        ILayout CreateLayout(string type);
    }
}
