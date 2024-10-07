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
    internal class BasicCell : Cell
    {
        public BasicCell(int newRowIndex, int newColumnIndex)
            : base(newRowIndex, newColumnIndex)
        {
        }


    }
}
