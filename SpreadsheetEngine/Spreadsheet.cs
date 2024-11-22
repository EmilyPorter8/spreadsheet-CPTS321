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
    using System.IO;
    using System.Linq;
    using System.Runtime;
    using System.Runtime.ExceptionServices;
    using System.Runtime.Remoting.Messaging;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;

    /// <summary>
    /// Spreadsheet class, will hold 2d array of BasicCells. This is also where we will evaluate cell operations.
    /// </summary>
    public class Spreadsheet
    {
        /// <summary>
        /// two d array of cells making up the spreadsheet itself.
        /// </summary>
        private Cell[,] spreadsheet;

        /// <summary>
        /// The amount of rows in the spreadsheet.
        /// </summary>
        private int rowCount;

        /// <summary>
        /// The amount of columns in the spreadsheet.
        /// </summary>
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
        /// saves the current spreadsheet to an xml file.
        /// </summary>
        /// <param name="filePath">
        /// file that we are saving spreadsheet to.
        /// </param>
        public void Save(string filePath)
        {
            // covert from spreadsheet to xml.
            int rowIndex = 0;
            int colIndex = 0;

            XmlWriterSettings settings = new XmlWriterSettings
            {
                Indent = true, // we want indented xml for file for readabilty.
            };

            using (XmlWriter xmlWriter = XmlWriter.Create(filePath, settings))
            {
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("spreadsheet"); // first element.

                for (rowIndex = 0; rowIndex < this.rowCount; rowIndex++) // iterate through the spreadsheet.
                {
                    for (colIndex = 0; colIndex < this.ColumnCount; colIndex++)
                    {
                        // if spreadsheet cell has a changed from default attribute, then add to xml.
                        if (this.spreadsheet[rowIndex, colIndex].Text != string.Empty || this.spreadsheet[rowIndex, colIndex].BGColor != 0xFFFFFFFF)
                        {
                            // some property has been changed, so we add to xml.
                            xmlWriter.WriteStartElement("cell");
                            xmlWriter.WriteAttributeString("name", this.spreadsheet[rowIndex, colIndex].GetCellName());
                            xmlWriter.WriteElementString("bgcolor", this.spreadsheet[rowIndex, colIndex].BGColor.ToString());
                            xmlWriter.WriteElementString("text", this.spreadsheet[rowIndex, colIndex].Text.ToString());
                            xmlWriter.WriteEndElement();
                        }
                    }
                }

                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndDocument();
            }
        }

        /// <summary>
        /// This will load an xml file into the spreadsheet file.
        /// </summary>
        /// <param name="filePath">
        /// the filepath that we are loading the xml file from.
        /// </param>
        public void Load(string filePath)
        {
            // need to remove all events?.
            // need to reinitilize spreadsheet
            this.ResetSpreadsheet();
            int rowIndex = 0;
            int colIndex = 0;
            Cell curCell = null;

            // convert from xml to spreadsheet.
            using (XmlReader xmlReader = XmlReader.Create(filePath))
            {
                try
                {
                    while (xmlReader.Read())
                    {
                        if (xmlReader.NodeType == XmlNodeType.Element)
                        {
                            if (xmlReader.Name == "cell")
                            {
                                string name = xmlReader.GetAttribute("name");
                                colIndex = name[0] - 'A'; // to convert A to 0.convert user input of example 3 to 2.
                                string rowIndexString = name.Substring(1);
                                if (int.TryParse(rowIndexString, out rowIndex)) // test to see if we can even convert to int, if we can, assign to rowIndex
                                {
                                    rowIndex = rowIndex - 1; // if the user input is =A1, what they really want is 0,0
                                    curCell = this.GetCell(rowIndex, colIndex);
                                }
                            }
                            else if (xmlReader.Name == "bgcolor") // test to see if this is bgcolor element.
                            {
                                xmlReader.Read();
                                if (xmlReader.Value != string.Empty && uint.TryParse(xmlReader.Value.Trim(), out uint newBGColor) && curCell != null)
                                {
                                    // if value can be parsed and the cell is initilized, then set to color.
                                    curCell.BGColor = newBGColor;
                                }
                                else
                                {
                                    throw new Exception("BGColor value could not be parsed or the cell was null.");
                                }
                            }
                            else if (xmlReader.Name == "text") // test to see if this is bgcolor element.
                            {
                                xmlReader.Read();
                                if (xmlReader.Value != string.Empty && curCell != null)
                                {
                                    // if value can be parsed and the cell is initilized, then value set to text.
                                    curCell.Text = xmlReader.Value.Trim();
                                }
                                else
                                {
                                    throw new Exception("Text could not be inputted since cell was null.");
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"LOAD ERROR:: {ex.Message}");
                }
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
            curCell.RemoveDependencies();

            // bool finishColumnRead = false;
            // will add future implementation of operators here.
            if (curCell.Text.Length >= 2 && curCell.Text[0] == '=')
            {
                try
                {
                    // grab the actual expression.
                    string expression = curCell.Text.Substring(1);
                    ExpressionTree tree = new SpreadsheetEngine.ExpressionTree(expression);
                    if (tree.IsRootNull())
                    {
                        Console.WriteLine("Please enter new expression.");
                        throw new ArgumentException("Expression Tree could not be formed.");
                    }

                    Dictionary<string, double> variables = tree.GetVariableNames();

                    foreach (var item in variables)
                    {
                        // only the initilization to cell ID
                        int columnIndex = item.Key[0] - 'A'; // to convert A to 0.convert user input of example 3 to 2.
                        string rowIndexString = item.Key.Substring(1);
                        if (int.TryParse(rowIndexString, out int rowIndex)) // test to see if we can even convert to int, if we can, assign to rowIndex
                        {
                            rowIndex = rowIndex - 1; // if the user input is =A1, what they really want is 0,0
                            Cell variableCell = this.GetCell(rowIndex, columnIndex);
                            if (variableCell != null)
                            {
                                if (variableCell == curCell)
                                {
                                    // self reference.
                                    throw new ArgumentException("Expression contained self reference.");
                                }

                                if (variableCell.DependentCells != null) // want to iterate through dependent cell to make sure none of them are circular.
                                {
                                    if (this.CheckCircular(curCell, variableCell) == false)
                                    {
                                        throw new ArgumentException("Expression contained circular reference.");
                                    }
                                }

                                curCell.AddDependency(variableCell); // add the variable to the dependency list.
                                variableCell.PropertyChanged += curCell.OnDependencyChanged; // subscribe cur cell to variable cell.

                                if (double.TryParse(variableCell.Value, out double value))
                                {
                                    tree.SetVariable(item.Key, value); // set the value of varibale.
                                }
                                else
                                {
                                    if (variableCell.Value == string.Empty)
                                    {
                                        // curCell.Value = string.Empty;
                                        tree.SetVariable(item.Key, 0); // set the value of varibale.
                                    }
                                    else
                                    {
                                        curCell.Value = variableCell.Value;
                                        Console.WriteLine(item.Key + "unable to be found");
                                        return;
                                    }
                                }
                            }
                            else
                            {
                                // row and column index are out of range, so error.
                                throw new IndexOutOfRangeException("variable row and column index are out of range, so error.");
                            }
                        }
                        else
                        {
                            // row index doesnt fit format, so error.
                            throw new IndexOutOfRangeException("Current cell is out of bounds.");
                        }
                    }

                    if (tree.Evaluate() == double.NaN)
                    {
                        curCell.Value = "!ERROR!";
                    }
                    else
                    {// set all variables, so now evaluate
                        curCell.Value = tree.Evaluate().ToString();
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Evaluation error: {ex.Message}");
                    if (ex.Message == "Expression Tree could not be formed.")
                    {
                        curCell.Value = "!INVALID EXPRESSION!";
                    }
                    else if (ex.Message == "Expression contained self reference.")
                    {
                        curCell.Value = "!SELF REFERENCE!";
                    }
                    else if (ex.Message == "Expression contained circular reference.")
                    {
                        curCell.Value = "!CIRCULAR REFERENCE!";
                    }
                    else
                    {
                        curCell.Value = "!ERROR!";
                    }
                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine($"Evaluation error: {ex.Message}");
                    curCell.Value = "!DOES NOT EXIST!";
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Unexpected error in evaluation: {ex.Message}");
                    curCell.Value = "!ERROR!";
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
        /// go through variable cellls dependent cells to make sure curCell isnt in there.
        /// </summary>
        /// <param name="curCell">
        /// og cell.
        /// </param>
        /// <param name="variableCell">
        /// what we are testing.
        /// </param>
        /// <returns>
        /// return false if circular, true if non circular.
        /// </returns>
        private bool CheckCircular(Cell curCell, Cell variableCell)
        {
            foreach (Cell dependent in variableCell.DependentCells)
            {
                // recursive call.
                if (dependent == curCell) // ahhhh circular
                {
                    return false;
                }
                else
                {
                    if (this.CheckCircular(curCell, dependent) == false) // recursive call.
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Reset spreadsheet to default, then create new cells.
        /// </summary>
        private void ResetSpreadsheet()
        {
            for (int rowIndex = 0; rowIndex < this.rowCount; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < this.columnCount; columnIndex++)
                {
                    // rowIndex and columnIndex will start at 0, while rowSize and columnSize will start at 1.
                    this.spreadsheet[rowIndex, columnIndex].Text = string.Empty; // reset the old stuff.
                    this.spreadsheet[rowIndex, columnIndex].BGColor = 0xFFFFFFFF;
                    this.spreadsheet[rowIndex, columnIndex] = new BasicCell(rowIndex, columnIndex);
                    this.spreadsheet[rowIndex, columnIndex].PropertyChanged += this.SpreadsheetPropertyChanged; // subscribe spreadsheet to cell's properties.
                }
            }
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
            if (e.PropertyName == "Text")
            {
                curCell.RemoveDependencies();
                if (curCell.Text != string.Empty && curCell.Text[0] == '=') // check if text needs to be evaluated.
                {
                    this.Evaluate(curCell); // if text needs to be evaluated, call function.
                }
                else
                {
                    curCell.Value = curCell.Text; // text isnt function, so just set value as cell content.
                }
            }

            this.CellPropertyChanged?.Invoke(curCell, e); // raise notificaiton to subscribers that spreadsheet changed.

            try
            {
                foreach (Cell cell in curCell.DependentCells)
                {
                    if (cell.Text != string.Empty && cell.Text[0] == '=')
                    {
                        this.Evaluate(cell);
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine($"Error: cell is either out of range or does not have value");
                curCell.Value = "!ERROR!";
            }
        }
    }
}
