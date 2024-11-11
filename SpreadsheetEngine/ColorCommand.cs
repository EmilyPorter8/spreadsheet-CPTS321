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
        /// 
        /// </summary>
        private Cell[] cells;

        /// <summary>
        /// 
        /// </summary>
        private uint prevColor;

        /// <summary>
        /// 
        /// </summary>
        private uint curColor;

        /// <summary>
        /// 
        /// </summary>
        private readonly string description;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cell"></param>
        /// <param name="prevColor"></param>
        /// <param name="curColor"></param>
        public ColorCommand(Cell[] cell, uint prevColor, uint curColor)
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
        /// 
        /// </summary>
        public void Execute()
        {
            foreach (var cell in this.cells)
            {
                cell.BGColor = this.curColor;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Unexecute()
        {
            foreach (var cell in this.cells)
            {
                cell.BGColor = this.prevColor;
            }
        }
    }
}
