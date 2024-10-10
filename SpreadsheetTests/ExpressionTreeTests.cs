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
    }
}
