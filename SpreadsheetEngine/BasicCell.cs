// <copyright file="BasicCell.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// Emily Porter 011741612

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("SpreadsheetTests")]

namespace SpreadsheetEngine
{
    /// <summary>
    /// Inherits from Cell class, but can actually be instantiated. Should include setter for Value.
    /// </summary>
    public class BasicCell : Cell
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BasicCell"/> class.
        /// Constructor for Basic Cell.
        /// </summary>
        /// <param name="newRowIndex">
        /// Row index passed in from spreadsheet.
        /// </param>
        /// <param name="newColumnIndex">
        /// Column index passed in from spreadsheet.
        /// </param>
        public BasicCell(int newRowIndex, int newColumnIndex)
            : base(newRowIndex, newColumnIndex)
        {
        }
    }
}
