// <copyright file="OperatorNodeFactory.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// Emily Porter 011741612.

namespace SpreadsheetEngine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// class to create operator based on user inputted value.
    /// </summary>
    internal class OperatorNodeFactory
    {
        /// <summary>
        /// dictionary of operators that are available for user to use.
        /// </summary>
        private Dictionary<char, Type> operators = new Dictionary<char, Type>();

        /// <summary>
        /// Initializes a new instance of the <see cref="OperatorNodeFactory"/> class.
        /// </summary>
        public OperatorNodeFactory()
        {
            this.TraverseAvailableOperators((op, type) => this.operators.Add(op, type));
        }

        /// <summary>
        /// delegates of operators.
        /// </summary>
        /// <param name="op">
        /// character of operator.
        /// </param>
        /// <param name="type">
        /// type of operator.
        /// </param>
        private delegate void OnOperator(char op, Type type);

        /// <summary>
        /// factory for creating operator nodes depending on the type of operator.
        /// </summary>
        /// <param name="op">
        /// user inputteed operator symbol. Used to create specific operator type.
        /// </param>
        /// <returns>
        /// specific operator node.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// There is no operator that matches user inputted value.
        /// </exception>
        public OperatorNode CreateOperatorNode(char op)
        {
            if (this.operators.ContainsKey(op))
            {
                object operatorNodeObject = Activator.CreateInstance(this.operators[op]);
                if (operatorNodeObject is OperatorNode)
                {
                    return (OperatorNode)operatorNodeObject;
                }
            }

            throw new Exception("Unhandled operator");
        }

        /// <summary>
        /// USED CODE FROM CLASS SLIDES.
        /// Iterates through all types to see if there is an operatornode that matches with onOperator.
        /// </summary>
        /// <param name="onOperator">
        /// current operator in tree.
        /// </param>
        private void TraverseAvailableOperators(OnOperator onOperator)
        {
            // get the type declaration of OperatorNode
            Type operatorNodeType = typeof(OperatorNode);

            // Iterate over all loaded assemblies:
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                // Get all types that inherit from our OperatorNode class using LINQ
                IEnumerable<Type> operatorTypes =
                assembly.GetTypes().Where(type => type.IsSubclassOf(operatorNodeType));

                // Iterate over those subclasses of OperatorNode
                foreach (var type in operatorTypes)
                {
                    // for each subclass, retrieve the Operator property
                    PropertyInfo operatorField = type.GetProperty("Operator");

                    if (operatorField != null)
                    {
                        object value = operatorField.GetValue(Activator.CreateInstance(type));
                        if (value is char)
                        {
                            char operatorSymbol = (char)value;
                            onOperator(operatorSymbol, type);
                        }
                    }
                }
            }
        }
    }
}
