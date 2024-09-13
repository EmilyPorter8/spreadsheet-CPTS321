// Emily Porter
// 011741612

using Form1;

namespace HW2Test
{
// using NUnit.Framework;

    /// <summary>
    /// RandomTest class to test all methods in RandomList class.
    /// </summary>
    [TestFixture]
    public class RandomTest
    {
        /// <summary>
        /// Attribute that will contain the list that we will be testing the methods on.
        /// </summary>
        private RandomList testList;

        /// <summary>
        /// Instantiates testList as a RandomList. Will use to test constructors.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.testList = new RandomList();
        }

        /// <summary>
        /// Test to see if RandomList constructor actually works.
        /// </summary>
        [Test]
        public void TestConstructionInstantiated()
        {
            Assert.That(this.testList, Is.Not.Null);
        }

        /// <summary>
        /// Test if list created is of correct size.
        /// </summary>
        [Test]
        public void TestConstructionSize()
        {
            Assert.That(this.testList.GetList().Count, Is.EqualTo(10001));
        }

        /// <summary>
        /// Normal Test if HashSetDistinct() will correctly determine # of distinct integers.
        /// </summary>
        [Test]
        public void TestNormalHashSetDistinct()
        {
            List<int> newList = [1, 1, 2, 2, 2, 5, 6, 123, 102, 99, 98, 3, 4];
            this.testList.SetList(newList);

            // list has ten distinct integers
            Assert.That(this.testList.HashSetDistinct(), Is.EqualTo(10));
        }

        /// <summary>
        /// Boundary test to see if program responds normally.
        /// </summary>
        [Test]
        public void TestBoundaryHashSetDistinct()
        {
            List<int> newList = [];
            this.testList.SetList(newList);

            // list has ten distinct integers
            Assert.That(this.testList.HashSetDistinct(), Is.EqualTo(0));
        }

        /// <summary>
        /// Normal Test if O1StorageDistinct() will correctly determine # of distinct integers.
        /// </summary>
        [Test]
        public void TestNormalO1Distinct()
        {
            List<int> newList = [1, 1, 2, 2, 2, 5, 6, 123, 102, 99, 98, 3, 4];
            this.testList.SetList(newList);

            // list has ten distinct integers
            Assert.That(this.testList.O1StorageDistinct(), Is.EqualTo(10));
        }

        /// <summary>
        /// Boundary test to see if program responds normally.
        /// </summary>
        [Test]
        public void TestBoundaryO1Distinct()
        {
            List<int> newList = [];
            this.testList.SetList(newList);

            // list has ten distinct integers
            Assert.That(this.testList.O1StorageDistinct(), Is.EqualTo(0));
        }

        /// <summary>
        /// Normal Test if SortedDistinct() will correctly determine # of distinct integers.
        /// </summary>
        [Test]
        public void TestNormalSortedDistinct()
        {
            List<int> newList = [1, 1, 2, 2, 2, 5, 6, 123, 102, 99, 98, 3, 4];
            this.testList.SetList(newList);

            // list has ten distinct integers
            Assert.That(this.testList.SortedDistinct(), Is.EqualTo(10));
        }

        /// <summary>
        /// Boundary test to see if program responds normally.
        /// </summary>
        [Test]
        public void TestBoundarySortedDistinct()
        {
            List<int> newList = [];
            this.testList.SetList(newList);

            // list has ten distinct integers
            Assert.That(this.testList.SortedDistinct(), Is.EqualTo(0));
        }
    }
}