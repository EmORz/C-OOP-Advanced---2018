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
        public void TestOfBaseVehicleClass()
        {
            IAssembler assembler = new VehicleAssembler();
            IVehicle vehicle = new Vanguard("VanguardS", 150, 15000, 150, 300, 525, assembler);
            IPart arsenalPart = new ArsenalPart("ArsenalYo", 100, 123, 321);
            IPart shellPart = new ShellPart("ShellYo", 100, 123, 321);
            IPart endurancePart = new EndurancePart("EmduranceYo", 100, 123, 321);

            vehicle.AddArsenalPart(arsenalPart);
            vehicle.AddShellPart(shellPart);
            vehicle.AddEndurancePart(endurancePart);

            var totalWeight = vehicle.TotalWeight;
            var totalHitPoints = vehicle.TotalHitPoints;
            var totalAttack = vehicle.TotalAttack;
            var totalDefense = vehicle.TotalDefense;
            var totalPrice = vehicle.TotalPrice;
          
            Assert.AreEqual(totalWeight, 450);
            Assert.AreEqual(totalHitPoints, 846);
            Assert.AreEqual(totalAttack, 471);
            Assert.AreEqual(totalPrice, 15369);
            Assert.AreEqual(totalDefense, 621);


            var actualResult = vehicle.ToString();
            var expectedResult = "Vanguard - VanguardS\r\nTotal Weight: 450.000\r\nTotal Price: 15369.000\r\nAttack: 471\r\nDefense: 621\r\nHitPoints: 846\r\nParts: ArsenalYo, ShellYo, EmduranceYo";

            Assert.AreEqual(actualResult, expectedResult);

        }
    }
}