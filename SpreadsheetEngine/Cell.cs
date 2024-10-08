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
    /// HW4 Part 4.
    /// </summary>
    public abstract class Cell : INotifyPropertyChanged
    {
        private readonly int rowindex;
        private readonly int columnindex;
        protected string text; // what we show to user.
        protected string value; // what cell actually contains.

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
        }

        /// <summary>
        /// This is the list of subsribers that will be notified when text/value is changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

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
            get => this.text;
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
    }
}
