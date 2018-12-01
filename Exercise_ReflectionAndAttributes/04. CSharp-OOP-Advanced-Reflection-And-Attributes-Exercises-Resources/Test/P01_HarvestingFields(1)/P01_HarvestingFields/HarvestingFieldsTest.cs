 using System.Collections;
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

            string command = Console.ReadLine();

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

                foreach (var fieldInfo in fields)
                {
                    var access = "";
                    if (fieldInfo.IsPublic)
                    {
                        access = "public";
                    }
                    if (fieldInfo.IsPrivate)
                    {
                        access = "private";

                    }
                    if (fieldInfo.IsFamily)
                    {
                        access = "protected";

                    }

                    Console.WriteLine($"{access} {fieldInfo.FieldType.Name} {fieldInfo.Name}");
                }



                command = Console.ReadLine();
            }
        }

        private static IEnumerable<FieldInfo> GetProtected(Type classType)
        {
            return classType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).Where(p => p.IsFamily);
        }

        private static IEnumerable<FieldInfo> GetPublic(Type classType)
        {
            return classType.GetFields(BindingFlags.Instance | BindingFlags.Public);
        }

        private static IEnumerable<FieldInfo> GetAll(Type classType)
        {
            return classType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public |
                                       BindingFlags.Static);
        }

        private static IEnumerable<FieldInfo> GetPrivate(Type classType)
        {
            return classType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).Where(x => x.IsPrivate);
        }
    }
}
