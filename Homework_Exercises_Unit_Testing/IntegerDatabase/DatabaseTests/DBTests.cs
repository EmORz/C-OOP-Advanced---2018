using System;
using System.Linq;
using System.Reflection;
using  Database;
using NUnit.Framework;

namespace DatabaseTests
{
    [TestFixture]
    public class DBTests
    {
        private const int ArraySize = 16;
        private const int InitialArr = -1;
        [Test]
        public void EmptyConstructorShouldInitData()
        {
            var db = new Database.Database();

            Type type = typeof(Database.Database);
            var field = (int[])type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(f => f.Name == "data")
                .GetValue(db);
            var lenght = field.Length;

            Assert.That(lenght, Is.EqualTo(ArraySize));
        }
        //
        [Test]
        public void EmptyConstructorShouldInitToMinusOne()
        {
            var db = new Database.Database();
            Type type = typeof(Database.Database);
            var indexValue = (int)type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(f => f.Name == "index")
                .GetValue(db);
            Assert.That(indexValue, Is.EqualTo(InitialArr));
        }
        //
        [Test]
        public void CtorShouldThrowInvalidOperationException()
        {
            int[] arr = new int[ArraySize+1];
            Assert.Throws<InvalidOperationException>(() => new Database.Database(arr));
        }

        [Test]
        [TestCase(new int[]{})]
        [TestCase(new int[]{13})]
        [TestCase(new int[]{13, 14, 15 })]
        [TestCase(new int[]{1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15,16 })]
        public void CtorShouldSetIndexCorrectly(int[] values)
        {
            var db = new Database.Database(values);
            int index = GetTypeAndIndex(db);
            var expected = values.Length - 1;
            Assert.That(index, Is.EqualTo(expected));
        }
        //
        [Test]
        [TestCase(new int[] {})]
        [TestCase(new int[] {1})]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15})]

        public void AddShouldIncreaceIndexCorrectly(int[] values)
        {

            var db = new Database.Database(values);
            db.Add(16);
            int index = GetTypeAndIndex(db);
            var expected = values.Length;

            Assert.That(index, Is.EqualTo(expected));
        }
        //
        [Test]
        public void AddWhenDBIsFullShouldThrowInvalidOperationException()
        {
            int[] arr = new int[16];
            var db = new Database.Database(arr);
            Assert.Throws<InvalidOperationException>(() => db.Add(1));
        }
        //
        [Test]
        public void RemoveCorrectly()
        {
            int[] arr = new int[10];
            var db = new Database.Database(arr);
            db.Removed();
            int index = GetTypeAndIndex(db);
            var expected = arr.Length-2;
            Assert.That(index, Is.EqualTo(expected));
        }
        //
        [Test]
        public void RemoveFromEmtyDBShoudThrowInvaiOE()
        {
            var db = new Database.Database();
            Assert.Throws<InvalidOperationException>(() => db.Removed());
        }

        //Methods
        private int GetTypeAndIndex(Database.Database db)
        {
            Type type = typeof(Database.Database);
            var index = (int)type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(f => f.Name == "index")
                .GetValue(db);
            return index;
        }
    }
}
