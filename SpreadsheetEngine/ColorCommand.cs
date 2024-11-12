// <copyright file="ColorCommand.cs" company="PlaceholderCompany">
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
    public class ColorCommand : ICommand
    {
        /// <summary>
        /// button text description.
        /// </summary>
        private readonly string description;

        /// <summary>
        /// cells whoes color was changed.
        /// </summary>
        private Cell[] cells;

        /// <summary>
        /// the previous color of the cell.
        /// </summary>
        private uint[] prevColor;

        /// <summary>
        /// the current color of the cell.
        /// </summary>
        private uint[] curColor;

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorCommand"/> class.
        /// </summary>
        /// <param name="cell">
        /// cell that is being updated.
        /// </param>
        /// <param name="prevColor">
        /// what the color was before we changed it.
        /// </param>
        /// <param name="curColor">
        /// the current color of the cell.
        /// </param>
        public ColorCommand(Cell[] cell, uint[] prevColor, uint[] curColor)
        {
            this.cells = cell;
            this.prevColor = prevColor;
            this.curColor = curColor;
            this.description = "changing cell background colour";
        }

        /// <summary>
        /// Gets description attribute.
        /// </summary>
        public string Description
        { get => this.description; }

        /// <summary>
        /// when we redo, set color back to cur color for each cell.
        /// </summary>
        public void Execute()
        {
            int index = 0;
            foreach (var cell in this.cells)
            {
                cell.BGColor = this.curColor[index];
                index++;
            }
        }

        /// <summary>
        /// when we undo, set color to prev color for each cell.
        /// </summary>
        public void Unexecute()
        {
            int index = 0;
            foreach (var cell in this.cells)
            {
                cell.BGColor = this.prevColor[index];
                index++;
            }
        }
    }
}
