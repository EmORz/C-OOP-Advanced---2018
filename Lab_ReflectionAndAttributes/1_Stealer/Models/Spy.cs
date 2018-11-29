using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string RevealPrivateMethods(string className)
    {
        StringBuilder sb = new StringBuilder();
        Type classType = Type.GetType(className);
        MethodInfo[] classInfo = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
        sb.AppendLine($"All Private Methods of Class: {className}");
        sb.AppendLine($"Base Class: {classType.BaseType.Name}");
        foreach (var methodInfo in classInfo)
        {
            sb.AppendLine(methodInfo.Name);
        }
        var result = sb.ToString().Trim();
        return result;
    }
    public string StealFieldInfo(string investigateClass, params string[] requestedFields)
    {
        Type classType = Type.GetType(investigateClass);

        FieldInfo[] classInfo = classType.GetFields
        (
                BindingFlags.Instance |
                BindingFlags.NonPublic |
                BindingFlags.Static |
                BindingFlags.Public
         );

        StringBuilder sb = new StringBuilder();

        Object classInstance = Activator.CreateInstance(classType, new object[] { });

        sb.AppendLine($"Class under investigation: {investigateClass}");

        foreach (var field in classInfo.Where(f => requestedFields.Contains(f.Name)))
        {
            var result = $"{field.Name} = {field.GetValue(classInstance)}";
            sb.AppendLine(result);
        }

        return sb.ToString().Trim();
    }

    public string AnalyzeAcessModifiers(string investigateClass)
    {
        Type classType = Type.GetType(investigateClass);

        FieldInfo[] classField = classType.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
        MethodInfo[] classPublic = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
        MethodInfo[] classNonPublic = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        StringBuilder sb = new StringBuilder();

        foreach (var field in classField)
        {
            sb.AppendLine($"{field.Name} must be private!");
        }
        foreach (var methodInfo in classNonPublic.Where(x => x.Name.StartsWith("get")))
        {
            sb.AppendLine($"{methodInfo.Name} have to be public!");
        }
        foreach (var methodInfo in classPublic.Where(x => x.Name.StartsWith("set")))
        {
            sb.AppendLine($"{methodInfo.Name} have to be private!");
        }
        return sb.ToString().Trim();
    }
}
