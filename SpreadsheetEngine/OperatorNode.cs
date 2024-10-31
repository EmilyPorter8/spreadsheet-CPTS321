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
        /// <summary>
        /// left child of this node.
        /// </summary>
        private Node left;

        /// <summary>
        /// right child of this node.
        /// </summary>
        private Node right;

        /// <summary>
        /// should be inherited and assigned in child class.
        /// </summary>
        private int precedence;

        /// <summary>
        /// left or right, set by child class.
        /// </summary>
        private string association;

        /// <summary>
        /// Initializes a new instance of the <see cref="OperatorNode"/> class.
        /// Constructor inherited from Node. It converts object to character for operator.
        /// </summary>
        /// <param name="value">
        /// the operator.
        /// </param>
        /// <param name="precedence">
        /// the level of precedence of a operator.
        /// </param>
        /// <param name="association">
        /// the association of the operator.
        /// </param>
        public OperatorNode(string value, int precedence, string association)
            : base(value)
        {
            this.precedence = precedence;
            this.left = null;
            this.right = null;
            this.association = association;
            this.Operator = value[0];
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

        public char Operator
        { get;
            set;
        }

        /// <summary>
        /// Gets precedence data member.
        /// </summary>
        public int Precedence
        { get => this.precedence; }

        /// <summary>
        /// Gets association data member.
        /// </summary>
        public string Association
        { get => this.association; }
    }
}
