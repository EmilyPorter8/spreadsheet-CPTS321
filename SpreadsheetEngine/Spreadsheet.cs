// <copyright file="Spreadsheet.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// Emily Porter 011741612

namespace SpreadsheetEngine
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Spreadsheet class, will hold 2d array of BasicCells. This is also where we will evaluate cell operations.
    /// </summary>
    public class Spreadsheet
    {
        private BasicCell[][] spreadsheet;
        private int rowCount;
        private int columnCount;

        /// <summary>
        /// Gets rowCount.
        /// </summary>
        public int RowCount
        {
            get => this.rowCount;
        }

        /// <summary>
        /// Gets column count. Property that will return columnCount data member.
        /// </summary>
        public int ColumnCount
        { get => this.columnCount; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Spreadsheet"/> class.
        /// It will be a 2d array of RowSize and Column size. Iterate through array and instantiate BasicCell.
        /// </summary>
        /// <param name="rowSize">
        /// Number of rows in spreadsheet.
        /// </param>
        /// <param name="columnSize">
        /// Number of columns in spreadsheet.
        /// </param>
        public Spreadsheet(int rowSize, int columnSize)
        {
            this.rowCount = rowSize;
            this.columnCount = columnSize;
            if (rowSize > 0 && columnSize > 0)
            {
                for (int rowIndex = 0; rowIndex < rowSize; rowIndex++)
                {
                    for (int columnIndex = 0; columnIndex < columnSize; columnIndex++)
                    {
                        this.spreadsheet[rowIndex][columnIndex] = new BasicCell(rowIndex, columnIndex); // rowIndex and columnIndex will start at 0, while rowSize and columnSize will start at 1.
                    }
                }
            }
            else
            {
                this.spreadsheet = null;
            }
        }

        /// <summary>
        /// This is the list of subsribers that will be notified when cell is changed.
        /// </summary>
        public event PropertyChangedEventHandler CellPropertyChanged = delegate { };

        /// <summary>
        /// Skeleton code for GetCell().
        /// </summary>
        /// <param name="rowIndex">
        /// rowIndex is the row that cell we are returning is located.
        /// </param>
        /// <param name="columnIndex">
        /// columnIndex is the column that cell we are returning is located.
        /// </param>
        /// <returns>
        /// Will return reference to cell at that location.
        /// </returns>
        public Cell GetCell(int rowIndex, int columnIndex)
        {
            Cell cell = new BasicCell(rowIndex, columnIndex);
            return cell;
        }
    }
}
