// <copyright file="Form1.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// Emily Porter 011741612

namespace Spreadsheet_Emily_Porter
{
    using System.ComponentModel;
    using System.Windows.Forms;
    using SpreadsheetEngine;

    /// <summary>
    /// winforms spreadsheet class definition.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// 
        /// </summary>
        private SpreadsheetEngine.Spreadsheet spreadsheet;

        /// <summary>
        /// 
        /// </summary>
        private SpreadsheetEngine.EditInvoker editInvoker;

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// Winforms spreadsheet application constructor.
        /// </summary>
        public Form1()
        {
            this.InitializeComponent();
            this.InitilizeDataGridView();
            this.spreadsheet = new SpreadsheetEngine.Spreadsheet(50, 26); // initilize spreadsheet to correct size for hw4.
            this.spreadsheet.CellPropertyChanged += this.SpreadsheetPropertyChanged; // subscribe UI spreadsheet to spreadsheet.
            this.editInvoker = new SpreadsheetEngine.EditInvoker();
            this.redoToolStripMenuItem.Enabled = false;
            this.undoToolStripMenuItem.Enabled = false;

        }

        /// <summary>
        /// Reacts to raised notification from spreadsheet class.
        /// </summary>
        /// <param name="sender">
        /// Cell that has changed.
        /// </param>
        /// <param name="e">
        /// Property of cell that has been changed.
        /// </param>
        private void SpreadsheetPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            Cell? cell = sender as Cell; // set cell to the cell that has just been changed.

            if (cell != null) // check if null.
            {
                if (e.PropertyName == "Value") // check what property has changed.
                {
                    this.dataGridView1.Rows[cell.RowIndex].Cells[cell.ColumnIndex].Value = cell.Value; // update text in datagridview cell.
                }
                else if (e.PropertyName == "BGColor")
                {
                    this.dataGridView1.Rows[cell.RowIndex].Cells[cell.ColumnIndex].Style.BackColor = Color.FromArgb((int)cell.BGColor); // update color in datagridview cell.
                }
            }
        }

        /// <summary>
        /// Used CellEndEdit becuase once finsihed editing datagridview cell, then update the actual spreadsheet cell.
        /// </summary>
        /// <param name="sender">
        /// I am assuming that sender is the datagridview.
        /// </param>
        /// <param name="e">
        /// the cell that has just been changed in the datagridview.
        /// </param>
        private void DataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Cell cell = this.spreadsheet.GetCell(e.RowIndex, e.ColumnIndex); // What is the cell we are going to update?
            if (cell != null)
            {
                string prevText = cell.Text;
                cell.Text = (string)this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value; // update text in spreadsheet cell.
                this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = cell.Value;
                string curText = cell.Text;
                TextCommand newText = new TextCommand(cell, prevText, curText);
                this.editInvoker.AddUndo(newText);
                this.undoToolStripMenuItem.Enabled = true;
            }
        }

        /// <summary>
        /// Used CellEndEdit becuase once finsihed editing datagridview cell, then update the actual spreadsheet cell.
        /// </summary>
        /// <param name="sender">
        /// I am assuming that sender is the datagridview.
        /// </param>
        /// <param name="e">
        /// the cell that has just been changed in the datagridview.
        /// </param>
        private void DataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            Cell cell = this.spreadsheet.GetCell(e.RowIndex, e.ColumnIndex); // What is the cell we are going to update?
            if (cell != null)
            {
                // cell.Text = (string)this.dataGridView1.Rows[cell.RowIndex].Cells[cell.ColumnIndex].; // update text in spreadsheet cell.
                this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = cell.Text;
            }
            else
            {
                this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = string.Empty;
            }
        }

        /// <summary>
        /// HW4 step 2 and 1: Initilizing the data grid view so it has alphabet columns and 50 rows.
        /// </summary>
        private void InitilizeDataGridView()
        {
            for (char c = 'A'; c <= 'Z'; c++) // iterate through alphabet, adding columns each time
            {
                string newheader = c.ToString(); // newheader is.
                this.dataGridView1.Columns.Add(newheader, newheader); // add column with corresponding character to column name.
            }

            for (int i = 0; i < 50; i++) // add 50 rows to the dataGridView1
            {
                this.dataGridView1.Rows.Add(); // add new row to datagridview.
                this.dataGridView1.Rows[i].HeaderCell.Value = (i + 1).ToString(); // name row that we just added.
            }
        }

        /// <summary>
        /// demo button for hw 4.
        /// </summary>
        /// <param name="sender">
        /// button.
        /// </param>
        /// <param name="e">
        /// not used.
        /// </param>
        private void Hw4demo_Click(object sender, EventArgs e)
        {
            // random text.
            var rand = new Random();
            for (int i = 0; i < 50; i++)
            {
                int rowIndex = rand.Next(50);
                int columnIndex = rand.Next(26);
                Cell cell = this.spreadsheet.GetCell(rowIndex, columnIndex);
                cell.Text = "potato";
            }

            // implement the B column text.
            for (int i = 0; i < 50; i++)
            {
                Cell cell = this.spreadsheet.GetCell(i, 1);
                cell.Text = "This is cell B" + (i + 1);
            }

            // implement the A colomn text.
            for (int i = 0; i < 50; i++)
            {
                int h = i + 1;
                string ha = "=B" + h;
                Cell cell = this.spreadsheet.GetCell(i, 0);
                cell.Text = ha;
            }
        }

        /// <summary>
        /// Upon click of menu item, change selected celll to chose colors in dialog.
        /// </summary>
        /// <param name="sender">
        /// menu strip.
        /// </param>
        /// <param name="e">
        /// e isnt really used in this function.
        /// </param>
        private void ChangeBackgroundColourToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            Cell[] cells = new Cell[this.dataGridView1.SelectedCells.Count];
            int index = 0;
            uint prevColor = 0;
            uint curColor = 0;

            if (dialog.ShowDialog() == DialogResult.OK) // get color.
            {
                foreach (DataGridViewCell curCell in this.dataGridView1.SelectedCells) // in case we have selected more than one cell, iterate through all celected cells.
                {
                    Cell cell = this.spreadsheet.GetCell(curCell.RowIndex, curCell.ColumnIndex); // grab the cell we are changing
                    if (cell != null)
                    {
                        prevColor = cell.BGColor;
                        cell.BGColor = (uint)dialog.Color.ToArgb(); // update cell color.
                        curColor = cell.BGColor;
                        cells[index] = cell;
                    }

                    ++index;
                }

                ColorCommand newColor = new ColorCommand(cells, prevColor, curColor);
                this.editInvoker.AddUndo(newColor);
                this.undoToolStripMenuItem.Enabled = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UndoButton_Click(object sender, EventArgs e)
        {
            this.editInvoker.UndoButtonPushed();
            if (this.editInvoker.UndoNull())
            {
                this.undoToolStripMenuItem.Enabled = false;
            }

            this.redoToolStripMenuItem.Enabled = true;
            this.undoToolStripMenuItem.Text = "Undo " + this.editInvoker.PeekUndo().Description;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RedoButton_Click(object sender, EventArgs e)
        {
            this.editInvoker.RedoButtonPushed();
            if (this.editInvoker.RedoNull())
            {
                this.redoToolStripMenuItem.Enabled = false;
            }

            this.redoToolStripMenuItem.Text = "Redo " + this.editInvoker.PeekRedo().Description;
        }
    }
}
