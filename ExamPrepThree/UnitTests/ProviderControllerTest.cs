using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace UnitTests
{
    public class ProviderControllerTest
    {
        private EnergyRepository energyRepository;
        private ProviderController providerController;


        [SetUp]
        public void SetUp()
        {
            this.energyRepository = new EnergyRepository();
            this.providerController = new ProviderController(energyRepository);
        }

        [Test]
        public void ProduceCorrectAmountOfEnergy()
        {
            List<string> provider1 = new List<string>
            {
                "Solar", "1", "100"
            };

            List<string> provider2 = new List<string>
            {
                "Solar", "2", "100"
            };

            this.providerController.Register(provider1);
            this.providerController.Register(provider2);


            for (int i = 0; i < 3; i++)
            {
                providerController.Produce();
            }

            Assert.AreEqual(this.providerController.TotalEnergyProduced, 600);

        }


        [Test]
        public void ProduceCorrectAmountOfEnergy2()
        {
            List<string> provider1 = new List<string>
            {
                "Solar", "1", "100"
            };

            List<string> provider2 = new List<string>
            {
                "Solar", "2", "100"
            };

            this.providerController.Register(provider1);
            this.providerController.Register(provider2);

            var expect = this.providerController.Produce();

            Assert.AreEqual(expect, "Produced 200 energy today!");

        }


        [Test]
        public void ProduceCorrectAmountOfEnergy3()
        {
            List<string> provider1 = new List<string>
            {
                "Pressure", "1", "100"
            };


            this.providerController.Register(provider1);
            for (int i = 0; i < 8; i++)
            {
                this.providerController.Produce();
            }
            var expect = this.providerController.Entities.Count;

            Assert.AreEqual(expect, 0);

        }
    }
}
