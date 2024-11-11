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
        private Cell cell;
        private string prevText;
        private string curText;

        public TextCommand(Cell cell, string prevText, string curText)
        {
            this.cell = cell;
            this.prevText = prevText;
            this.curText = curText;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Execute()
        {
            this.cell.Text = this.curText;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Unexecute()
        {
            this.cell.Text = this.prevText;

        }
    }
}

