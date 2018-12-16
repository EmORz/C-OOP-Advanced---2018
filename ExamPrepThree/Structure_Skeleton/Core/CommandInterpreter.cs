using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;


public class CommandInterpreter : ICommandInterpreter
{
    public CommandInterpreter(IHarvesterController harvesterController, IProviderController providerController)
    {
        this.HarvesterController = harvesterController;
        this.ProviderController = providerController;
    }

    public IHarvesterController HarvesterController { get; private set; }

    public IProviderController ProviderController { get; private set; }

    public string ProcessCommand(IList<string> args)
    {
        ICommand command = this.CreateCommand(args);

        var result = command.Execute();
        return result;
    }

    private ICommand CreateCommand(IList<string> args)
    {
        string commandName = args[0];

        Type type = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(x => x.Name == commandName+"Command");

        if (type == null)
        {
            throw new ArgumentException(string.Format(Constants.CommandNotFound, commandName));
        }

        if (!typeof(ICommand).IsAssignableFrom(type))
        {
            throw new InvalidOperationException(string.Format(Constants.InvalidCommand, commandName));
        }

        ConstructorInfo ctor = type.GetConstructors().First();
        ParameterInfo[] parameterInfos = ctor.GetParameters();
        object[] parameters = new object[parameterInfos.Length];

        for (int i = 0; i < parameters.Length; i++)
        {
            Type paramTypes = parameterInfos[i].ParameterType;

            if (paramTypes == typeof(IList<string>))
            {
                parameters[i] = args.Skip(1).ToList();
            }
            else
            {
                var parameterInfo =
                    this.GetType().GetProperties().FirstOrDefault(x => x.PropertyType == paramTypes);
                parameters[i] = parameterInfo.GetValue(this);
            }

        }
        var instance = (ICommand)Activator.CreateInstance(type, parameters);

        return instance;


    }
}
