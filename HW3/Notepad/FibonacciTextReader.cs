// <copyright file="FibonacciTextReader.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Notepad
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Eventing.Reader;
    using System.Linq;
    using System.Numerics;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Inherits from TextReader, generates as many integers
    /// as passed in for maxLines. Through its methods, will
    /// be able to implement it into notepad.
    /// </summary>
    public class FibonacciTextReader : TextReader
    {
        private BigInteger prev; // previous number that fibonacci generates.
        private BigInteger cur; // current number that fibonacci generates.
        private int maxLines; // what number we are going to.
        private int curLine; // index of current lines iterated through.

        /// <summary>
        /// Initializes a new instance of the <see cref="FibonacciTextReader"/> class.
        /// </summary>
        public FibonacciTextReader()
        {
            this.prev = 0;
            this.cur = 0;
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
            this.prev = 0;
            this.cur = 0;
        }

        /// <summary>
        /// Overloaded ReadLine() function. Generates next fibonacci number in sequence
        /// from the two previous numbers.
        /// </summary>
        /// <returns>
        /// String of current number in Fibonnaci sequence, or null.
        /// </returns>
        public override string? ReadLine()
        {
            this.curLine++; // increase current number of lines index.
            if (this.curLine <= this.maxLines) // only go to number specified in construction.
            {
                BigInteger next = this.cur + this.prev; // fibonacci is addition of two previous.
                if (this.curLine == 1) // this is for first special case.
                {
                    next = 0;
                }
                else if (this.curLine == 2) // second special case.
                {
                    next = 1;
                    this.cur = 1; // set this to one, to actually begin the algorithm.
                }
                else
                {
                    this.prev = this.cur; // prev is not cur.
                    this.cur = next; // cur is now next.
                }

                // Console.WriteLine(this.curLine.ToString() + ": " + next.ToString());
                return this.curLine.ToString() + ": " + next.ToString(); // to have the formatting that is in example.
            }
            else
            {
                return null; // we reached the end.
            }
        }

        /// <summary>
        /// Overloaded ReadToEnd() function. Calls overloaded ReadLine() maxLine number of times.
        /// </summary>
        /// <returns>
        /// Returns string of maxLine number of fibonacci sequence.
        /// </returns>
        public override string? ReadToEnd()
        {
            string curFib = "start"; // need to set this to something other than null for while to loop.
            string? result = null; // used a string instead of stringbuilder.
            while (curFib != null) // iterate until readline() returns null.
            {
                curFib = this.ReadLine(); // set curFib to return value of readline, which should be new fib number.
                if (curFib != null) // check if return is null.
                {
                    result += "\r\n" + curFib; // add current fib to return.
                }
            }

            return result; // return the string with concatened fib values in maxLines number.
        }
    }
}
