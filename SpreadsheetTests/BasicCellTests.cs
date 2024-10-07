namespace SpreadsheetTests
{
    using NUnit.Framework;

    public class Tests
    {
        private SpreadsheetEngine.BasicCell test;

        [SetUp]
        public void Setup()
        {
           this.test = new SpreadsheetEngine.BasicCell(8, 3);

        }

        /// <summary>
        /// Just testing to see if constructor actually constructs something.
        /// </summary>
        [Test]
        public void NormalConstructorTest()
        {
            Assert.IsNotNull(this.test);
        }


        /// <summary>
        /// Testing RowIndex getter, if it returns correct value.
        /// </summary>
        [Test]
        public void NormalRowIndexGetterTest()
        {
            Assert.That(this.test.RowIndex, Is.EqualTo(8));
        }

        /// <summary>
        /// Testing ColumnIndex getter, if it returns correct value.
        /// </summary>
        [Test]
        public void NormalColumnIndexGetterTest()
        {
            Assert.That(this.test.ColumnIndex, Is.EqualTo(3));
        }
    }
}