// <copyright file="VariableNode.cs" company="PlaceholderCompany">
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
    /// Inherited from Node class, this is Node representing variable.
    /// </summary>
    internal class VariableNode : Node
    {
        private string value;

        /// <summary>
        /// Initializes a new instance of the <see cref="VariableNode"/> class.
        /// Constructor inherited from Node. It converts object to string for variable name.
        /// </summary>
        /// <param name="value">
        /// the variable name.
        /// </param>
        public VariableNode(string value)
            : base(value)
        {
            this.value = value.ToString();
        }

        /// <summary>
        /// Overrrides Node evaluate function. This checks to see if this.value variable is present in the dictionary.
        /// If so, it will return corresponding value. Else it will just return 0.
        /// </summary>
        /// <param name="variables">
        /// user inputted variables.
        /// </param>
        /// <returns>
        /// Returns corresponding value if key is present in dictionary, else returns 0.
        /// </returns>
        public override double Evaluate(Dictionary<string, double> variables)
        {
            if (variables.TryGetValue(this.value, out double result)) // try and get value from dictionary.
            {
                return result; // key is present, so return corresponding value.
            }
            else
            {
                return 0; // key isnt present, return 0.
            }
        }
    }
}
