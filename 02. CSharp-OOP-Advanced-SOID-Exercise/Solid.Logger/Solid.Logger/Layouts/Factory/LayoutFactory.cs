using System;
using System.Collections.Generic;
using System.Text;
using Solid.Logger.Layouts.Contracts;
using Solid.Logger.Layouts.Factory.Contracts;

namespace Solid.Logger.Layouts.Factory
{
    public class LayoutFactory: ILayoutFactory
    {
        public ILayout CreateLayout(string type)
        {
            var asLowerCase = type.ToLower();

            switch (asLowerCase)
            {
                case "simplelayout":
                    return new SimpleLayout();
                case "xmllayout":
                    return new XmlLayout();
                default:
                    throw  new ArgumentException("Invalid layout type!");

            }
        }
    }
}
