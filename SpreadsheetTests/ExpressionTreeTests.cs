// <copyright file="ExpressionTreeTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// Emily Porter 011741612.

namespace SpreadsheetTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using NUnit.Framework;

    /// <summary>
    /// HW5 tests for expression tree.
    /// </summary>
    internal class ExpressionTreeTests
    {
        /// <summary>
        /// Just testing typical input without any variables.
        /// </summary>
        [Test]
        public void NormalConstantNodeEvaluateTest()
        {
            SpreadsheetEngine.ExpressionTree tree = new SpreadsheetEngine.ExpressionTree("1+2+3");
            Assert.That(tree.Evaluate(), Is.EqualTo(6));
        }

        /// <summary>
        /// Just testing typical input with only variables.
        /// </summary>
        [Test]
        public void NormalVariableNodeEvaluateTest()
        {
            SpreadsheetEngine.ExpressionTree tree = new SpreadsheetEngine.ExpressionTree("A1+B6+E41");
            tree.SetVariable("A1", 2);
            tree.SetVariable("B6", 3);
            tree.SetVariable("E41", 1);
            Assert.That(tree.Evaluate(), Is.EqualTo(6));
        }

        /// <summary>
        /// Just testing typical input with both kinds of variables.
        /// </summary>
        [Test]
        public void NormalMixNodeEvaluateTest()
        {
            SpreadsheetEngine.ExpressionTree tree = new SpreadsheetEngine.ExpressionTree("2+B6+E41");
            tree.SetVariable("B6", 3);
            tree.SetVariable("E41", 1);
            Assert.That(tree.Evaluate(), Is.EqualTo(6));
        }

        /// <summary>
        /// testing if dividing by zero actually results in positive infinity.
        /// </summary>
        [Test]
        public void BoundaryEvaluateTest()
        {
            SpreadsheetEngine.ExpressionTree tree = new SpreadsheetEngine.ExpressionTree("B6/0");
            tree.SetVariable("B6", 3);
            Assert.That(tree.Evaluate(), Is.EqualTo(double.PositiveInfinity));
        }

        /// <summary>
        /// Test if there is no variable definiton then it is converted to zero.
        /// </summary>
        [Test]
        public void ExceptionalEvaluateTest()
        {
            SpreadsheetEngine.ExpressionTree tree = new SpreadsheetEngine.ExpressionTree("B6/3");
            Assert.That(tree.Evaluate(), Is.EqualTo(0));
        }

        /// <summary>
        /// Normal test if tree results in correct result with multiple operators.
        /// </summary>
        [Test]
        public void NormalMultipleOperatorsTest1()
        {
            SpreadsheetEngine.ExpressionTree tree = new SpreadsheetEngine.ExpressionTree("9/3*4");
            Assert.That(tree.Evaluate(), Is.EqualTo(12));
        }

        /// <summary>
        /// Normal test if tree results in correct result with multiple operators of different precedence.
        /// </summary>
        [Test]
        public void NormalMultipleOperatorsTest2()
        {
            SpreadsheetEngine.ExpressionTree tree = new SpreadsheetEngine.ExpressionTree("9/3*4+5");
            Assert.That(tree.Evaluate(), Is.EqualTo(17));
        }

        /// <summary>
        /// Normal test if tree results in correct result with multiple operators, parentheses, and variables.
        /// </summary>
        [Test]
        public void NormalMultipleOperatorsTest3()
        {
            SpreadsheetEngine.ExpressionTree tree = new SpreadsheetEngine.ExpressionTree("(5-3)*(A5+20)");
            tree.SetVariable("A5", 3);
            Assert.That(tree.Evaluate(), Is.EqualTo(46));
        }

        /// <summary>
        /// Normal test if tree results in correct result with multiple operators, parentheses, and variables.
        /// </summary>
        [Test]
        public void NormalMultipleOperatorsTest4()
        {
            SpreadsheetEngine.ExpressionTree tree = new SpreadsheetEngine.ExpressionTree("(5-3)*A5");
            tree.SetVariable("A5", 3);
            Assert.That(tree.Evaluate(), Is.EqualTo(6));
        }

        /// <summary>
        /// Boundary test if tree results in correct result with many parentheses.
        /// </summary>
        [Test]
        public void BoundaryMultipleOperatorsTest()
        {
            SpreadsheetEngine.ExpressionTree tree = new SpreadsheetEngine.ExpressionTree("(((((2+3)))))");
            Assert.That(tree.Evaluate(), Is.EqualTo(5));
        }

        /// <summary>
        /// Exceptional test if tree results in correct result with incorrectly used multiple operators and tons of parentheses.
        /// </summary>
        [Test]
        public void ExceptionalMultipleOperatorsTest()
        {
            SpreadsheetEngine.ExpressionTree tree = new SpreadsheetEngine.ExpressionTree("(((((2+/3)))))");

            // TODO fix result
            Assert.That(tree.Evaluate(), Is.EqualTo(0));
        }

        /// <summary>
        /// Exceptional test if tree results correctly with odd number of parentheses.
        /// </summary>
        [Test]
        public void ExceptionalMultipleParenthesTest()
        {
            SpreadsheetEngine.ExpressionTree tree = new SpreadsheetEngine.ExpressionTree("(((((2+3)))");

            // TODO fix result
            Assert.That(tree.Evaluate(), Is.EqualTo(0));
        }
    }
}
