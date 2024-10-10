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
        public VariableNode(object value)
            : base(value)
        {
            this.value = value.ToString();
        }
    }
}
