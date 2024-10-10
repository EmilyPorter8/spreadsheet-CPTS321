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
    internal class OperatorNode : Node
    {
        private char value;
        private Node left;
        private Node right;

        /// <summary>
        /// Initializes a new instance of the <see cref="OperatorNode"/> class.
        /// Constructor inherited from Node. It converts object to character for operator.
        /// </summary>
        /// <param name="value">
        /// the operator.
        /// </param>
        public OperatorNode(object value)
            : base(value)
        {
            this.value = (char)value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OperatorNode"/> class.
        /// Constructor inherited from Node. It converts object to character for operator.
        /// </summary>
        /// <param name="value">
        /// the operator.
        /// </param>
        /// <param name="newLeft">
        /// the new left child node.
        /// </param>
        /// <param name="newRight">
        /// the new right child node.
        /// </param>
        public OperatorNode(object value, Node newLeft, Node newRight)
            : base(value)
        {
            this.value = (char)value;
            this.left = newLeft;
            this.right = newRight;
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
