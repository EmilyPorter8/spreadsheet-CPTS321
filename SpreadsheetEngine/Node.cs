// <copyright file="Node.cs" company="PlaceholderCompany">
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
    /// Abstract base class for rest of node types to inherit from.
    /// </summary>
    public abstract class Node
    {
        private object value;

        /// <summary>
        /// Initializes a new instance of the <see cref="Node"/> class.
        /// </summary>
        /// <param name="value">
        /// The value of the node we are constructing. For example, for operator node, value could be  '+'.
        /// </param>
        public Node(object value)
        {
            this.value = value;
        }
    }
}
