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

        /// <summary>
        /// List of cells that the current cell is dependent on.
        /// </summary>
        private List<Cell> dependentCells;

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
            this.dependentCells = new List<Cell> { };
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
                    this.OnPropertyChanged("Value");
                }
            }
        }

        /// <summary>
        /// Gets the dependentcells list.
        /// </summary>
        public List<Cell> DependentCells
        {
            get => this.dependentCells;
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
                    this.OnPropertyChanged("Text");
                }
            }
        }

        /// <summary>
        /// Adds the cell that this current cell is dependent on to the dependent cell library.
        /// Subscribes this current cell to the changes of dependent cell so that when
        /// dependent cell changes it will update this cell.
        /// </summary>
        /// <param name="dependentCell">
        /// cell that this current cell depends on.
        /// </param>
        public void AddDependency(Cell dependentCell)
        {
            if (!this.dependentCells.Contains(dependentCell)) // does it already exist?
            {
                this.dependentCells.Add(dependentCell); // add to list.
                dependentCell.PropertyChanged += this.PropertyChanged; // subscribe.
            }
        }

        /// <summary>
        /// Called everytime I evaluate. Removes all dependencies when the cell is being changed if it s a funciton.
        /// </summary>
        public void RemoveDependencies()
        {
            foreach (Cell dependentCell in this.dependentCells)
            {
                dependentCell.PropertyChanged -= this.PropertyChanged; // unsubscribe.
            }

            this.dependentCells.Clear(); // clear the libaray.
        }

        /// <summary>
        /// called for when dependentcell is changed.
        /// </summary>
        /// <param name="sender">
        /// cell that is changed.
        /// </param>
        /// <param name="e">
        /// what property has changed.
        /// </param>
        public void OnDependencyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Value")
            {
                this.OnPropertyChanged("Text"); // we changed the value of the dependency, so tell current cell that text has changed.
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
    }
}
