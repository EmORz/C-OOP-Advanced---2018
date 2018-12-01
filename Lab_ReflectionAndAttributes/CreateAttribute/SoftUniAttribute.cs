using System;


[AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
public class SoftUniAttribute : Attribute
{
    private string name;

    public SoftUniAttribute(string name)
    {
        this.Name = name;
    }

    public string Name { get; set; }
}
