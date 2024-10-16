// <copyright file="OperatorNodeFactory.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// Emily Porter 011741612.

namespace SpreadsheetEngine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// class to create operator based on user inputted value.
    /// </summary>
    internal class OperatorNodeFactory
    {
        /// <summary>
        /// factory for creating operator nodes depending on the type of operatoor.
        /// </summary>
        /// <param name="value">
        /// user inputteed operator symbol. Used to create specific operator type.
        /// </param>
        /// <returns>
        /// specific operator node.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// There is no operator that matches user inputted value.
        /// </exception>
        public OperatorNode CreateOperatorNode(char value)
        {
            // what operator are we using.
            switch (value)
            {
                case '+':
                    return new AdditionOperatorNode();
                case '-':
                    return new SubtractionOperatorNode();
                case '*':
                    return new MultiplicationOperatorNode();
                case '/':
                    return new DivisionOperatorNode();
                default:
                    Console.WriteLine("\nUnavailable operator entered.");
                    throw new NotImplementedException(); // software just autocorrected gave this to me. // TODO change
            }
        }
    }
}
