using NUnit.Framework;
using StorageMaster;
using StorageMaster.Entities.Products;
using StorageMaster.Entities.Storage;
using StorageMaster.Entities.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace StorageMaster.Tests.Structure
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
        //2
        [Test]
        public void ValidateAllChildClassStorage()
        {
            var derivateTypes = new[]
            {
                GetType("AutomatedWarehouse"),
                GetType("DistributionCenter"),
                GetType("Warehouse"),
            };
            foreach (var derivateType in derivateTypes)
            {
                Assert.That(derivateType.BaseType, Is.EqualTo(storage), $"{storage} doesn't inheritage");
            }
        }
        //3
        [Test]
        public void ValidateStorageConstructorNotNullAndParameters()
        {
            var flags = BindingFlags.NonPublic | BindingFlags.Instance;
            var construct = this.storage.GetConstructors(flags).FirstOrDefault();
            Assert.That(construct, Is.Not.Null);
            var constructParameters = construct.GetParameters();
            Assert.That(constructParameters[0].ParameterType, Is.EqualTo(typeof(string)));
            Assert.That(constructParameters[1].ParameterType, Is.EqualTo(typeof(int)));
            Assert.That(constructParameters[2].ParameterType, Is.EqualTo(typeof(int)));
            Assert.That(constructParameters[3].ParameterType, Is.EqualTo(typeof(IEnumerable<Vehicle>)));
        }
        //4
        [Test]
        public void ValidateStorageProperties()
        {
            var actualProperties = storage.GetProperties();

            var expectedProperties = new Dictionary<string, Type>();
            expectedProperties.Add("Name", typeof(string));
            expectedProperties.Add("Capacity", typeof(int));
            expectedProperties.Add("GarageSlots", typeof(int));
            expectedProperties.Add("IsFull", typeof(bool));
            expectedProperties.Add("Garage", typeof(IReadOnlyCollection<Vehicle>));
            expectedProperties.Add("Products", typeof(IReadOnlyCollection<Product>));

            foreach (var actualProperty in actualProperties)
            {
                var propertyExist = expectedProperties.Any(x => x.Key == actualProperty.Name && x.Value == actualProperty.PropertyType);
                Assert.That(propertyExist, $"{actualProperty.Name} doesn't exists!");
            }
        }
        //5
        [Test]
        public void ValidateAbstractClassStorage()
        {
            Assert.That(storage.IsAbstract, "Storage must be abstract class");
        }
        //6
        [Test]
        public void ValidateStorageFields()
        {
            var storageFields = storage.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (var storageField in storageFields)
            {
                Assert.That(storageField, Is.Not.Null, "Invalid field");
            }
        }
        //7
        [Test]
        public void ValidateStorageMethods()
        {
            var expectedMethods = new List<Method>
            {
                new Method(typeof(Vehicle), "GetVehicle", typeof(Vehicle)),
                new Method(typeof(int), "SendVehicleTo", typeof(int), typeof(Storage)),
                new Method(typeof(int), "UnloadVehicle", typeof(int))
            };
            var actualMethods = storage.GetMethods();

            foreach (var expectedMethod in expectedMethods)
            {
                var currentMethod = storage.GetMethod(expectedMethod.Name);
                Assert.That(currentMethod, Is.Not.Null);
                var currentMethodReturnType = expectedMethod.ReturnaType == currentMethod.ReturnType;
                Assert.That(currentMethodReturnType);

                //var expectedMethodParams = expectedMethod.InputParameters;
                //var actualParams = currentMethod.GetParameters();

                //for (int i = 0; i < expectedMethodParams.Length; i++)
                //{
                //    var actParam = actualParams[i];
                //    var expectParams = expectedMethodParams[i];
                //    Assert.AreEqual(expectParams, actParam);
                //}
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
        private class Method
        {
            public Method(Type returnaType, string name, params Type[] inputParameters)
            {
                this.ReturnaType = returnaType;
                this.Name = name;
                this.InputParameters = inputParameters;
            }

            public Type ReturnaType { get; set; }

            public string Name { get; set; }

            public Type[] InputParameters { get; set; }
        }
    }
}