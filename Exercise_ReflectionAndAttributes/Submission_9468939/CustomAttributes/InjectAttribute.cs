using System;

namespace _03BarracksFactory.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class InjectAttribute: Attribute
    {
    }
}
