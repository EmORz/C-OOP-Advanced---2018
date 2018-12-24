namespace CosmosX.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class ModuleContainerTests
    {
        [Test]
        public void TestModuleContainerFirst()
        {
            int modulCapacity = 8;
            IContainer container = new ModuleContainer(modulCapacity);
            IReactor reactorCryo = new CryoReactor(1, container, modulCapacity);
            IReactor reactorHeat = new CryoReactor(2, container, modulCapacity);
            IEnergyModule energyModule = new CryogenRod(1, 100);
            IEnergyModule energy = new CryogenRod(2, 100);
            container.AddEnergyModule(energyModule);
            container.AddEnergyModule(energy);

            var res = container.ModulesByInput.Count;

            Assert.That(res, Is.EqualTo(2));





        }
    }
}