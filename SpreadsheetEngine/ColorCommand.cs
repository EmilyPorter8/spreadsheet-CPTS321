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
        private Cell cell;
        private uint prevColor;
        private uint curColor;

        public ColorCommand(Cell cell, uint prevColor, uint curColor)
        {
            this.cell = cell;
            this.prevColor = prevColor;
            this.curColor = curColor;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Execute()
        {
            this.cell.BGColor = this.curColor;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Unexecute()
        {
            this.cell.BGColor = this.prevColor;
        }
    }
}
