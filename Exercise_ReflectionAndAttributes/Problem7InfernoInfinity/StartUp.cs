using System;
using Problem7InfernoInfinity.Contracts;
using Problem7InfernoInfinity.Core;
using Problem7InfernoInfinity.Core.Factories;
using Problem7InfernoInfinity.Data;

namespace Problem7InfernoInfinity
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var repository = new WeaponRepository();
            var interpreter = new CommandInterpreter();
            var weaponFactory = new WeaponFactory();
            var gemFactory = new GemFactory();

            IRunnable engine = new Engine(gemFactory, weaponFactory, interpreter, repository);
            engine.Run();
        }
    }
}
