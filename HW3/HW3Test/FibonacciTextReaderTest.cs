using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3Test
{
    using System.ComponentModel;
    using Notepad;

    /// <summary>
    /// Testing FibonacciTextReader methods.
    /// </summary>
    [TestFixture]
    public class FibonacciTextReaderTest
    {
        /// <summary>
        /// Probably will leave empty.
        /// </summary>
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// Normal test of ReadLine() generating first string.
        /// </summary>
        [Test]
        public void TestNormalFirstReadLine()
        {
            FibonacciTextReader fibonacciTextReader = new FibonacciTextReader(3);
            Assert.That(fibonacciTextReader.ReadLine(), Is.EqualTo("1: 0"));
        }

        /// <summary>
        /// Normal test of ReadLine() generating string between first and end.
        /// </summary>
        [Test]
        public void TestNormalMiddleReadLine()
        {
            FibonacciTextReader fibonacciTextReader = new FibonacciTextReader(3);
            fibonacciTextReader.ReadLine();
            Assert.That(fibonacciTextReader.ReadLine(), Is.EqualTo("2: 1"));
        }

        /// <summary>
        /// Normal test of ReadLine() generating string at end.
        /// </summary>
        [Test]
        public void TestNormalEndReadLine()
        {
            FibonacciTextReader fibonacciTextReader = new FibonacciTextReader(3);
            fibonacciTextReader.ReadLine();
            fibonacciTextReader.ReadLine();
            fibonacciTextReader.ReadLine();
            Assert.That(fibonacciTextReader.ReadLine(), Is.EqualTo(null));
        }

        /// <summary>
        /// Exception test of ReadLine() with bad arguement.
        /// </summary>
        [Test]
        public void TestExceptionReadLine()
        {
            FibonacciTextReader fibonacciTextReader = new FibonacciTextReader(-222222);

            // throw exception.
            //Assert.Throws<>(Type );
            Assert.That(fibonacciTextReader.ReadLine(), Is.EqualTo(null));
        }

        /// <summary>
        /// Boundary test of ReadLine() generating string if input is 0.
        /// </summary>
        [Test]
        public void TestBoundryReadLine()
        {
            FibonacciTextReader fibonacciTextReader = new FibonacciTextReader(0);
            fibonacciTextReader.ReadLine();
            Assert.That(fibonacciTextReader.ReadLine(), Is.EqualTo(null));
        }

    }
}
