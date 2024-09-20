using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Notepad
{
    /// <summary>
    /// Inherits from TextReader, generates as many integers
    /// as passed in for maxLines. Through its methods, will
    /// be able to implement it into notepad.
    /// </summary>
    public class FibonacciTextReader : TextReader
    {
        private BigInteger prev;
        private BigInteger cur;
        private int maxLines;
        private int curLine;

        /// <summary>
        /// Initializes a new instance of the <see cref="FibonacciTextReader"/> class.
        /// </summary>
        public FibonacciTextReader()
        {
            this.prev = -1;
            this.cur = -1;
            this.maxLines = 0;
            this.curLine = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FibonacciTextReader"/> class.
        /// </summary>
        /// <param name="maxLines">
        /// Number of lines of fibonnaci.
        /// </param>
        public FibonacciTextReader(int maxLines)
        {
            this.maxLines = maxLines;
            this.curLine = 0;
            this.prev = -1;
            this.cur = -1;
        }

        /// <summary>
        /// Overloaded ReadLine() function. Generates next fibonacci number in sequence
        /// from the two previous numbers.
        /// </summary>
        /// <returns>
        /// String of current number in Fibonnaci sequence, or null.
        /// </returns>
        private string ReadLine()
        { return " "; }


        //ReadToEnd()
        //{ }
    }
}
