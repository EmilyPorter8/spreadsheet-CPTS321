// <copyright file="BasicCellTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// Emily Porter 011741612

namespace SpreadsheetTests
{
    using NUnit.Framework;

    /// <summary>
    /// Tests for Internal BasicCell. Mostly just testing methods from abstract Cell.
    /// </summary>
    public class BasicCellTests
    {
        private SpreadsheetEngine.BasicCell test;

        /// <summary>
        /// Constructing/initilizing a BasicCell to use for tests.
        /// </summary>
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