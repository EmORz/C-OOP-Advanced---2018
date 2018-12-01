 using System.Collections.Generic;
 using System.Linq;
 using System.Reflection;

namespace P01_HarvestingFields
{
    using System;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            //TODO put your reflection code here

            Type classType = typeof(HarvestingFields);

            var command = Console.ReadLine();

            while (command != "HARVEST")
            {

                IEnumerable<FieldInfo> fields = null;
                switch (command)
                {
                    case "private":
                        fields = GetPrivate(classType);
                        break;
                    case "protected":
                        fields = GetProtected(classType);
                        break;
                    case "public":
                        fields = GetPublic(classType);
                        break;
                    case "all":
                        fields = GetAll(classType);
                        break;
                }
                command = Console.ReadLine();
                foreach (var variable in fields)
                {
                    var accessModifier = "";
                    if (variable.IsPublic)
                    {
                        accessModifier = "public";
                    }

                    else if (variable.IsPrivate)
                    {
                        accessModifier = "private";
                    }
                    else
                    {
                        accessModifier = "protected";
                    }

                    Console.WriteLine($"{accessModifier} {variable.FieldType.Name} {variable.Name}");

                }
            }

            

        }

        private static IEnumerable<FieldInfo> GetAll(Type clasType)
        {
            return clasType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic|BindingFlags.Static);
        }

        private static IEnumerable<FieldInfo> GetPublic(Type clasType)
        {
            return clasType.GetFields(BindingFlags.Instance | BindingFlags.Public);
        }

        private static IEnumerable<FieldInfo> GetProtected(Type clasType)
        {
            return clasType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).Where(x => x.IsFamily);
        }

        private static IEnumerable<FieldInfo> GetPrivate(Type clasType)
        {
            return clasType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).Where(z => z.IsPrivate);
        }
    }
}
