// <copyright file="TextCommand.cs" company="PlaceholderCompany">
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
    /// cell color changed, so add command.
    /// </summary>
    public class TextCommand : ICommand
    {
        /// <summary>
        /// button text description.
        /// </summary>
        private readonly string description;

        /// <summary>
        /// cell whoes text was changed.
        /// </summary>
        private Cell cell;

        /// <summary>
        /// the previous text of the cell.
        /// </summary>
        private string prevText;

        /// <summary>
        /// the current text of the cell.
        /// </summary>
        private string curText;

        /// <summary>
        /// Initializes a new instance of the <see cref="TextCommand"/> class.
        /// </summary>
        /// <param name="cell">
        /// cell that is being updated.
        /// </param>
        /// <param name="prevText">
        /// what the text was before we changed it.
        /// </param>
        /// <param name="curText">
        /// the current text of the cell.
        /// </param>
        public TextCommand(Cell cell, string prevText, string curText)
        {
            this.cell = cell;
            this.prevText = prevText;
            this.curText = curText;
            this.description = "changing cell text";
        }

        /// <summary>
        /// Gets description attribute.
        /// </summary>
        public string Description
        { get => this.description; }

        /// <summary>
        /// when we redo, set text back to cur text.
        /// </summary>
        public void Execute()
        {
            this.cell.Text = this.curText;
        }

        /// <summary>
        /// when we undo, set text to prev text.
        /// </summary>
        public void Unexecute()
        {
            this.cell.Text = this.prevText;
        }
    }
}