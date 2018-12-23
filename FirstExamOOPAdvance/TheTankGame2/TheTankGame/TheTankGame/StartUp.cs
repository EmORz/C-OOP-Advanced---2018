using TheTankGame.Entities.Parts.Factories;
using TheTankGame.Entities.Parts.Factories.Contracts;
using TheTankGame.Entities.Vehicles.Factories;
using TheTankGame.Entities.Vehicles.Factories.Contracts;

namespace TheTankGame
{
    using Core;
    using Core.Contracts;
    using IO;
    using IO.Contracts;

    public class StartUp
    {
        public static void Main()
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IVehicleFactory vehicleFactory = new VehicleFactory();
            IBattleOperator battleOperator = new TankBattleOperator();
            IPartFactory partFactory = new PartFactory();
            IManager manager = new TankManager(battleOperator, vehicleFactory, partFactory);

            ICommandInterpreter commandInterpreter = new CommandInterpreter(manager);

            IEngine engine = new Engine(
                reader,
                writer,
                commandInterpreter);

            engine.Run();
        }
    }
}
