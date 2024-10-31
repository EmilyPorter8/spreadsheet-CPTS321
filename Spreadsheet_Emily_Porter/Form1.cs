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
        private SpreadsheetEngine.Spreadsheet spreadsheet;

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

            if (cell != null && e.PropertyName == "Value") // check what property has changed.
            {
                this.dataGridView1.Rows[cell.RowIndex].Cells[cell.ColumnIndex].Value = cell.Value; // update text in datagridview cell.
            }

            //if (cell != null && e.PropertyName == "Text") // this is not necassary
            //{
            //    cell.Text = (string)this.dataGridView1.Rows[cell.RowIndex].Cells[cell.ColumnIndex].Value; // update text in spreadsheet cell.
            //}
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
                cell.Text = (string)this.dataGridView1.Rows[cell.RowIndex].Cells[cell.ColumnIndex].Value; // update text in spreadsheet cell.
            }
            else
            {
                cell.Text = string.Empty;
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
                //cell.Text = (string)this.dataGridView1.Rows[cell.RowIndex].Cells[cell.ColumnIndex].; // update text in spreadsheet cell.
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

        //private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{

        //}
    }
}
