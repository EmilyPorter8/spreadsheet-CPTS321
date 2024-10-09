// <copyright file="Spreadsheet.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// Emily Porter 011741612
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("SpreadsheetTests")]

namespace SpreadsheetEngine
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Spreadsheet class, will hold 2d array of BasicCells. This is also where we will evaluate cell operations.
    /// </summary>
    public class Spreadsheet
    {
        // private BasicCell[][] spreadsheet;
        private Cell[,] spreadsheet;
        private int rowCount;
        private int columnCount;

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
            this.InitializeSpreadsheet();
        }

        /// <summary>
        /// This is the list of subscribers that will be notified when cell is changed.
        /// </summary>
        public event PropertyChangedEventHandler CellPropertyChanged = delegate { };

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
        /// Returns refrence to cell given at rowindex and column index. If the cell is out of spreadsheet bounds, returns null.
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
            if (rowIndex < this.rowCount && columnIndex < this.columnCount && rowIndex >= 0 && columnIndex >= 0)
            {
                // Cell cell = new BasicCell(rowIndex, columnIndex);
                Cell cell = this.spreadsheet[rowIndex, columnIndex];
                return cell;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// takes current cell, cehcks if the cell text is the right size. Then, convert user
        /// input to correct interger indexes, if it is =(letter)(int) format. From there,
        /// take value from named cell and set it to current cell.
        /// </summary>
        /// <param name="curCell">
        /// cell that has text to be evaluated, to have new value.
        /// </param>
        internal void Evaluate(Cell curCell)
        {
            // will add future implementation of operators here.
            if (curCell.Text.Length == 3)
            {
                // only the initilization to cell ID
                int rowIndex = curCell.Text[1] - 'A'; // to convert A to 0.
                int columnIndex = curCell.Text[2] - '0' - 1; // convert user input of example 3 to 2.
                if (this.GetCell(rowIndex, columnIndex) != null)
                {
                    curCell.Value = this.GetCell(rowIndex, columnIndex).Value;
                }
                else
                {
                    curCell.Value = "!ERROR!";
                }
            }
            else
            {
                // call future implementations of evaluate if too long?
                curCell.Value = "!ERROR!";
            }
        }

        /// <summary>
        /// Gets spreadsheet.
        /// </summary>
        /// <returns>
        /// Method that will return spreadsheet data member.
        /// </returns>
        internal Cell[,] GetSpreadsheet()
        {
            return this.spreadsheet;
        }

        private void InitializeSpreadsheet()
        {
            if (this.rowCount > 0 && this.columnCount > 0)
            {
                this.spreadsheet = new BasicCell[this.rowCount, this.columnCount];

                for (int rowIndex = 0; rowIndex < this.rowCount; rowIndex++)
                {
                    for (int columnIndex = 0; columnIndex < this.columnCount; columnIndex++)
                    {
                        // rowIndex and columnIndex will start at 0, while rowSize and columnSize will start at 1.
                        this.spreadsheet[rowIndex, columnIndex] = new BasicCell(rowIndex, columnIndex);
                        this.CellPropertyChanged += this.SpreadsheetPropertyChanged;
                    }
                }
            }
            else
            {
                this.spreadsheet = null;
                this.rowCount = 0;
                this.columnCount = 0;
            }
        }

        private void SpreadsheetPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Cell curCell = sender as BasicCell;

            // this.UpdateValue(curCell);
            if (curCell.Text[0] == '=')
            {
                this.Evaluate(curCell);
            }
            else
            {
                curCell.Value = curCell.Text;
            }

            // this.CellPropertyChanged.Invoke(curCell, e);
        }
    }
}
