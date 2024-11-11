// <copyright file="ICommand.cs" company="PlaceholderCompany">
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
    /// general command interface, TODO
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// to be overwritten by other command classes. Will use this for redo.
        /// </summary>
        void Execute();

        /// <summary>
        /// to be overwritten by other command classes. Will use this for undo.
        /// </summary>
        void Unexecute();
    }
}
