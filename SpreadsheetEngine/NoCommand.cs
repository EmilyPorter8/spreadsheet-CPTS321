// <copyright file="NoCommand.cs" company="PlaceholderCompany">
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

    // Instantiates NoCommand code from class to instantiate an empty command.
    internal class NoCommand : ICommand
    {
        /// <summary>
        /// empty execute function.
        /// </summary>
        public void Execute()
        {
        }

        /// <summary>
        /// empty unexecute function.
        /// </summary>
        public void Unexecute()
        {
        }
    }
}
