using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;
using StorageMaster;
using StorageMaster.Entities.Products;
using StorageMaster.Entities.Storage;

namespace StorageMester.BusinessLogic.Tests
{
    [TestFixture]
    public class StorageMasterTests
    {
        private Type storageMaster;

        [SetUp]
        public void SetUp()
        {
            this.storageMaster = this.GetType("StorageMaster");
        }

        [Test]
        public void ValidateSendVehicleToMethod()
        {
           
            var registerStorageMethod = storageMaster.GetMethod("RegisterStorage");
            var instance = Activator.CreateInstance(storageMaster);

            var firstStorageType = "DistributionCenter";
            var firstName = "Gosho";

            var secondStorageType = "AutomatedWarehouse";
            var secondName = "Pesho";

            registerStorageMethod.Invoke(instance, new object[] { firstStorageType, firstName });
            registerStorageMethod.Invoke(instance, new object[] { secondStorageType, secondName });

            var actualResult = storageMaster.GetMethod("SendVehicleTo")
                .Invoke(instance, new object[] {"Gosho", 1, "Pesho"});

            var expectedResult = "Sent Van to Pesho (slot 1)";
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }
   
        [Test]
        public void ValidateRegisterStorageMethod()
        {
            var registerStorageMethod = storageMaster.GetMethod("RegisterStorage");
            var instance = Activator.CreateInstance(storageMaster);

            var storageType = "DistributionCenter";
            var name = "Gosho";
            var result = registerStorageMethod.Invoke(instance, new object[]{storageType, name});
            var expectedResult = $"Registered {name}";
            Assert.AreEqual(result, expectedResult);

            var storageRegistry = (IDictionary<string, Storage>)storageMaster.GetField("storageRegistry", (BindingFlags)62).GetValue(instance);

            Assert.That(storageRegistry[name].Name, Is.EqualTo(name));
        }
        [Test]
        public void ValidateAddProduct()
        {
            var addProductMethod = storageMaster.GetMethod("AddProduct");

            var instance = Activator.CreateInstance(storageMaster);

            string productType = "SolidStateDrive";
            double price = 230.4;
            var actualResult = addProductMethod.Invoke(instance, new object[] { productType, price });

            var expectedResult = $"Added SolidStateDrive to pool";

            Assert.AreEqual(actualResult, expectedResult);
            var productsPoolField = (IDictionary<string, Stack<Product>>)storageMaster.GetField("productsPool", (BindingFlags)62).GetValue(instance);

            Assert.That(productsPoolField[productType].Count, Is.EqualTo(1));
        }
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
