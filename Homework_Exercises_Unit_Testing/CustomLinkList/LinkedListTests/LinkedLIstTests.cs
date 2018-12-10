using System;
using CustomLinkedList;
using NUnit.Framework;

namespace LinkedListTests
{
    [TestFixture]
    public class LinkedLIstTests
    {
        private const int InitialCount = 0;
        private DynamicList<int> sut;

        [SetUp]
        public void TestInit()
        {
            this.sut = new DynamicList<int>();
        }
        [Test]
        public void CtorShouldSetCountToZero()
        {
            Assert.That(sut.Count, Is.EqualTo(InitialCount));
        }
        //
        [Test]
        public void IndexOperatorShouldReturnValue()
        {
            sut.Add(10);
            Assert.That(sut[0], Is.EqualTo(10));
        }
        //
        [Test]
        public void IndexOperatorShouldSetValue()
        {
            sut.Add(10);
            sut[0] = 11;
            Assert.That(sut[0], Is.EqualTo(11));
        }
        //
        [Test]
        [TestCase(-1)]
        [TestCase(int.MaxValue)]
        public void IndexOperatorSholdThrowExceptionWnehGetingInvaidIndex(int index)
        {
            FillWihtDataList(this.sut);
            var returnValue = 0;
            Assert.Throws<ArgumentOutOfRangeException>(() => returnValue = sut[index]);
        }
        //
        [Test]
        public void CannotCallElementWithIndexAboveTheRange()
        {
            var incorrectIndex = 1;
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                {
                    var test = this.sut[incorrectIndex];
                }
                , "Provided index is greater than the range of the collection");
        }
        //
        [Test]
        [TestCase(3, 1)]
        [TestCase(10, 1)]
        [TestCase(10, 0)]
        [TestCase(10, 7)]
        public void RemoveShouldDeleteElement(int numAdd, int numRemove)
        {
            //Arrange
            this.AddElements(numAdd);
            //Act
            this.sut.Remove(numRemove);
            //Assert
            Assert.That(-1, Is.EqualTo(this.sut.IndexOf(numRemove)));
        }
        //
        [Test]
        [TestCase(-1)]
        [TestCase(int.MaxValue)]
        public void IndexOperatorSholdThrowExceptionWnehSetingInvaidIndex(int index)
        {
            var list = DynamicList();
            FillWihtDataList(list);
            Assert.Throws<ArgumentOutOfRangeException>(() => list[index] = 69);
        }

        [Test]
        [TestCase(3, 1)]
        [TestCase(5, 4)]
        [TestCase(10, 7)]
        public void RemoveShouldReturnTheIndexOfTheRemovedElement(int numberOfAdditions, int elementToRemove)
        {
            // Arrange 
            this.AddElements(numberOfAdditions);
            var expectedIndex = elementToRemove;

            // Act
            var returnedIndex = this.sut.Remove(elementToRemove);

            // Assert
            Assert.AreEqual(expectedIndex, returnedIndex, "Remove returns wrong index");
        }
        [Test]
        [TestCase(3, 3)]
        [TestCase(3, -1)]
        [TestCase(3, 10)]
        public void RemoveUnexistentEelementShouldReturnNegativeInteger(int numberOfAdditions, int elementToRemove)
        {
            // Arrange
            this.AddElements(numberOfAdditions);

            // Act
            var isRemovingResultLesThanZero = this.sut.Remove(elementToRemove) < 0;

            // Assert
            Assert.IsTrue(isRemovingResultLesThanZero, "Attempting to remove an unexistent element returns positive integer");
        }

        [Test]
        [TestCase(3, 1)]
        [TestCase(5, 4)]
        [TestCase(10, 7)]
        public void ShouldReturnTrueIfElementExists(int numToAdd, int keyElement)
        {
            this.AddElements(numToAdd);

            Assert.IsTrue(this.sut.Contains(keyElement), "Contains returns false for existing element");
        }
        [Test]
        [TestCase(3, 3)]
        [TestCase(5, 6)]
        [TestCase(10, 159)]
        public void ShouldReturnFalseIfElementDoesNotExists(int numToAdd, int keyElement)
        {
            this.AddElements(numToAdd);

            Assert.IsFalse(this.sut.Contains(keyElement), "Contains returns true for element that doesnt existing");
        }
        //Methods
        private DynamicList<int> DynamicList()
        {
            DynamicList<int> list = new DynamicList<int>();
            return list;
        }
        private void FillWihtDataList(DynamicList<int> list)
        {
            for (int i = 0; i < 100; i++)
            {
                list.Add(i);
            }
        }
        private void AddElements(int numberOfAdditions)
        {
            for (int i = 0; i < numberOfAdditions; i++)
            {
                this.sut.Add(i);
            }
        }

    }
}
