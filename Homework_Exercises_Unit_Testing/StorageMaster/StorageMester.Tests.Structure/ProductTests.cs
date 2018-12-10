using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;
using StorageMaster;

namespace StorageMaster.Tests.Structure
{
    public class ProductTests
    {
        private Type product;

        [SetUp]
        public void SetUp()
        {
            this.product = this.GetType("Product");
        }
        //1
        [Test]
        public void ValidateAllProduct()
        {
            var types = new[]
            {
                "Gpu",
                "HardDrive",
                "Product",
                "Ram",
                "SolidStateDrive"
            };
            foreach (var type in types)
            {
                var currentType = GetType(type);
                Assert.That(currentType.Name, Is.EqualTo(type), $"{type} doesn't exists");
            }
        }
        //2
        [Test]
        public void ValidateAllChildClassProducts()
        {
            var derivateTypes = new[]
            {
                GetType("Gpu"),
                GetType("HardDrive"),
                GetType("Ram"),
                GetType("SolidStateDrive")
            };
            foreach (var derivateType in derivateTypes)
            {
                    Assert.That(derivateType.BaseType, Is.EqualTo(product), $"{product} doesn't inheritage");
            }
        }
        //3
        [Test]
        public void ValidateProductConstructorNotNullAndParameters()
        {
            var flags = BindingFlags.NonPublic | BindingFlags.Instance;
            var construct = this.product.GetConstructors(flags).FirstOrDefault();
            Assert.That(construct, Is.Not.Null);
            var constructParameters = construct.GetParameters();
            Assert.That(constructParameters[0].ParameterType, Is.EqualTo(typeof(double)));
            Assert.That(constructParameters[1].ParameterType, Is.EqualTo(typeof(double)));
        }
        //4
        [Test]
        public void ValidateProductProperties()
        {
            var testProp = product.GetProperties();
            var expectedProperties = new Dictionary<string, Type>();
            expectedProperties.Add("Price", typeof(double));
            expectedProperties.Add("Weight", typeof(double));

            foreach (var tetsPropertyInfo in testProp)
            {
                var validationData = expectedProperties.Any(x =>
                    x.Key == tetsPropertyInfo.Name && x.Value == tetsPropertyInfo.PropertyType);
            }

        }
        //5
        [Test]
        public void ValidateAbstractClassProduct()
        {
            Assert.That(product.IsAbstract, "Product must be abstract class");
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