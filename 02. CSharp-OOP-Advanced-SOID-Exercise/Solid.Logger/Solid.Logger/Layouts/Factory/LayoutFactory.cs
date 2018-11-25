

namespace Solid.Logger.Layouts.Factory
{
    using Contracts;
    using Solid.Logger.Layouts.Contracts;
    using System;

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
