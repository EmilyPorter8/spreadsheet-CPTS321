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
        public event PropertyChangedEventHandler CellPropertyChanged = (sender, e) => { };

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
            if (rowIndex < this.rowCount && columnIndex < this.columnCount && rowIndex >= 0 && columnIndex >= 0) // make sure cell is in spreadsheet range.
            {
                Cell cell = this.spreadsheet[rowIndex, columnIndex];
                return cell; // returning refrence to cell.
            }
            else
            {
                return null; // cell is outside of range.
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
            // bool finishColumnRead = false;
            // will add future implementation of operators here.
            if (curCell.Text.Length >= 3 && curCell.Text[0] == '=')
            {
                // only the initilization to cell ID
                int columnIndex = curCell.Text[1] - 'A'; // to convert A to 0.convert user input of example 3 to 2.

                string rowIndexString = curCell.Text.Substring(2);
                if (int.TryParse(rowIndexString, out int rowIndex)) // test to see if we can even convert to int, if we can, assign to rowIndex
                {
                    rowIndex = rowIndex - 1; // if the user input is =A1, what they really want is 0,0
                    if (this.GetCell(rowIndex, columnIndex) != null)
                    {
                        curCell.Value = this.GetCell(rowIndex, columnIndex).Value;
                    }
                    else
                    {
                        curCell.Value = "!ERROR!"; // row and column index are out of range, so error.
                    }
                }
                else
                {
                    curCell.Value = "!ERROR!"; // row index doesnt fit format, so error.
                }
            }
            else
            {
                // call future implementations of evaluate if too small?
                curCell.Value = "!ERROR!"; // incorrect size of input after =.
            }
        }

        /// <summary>
        /// Gets spreadsheet. Used during testing.
        /// </summary>
        /// <returns>
        /// Method that will return spreadsheet data member.
        /// </returns>
        internal Cell[,] GetSpreadsheet()
        {
            return this.spreadsheet;
        }

        /// <summary>
        /// Initialise the spreadsheet for given row and column size. Also subscribe spreadsheet to each cell.
        /// </summary>
        private void InitializeSpreadsheet()
        {
            // valid input?
            if (this.rowCount > 0 && this.columnCount > 0)
            {
                this.spreadsheet = new BasicCell[this.rowCount, this.columnCount]; // iniitilize size of spreadsheet.

                for (int rowIndex = 0; rowIndex < this.rowCount; rowIndex++)
                {
                    for (int columnIndex = 0; columnIndex < this.columnCount; columnIndex++)
                    {
                        // rowIndex and columnIndex will start at 0, while rowSize and columnSize will start at 1.
                        this.spreadsheet[rowIndex, columnIndex] = new BasicCell(rowIndex, columnIndex);
                        this.spreadsheet[rowIndex, columnIndex].PropertyChanged += this.SpreadsheetPropertyChanged; // subscribe spreadsheet to cell's properties.
                    }
                }
            }
            else // if user passes in invalid row or column counts
            {
                this.spreadsheet = null;
                this.rowCount = 0;
                this.columnCount = 0;
            }
        }

        /// <summary>
        /// Reacts to raised notification from cell class. It will raise its own notificaiton to its subscribers in the UI.
        /// </summary>
        /// <param name="sender">
        /// cell that was changed.
        /// </param>
        /// <param name="e">
        /// property that was changed.
        /// </param>
        private void SpreadsheetPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Cell curCell = sender as Cell; // caste sender as a cell.

            if (curCell.Text[0] == '=') // check if text needs to be evaluated.
            {
                this.Evaluate(curCell); // if text needs to be evaluated, call function.
            }
            else
            {
                curCell.Value = curCell.Text; // text isnt function, so just set value as cell content.
            }

            this.CellPropertyChanged?.Invoke(curCell, e); // raise notificaiton to subscribers that spreadsheet changed.
        }
    }
}
