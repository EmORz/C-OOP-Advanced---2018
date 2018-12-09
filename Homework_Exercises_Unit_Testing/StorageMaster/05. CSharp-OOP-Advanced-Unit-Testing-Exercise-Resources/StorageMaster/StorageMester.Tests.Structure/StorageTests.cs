using System;
using System.Linq;
using NUnit.Framework;
using StorageMaster;

namespace StorageMester.Tests.Structure
{
    public class StorageTests
    {
        private Type storage;

        [SetUp]
        public void SetUp()
        {
            this.storage = this.GetType("Storage");
        }
        //1
        [Test]
        public void ValidateAllStorage()
        {
            var storageArr = new[]
            {
                "AutomatedWarehouse",
                "Storage",
                "Warehouse",
                "DistributionCenter"
            };

            foreach (var storage in storageArr)
            {
                var currentType = GetType(storage);
                Assert.That(currentType.Name, Is.EqualTo(storage));
            }
        }
        //Private methods
        private Type GetType(string type)
        {
            var targetsType = typeof(StartUp)
                .Assembly
                .GetTypes()
                .FirstOrDefault(x => x.Name == type);
            return targetsType;
        }
    }
}