﻿// <copyright file="EditInvoker.cs" company="PlaceholderCompany">
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
    /// Executes or unexecutes changes in the spreadsheet.
    /// </summary>
    public class EditInvoker
    {
        /// <summary>
        /// collection of executed commands.
        /// </summary>
        private Stack<ICommand> undoCommands;

        /// <summary>
        /// collection of undoed commands.
        /// </summary>
        private Stack<ICommand> redoCommands;

        /// <summary>
        /// Initializes a new instance of the <see cref="EditInvoker"/> class.
        /// Constructs EditInvoker.
        /// </summary>
        public EditInvoker()
        {
            this.undoCommands = new Stack<ICommand>();
            this.redoCommands = new Stack<ICommand>();
        }

        /// <summary>
        /// This should be called everytime something changes in the spreadsheet.
        /// </summary>
        /// <param name="newCommand">
        /// the action that just changed the spreadsheet.
        /// </param>
        public void AddUndo(ICommand newCommand)
        {
            this.undoCommands.Push(newCommand);
        }

        /// <summary>
        /// This should be called everytime undo button is pushed. This unexecutes the top of the undoCommand stack.
        /// </summary>
        public void UndoButtonPushed()
        {
            ICommand undoCommand = this.undoCommands.Pop();
            undoCommand.Unexecute();
            this.AddRedo(undoCommand);
        }

        /// <summary>
        /// add command once undo button is clicked.
        /// </summary>
        /// <param name="newCommand">
        /// the command that was just undone
        /// </param>
        public void AddRedo(ICommand newCommand)
        {
            this.redoCommands.Push(newCommand);
        }

        /// <summary>
        /// This should be called everytime redo button is pushed. This executes the top of the redoCommand stack.
        /// </summary>
        public void RedoButtonPushed()
        {
            ICommand redoCommand = this.redoCommands.Pop();
            redoCommand.Execute();
            this.AddRedo(redoCommand);
        }

        /// <summary>
        /// This should be called everytime redo button is pushed. This executes the top of the redoCommand stack.
        /// </summary>
        public void RedoNull()
        {
            if (redoCommands.Count == 0)
            { }
        }
    }
}
