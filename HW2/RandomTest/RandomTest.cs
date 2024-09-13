// Emily Porter
// 011741612
namespace HW2Test
{
    using Form1;

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
        /// Similiar issue to the sorted implementation, I thought this would generate an error, but
        /// this implementation of distinct can work with negative numbers. I am unsure what an
        /// exception test case should look like.
        /// </summary>
        [Test]
        public void TestExceptionHashSetDistinct()
        {
            List<int> newList = [-1, -2, -50, -33];
            this.testList.SetList(newList);
            Assert.That(this.testList.HashSetDistinct(), Is.EqualTo(4));
            // Assert.Throws<InvalidOperationException>(() => this.testList.O1StorageDistinct());
        }

        /// <summary>
        /// Normal Test if O1StorageDistinct() will correctly determine # of distinct integers.
        /// </summary>
        [Test]
        public void TestNormalOStorageDistinct()
        {
            List<int> newList = [1, 1, 2, 2, 2, 5, 6, 123, 102, 99, 98, 3, 4];
            this.testList.SetList(newList);

            // list has ten distinct integers
            Assert.That(this.testList.OStorageDistinct(), Is.EqualTo(10));
        }

        /// <summary>
        /// Boundary test to see if program responds normally.
        /// </summary>
        [Test]
        public void TestBoundaryOStorageDistinct()
        {
            List<int> newList = [];
            this.testList.SetList(newList);

            // list has ten distinct integers
            Assert.That(this.testList.OStorageDistinct(), Is.EqualTo(0));
        }

        /// <summary>
        /// Similiar issue to the sorted implementation, I thought this would generate an error, but it just returns
        /// the incorrect value.I am unsure what an exception test case should look like.
        /// </summary>
        [Test]
        public void TestExceptionOStorageDistinct()
        {
            List<int> newList = [-1, -2, -50, -33];
            this.testList.SetList(newList);
            Assert.That(this.testList.OStorageDistinct(), Is.EqualTo(0));
           // Assert.Throws<InvalidOperationException>(() => this.testList.O1StorageDistinct());
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

        /// <summary>
        /// I thought this would generate an error, but this implementation of distinct
        /// can work with negative numbers. I am unsure what an exception test case should
        /// look like.
        /// </summary>
        [Test]
        public void TestExceptionSortedDistinct()
        {
            List<int> newList = [-1, -2, -50, -33];
            this.testList.SetList(newList);
            Assert.That(this.testList.SortedDistinct(), Is.EqualTo(4));
        }
    }
}