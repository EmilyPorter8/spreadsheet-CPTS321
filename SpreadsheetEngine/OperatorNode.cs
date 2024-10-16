// <copyright file="OperatorNode.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// Emily Porter 011741612.

namespace SpreadsheetEngine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.AccessControl;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Binary operator node, always has two children.
    /// Ex: + , - , *, / .
    /// </summary>
    internal abstract class OperatorNode : Node
    {
        private Node left;
        private Node right;

        /// <summary>
        /// Initializes a new instance of the <see cref="OperatorNode"/> class.
        /// Constructor inherited from Node. It converts object to character for operator.
        /// </summary>
        /// <param name="value">
        /// the operator.
        /// </param>
        public OperatorNode(string value)
            : base(value)
        {
            this.left = null;
            this.right = null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OperatorNode"/> class.
        /// Constructor inherited from Node. It converts object to character for operator.
        /// </summary>
        public OperatorNode()
        {
            this.left = null;
            this.right = null;
        }

        /// <summary>
        /// Gets or sets left child node of operator node.
        /// </summary>
        public Node Left
        {
            get => this.left;
            set => this.left = value;
        }

        /// <summary>
        /// Gets or sets right child node of operator node.
        /// </summary>
        public Node Right
        {
            get => this.right;
            set => this.right = value;
        }
    }
}
