using TheTankGame.Entities.Miscellaneous;
using TheTankGame.Entities.Miscellaneous.Contracts;
using TheTankGame.Entities.Parts;
using TheTankGame.Entities.Parts.Contracts;
using TheTankGame.Entities.Vehicles;
using TheTankGame.Entities.Vehicles.Contracts;

namespace TheTankGame.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class BaseVehicleTests
    {
        [Test]
        public void TestBaseClassVehicle()
        {
            IAssembler assembler = new VehicleAssembler();
            IVehicle vehicle = new Vanguard("Vanguard", 100, 100, 50, 60, 25, assembler );
            IPart part0 = new ArsenalPart("Arsenal1", 150, 1500, 26);
            IPart part1 = new EndurancePart("Endurance", 150, 1500, 26);
            IPart part2 = new ShellPart("Shell", 150, 1500, 26);
            //
            vehicle.AddArsenalPart(part0);
            vehicle.AddEndurancePart(part1);
            vehicle.AddShellPart(part2);

            var totalAttack = vehicle.TotalAttack;
            var totalDefense = vehicle.TotalDefense;
            var totalHitPoints = vehicle.TotalHitPoints;
            var totalWeight = vehicle.TotalWeight;
            var totalPrice = vehicle.TotalPrice;

            Assert.AreEqual(totalAttack,76 );
            Assert.AreEqual(totalDefense,86 );
            Assert.AreEqual(totalHitPoints,51 );
            Assert.AreEqual(totalWeight,550 );
            Assert.AreEqual(totalPrice, 4600);
            //
            var expectedR = vehicle.ToString();
            var actualR =
                "Vanguard - Vanguard\r\nTotal Weight: 550.000\r\nTotal Price: 4600.000\r\nAttack: 76\r\nDefense: 86\r\nHitPoints: 51\r\nParts: Arsenal1, Endurance, Shell";

            Assert.AreEqual(actualR, expectedR);

        }
    }
}