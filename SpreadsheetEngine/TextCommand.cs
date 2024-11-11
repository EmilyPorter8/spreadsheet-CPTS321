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
        /// 
        /// </summary>
        private Cell cell;

        /// <summary>
        /// 
        /// </summary>
        private string prevText;

        /// <summary>
        /// 
        /// </summary>
        private string curText;

        private string description;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cell"></param>
        /// <param name="prevText"></param>
        /// <param name="curText"></param>
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

