// <copyright file="Cell.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// Emily Porter 011741612

namespace SpreadsheetEngine
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// abstract cell class that base cell will inherit from.
    /// </summary>
    public abstract class Cell : INotifyPropertyChanged
    {
        /// <summary>
        /// Row index of the cell.
        /// </summary>
        private readonly int rowindex;

        /// <summary>
        /// Column index of the cell.
        /// </summary>
        private readonly int columnindex;

        /// <summary>
        /// String that is shown to the user, result of some function.
        /// </summary>
        private string text;

        /// <summary>
        /// User inputted value.
        /// </summary>
        private string value;

        private List<Cell> independentCells;


        /// <summary>
        /// Initializes a new instance of the <see cref="Cell"/> class.
        /// constructor for cell.
        /// </summary>
        /// <param name="newRowIndex">
        /// Passed in the new row index to assign to rowindex property.
        /// </param>
        /// <param name="newColumnIndex">
        /// Passed in the new column index to assign to columnindex property.
        /// </param>
        public Cell(int newRowIndex, int newColumnIndex)
        {
            this.rowindex = newRowIndex;
            this.columnindex = newColumnIndex;
            this.text = string.Empty;
            this.value = string.Empty;
            this.independentCells = new List<Cell> { };
        }

        /// <summary>
        /// This is the list of subsribers that will be notified when text/value is changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        /// <summary>
        /// Gets the readonly rowindex. Initilize property.
        /// </summary>
        public int RowIndex { get => this.rowindex; } // row index for where cell is located.

        /// <summary>
        /// Gets the readonly column. Initilize property.
        /// </summary>
        public int ColumnIndex { get => this.columnindex; } // column index for where cell is located.

        /// <summary>
        /// Gets the value attribute. Set can now be defined as internal in the BaseCell class.
        /// </summary>
        public string Value
        {
            get => this.value;
            internal set
            {
                if (this.value == value)
                {
                    // ignore it.
                }
                else
                {
                    // text is actually being changed.
                    this.value = value;
                    this.PropertyChanged(this, new PropertyChangedEventArgs("Value"));
                }
            }
        }

        /// <summary>
        /// Gets or sets the text attribute.
        /// </summary>
        public string Text
        {
            get => this.text;

            set
            {
                if (this.text == value)
                {
                    // ignore it.
                }
                else
                {
                    // text is actually being changed.
                    this.text = value;
                    this.PropertyChanged(this, new PropertyChangedEventArgs("Text"));
                }
            }
        }

        /// <summary>
        /// Raises propertychanged event, so that subscribers can react to change.
        /// </summary>
        /// <param name="propertyName">
        /// Value or Text property depending on which has been changed.
        /// </param>
        protected void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void AddDependency(Cell independentCell)
        {
            this.independentCells.Add(independentCell);
            independentCell.PropertyChanged += this.PropertyChanged;
            this.PropertyChanged(this, new PropertyChangedEventArgs("Dependency"));
        }

        public void RemoveDependencies()
        {
            this.independentCells.Clear();
        }
    }
}
