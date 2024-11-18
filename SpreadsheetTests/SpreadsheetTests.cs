// <copyright file="SpreadsheetTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// Emily Porter 011741612

namespace SpreadsheetTests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Threading.Tasks;
    using NUnit.Framework;
    using SpreadsheetEngine;

    /// <summary>
    /// Test for Spreadsheet class, which is a 2d array of BasicCell.
    /// </summary>
    public class SpreadsheetTests
    {
        // tests to implement: constructor for cell should only get ones in bounds of spreadsheet.
        // test to set value.
        private SpreadsheetEngine.Spreadsheet testNormal;
        private SpreadsheetEngine.Spreadsheet testBoundary;
        private SpreadsheetEngine.Spreadsheet testExceptional;
        private SpreadsheetEngine.Spreadsheet testActual; // actual size of spreadsheet used in this application.

        /// <summary>
        /// Constructing a test Spreadsheet.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.testNormal = new SpreadsheetEngine.Spreadsheet(5, 3);
            this.testBoundary = new SpreadsheetEngine.Spreadsheet(0, 0);
            this.testExceptional = new SpreadsheetEngine.Spreadsheet(-5, -30);
            this.testActual = new SpreadsheetEngine.Spreadsheet(50, 26);
        }

        /// <summary>
        /// Just testing to see if constructor actually constructs something.
        /// </summary>
        [Test]
        public void NormalConstructorTest()
        {
            Assert.IsNotNull(this.testNormal.GetSpreadsheet());
        }

        /// <summary>
        /// Testing if 0,0 input returns null.
        /// </summary>
        [Test]
        public void BoundaryConstructorTest()
        {
            Assert.IsNull(this.testBoundary.GetSpreadsheet());
        }

        /// <summary>
        /// Testing if negative user input returns null.
        /// </summary>
        [Test]
        public void ExceptionalConstructorTest()
        {
            Assert.IsNull(this.testExceptional.GetSpreadsheet());
        }

        /// <summary>
        /// Test if getcell returns correct cell data information.
        /// </summary>
        [Test]
        public void NormalGetCellTest()
        {
            SpreadsheetEngine.Cell testCell = this.testNormal.GetCell(2, 1);

            Assert.That(testCell.RowIndex, Is.EqualTo(2));
            Assert.That(testCell.ColumnIndex, Is.EqualTo(1));
        }

        /// <summary>
        /// Test if getcell returns correct cell data information for boundary.
        /// </summary>
        [Test]
        public void BoundaryGetCellTest()
        {
            // using testNormal here instead of testBoundary because testBoundary should be null and I want to test boundary of GetCell() not of testBoundary.
            SpreadsheetEngine.Cell testCell = this.testNormal.GetCell(0, 0);

            Assert.That(testCell.RowIndex, Is.EqualTo(0));
            Assert.That(testCell.ColumnIndex, Is.EqualTo(0));
        }

        /// <summary>
        /// Test if getcell returns correct cell data information for out of bounds inputs.
        /// </summary>
        [Test]
        public void ExceptionalGetCellTest1()
        {
            Assert.IsNull(this.testNormal.GetCell(-3, -8));
        }

        /// <summary>
        /// Test if getcell returns correct cell data information for out of bounds inputs.
        /// </summary>
        [Test]
        public void ExceptionalGetCellTest2()
        {
            Assert.IsNull(this.testNormal.GetCell(5, 2));
        }

        /// <summary>
        /// Normal Test to see if RowCount returns correct rowCount value.
        /// </summary>
        [Test]
        public void NormalGetRowCount()
        {
            Assert.That(this.testNormal.RowCount, Is.EqualTo(5));
        }

        /// <summary>
        /// Normal Test to see if ColumnCount returns correct columnCount value.
        /// </summary>
        [Test]
        public void NormalGetColumnCount()
        {
            Assert.That(this.testNormal.ColumnCount, Is.EqualTo(3));
        }

        /// <summary>
        /// Exceptional Test to see if RowCount returns correct rowCount value.
        /// </summary>
        [Test]
        public void ExceptionalGetRowCount()
        {
            Assert.That(this.testExceptional.RowCount, Is.EqualTo(0));
        }

        /// <summary>
        /// Exceptional Test to see if ColumnCount returns correct columnCount value.
        /// </summary>
        [Test]
        public void ExceptionalGetColumnCount()
        {
            Assert.That(this.testExceptional.ColumnCount, Is.EqualTo(0));
        }

        /// <summary>
        /// Boundary Test to see if RowCount returns correct rowCount value.
        /// </summary>
        [Test]
        public void BoundaryGetRowCount()
        {
            Assert.That(this.testBoundary.RowCount, Is.EqualTo(0));
        }

        /// <summary>
        /// Boundary Test to see if ColumnCount returns correct columnCount value.
        /// </summary>
        [Test]
        public void BoundaryGetColumnCount()
        {
            Assert.That(this.testBoundary.ColumnCount, Is.EqualTo(0));
        }

        /// <summary>
        /// Normal testing if value of Evaluation() correctly updates cell value. This works,
        /// but not when the this.PropertyChanged(this, new PropertyChangedEventArgs("Value")) is
        /// implemented in the Value setter, a System.IndexOutOfRangeException is raised.
        /// </summary>
        [Test]
        public void NormalEvaluation()
        {
            // this.testNormal.GetSpreadsheet()[0, 1].Value = 5.ToString(); // what we will grab with next cell. column B and row 3.
            // this.testNormal.GetSpreadsheet()[1, 1].Text = "=B1"; // have to remember that B is column and 3 is row, so 2, 1 is actual index.
            // this.testNormal.Evaluate(this.testNormal.GetSpreadsheet()[1, 1]);
            // Assert.That(this.testNormal.GetCell(1, 1).Value, Is.EqualTo("5"));
        }

        /// <summary>
        /// Boundary testing if value of Evaluation() correctly updates cell value to error if index is outside of bounds.
        /// </summary>
        [Test]
        public void BoundaryEvaluation()
        {
            this.testNormal.GetSpreadsheet()[1, 1].Text = "=Z3";
            this.testNormal.Evaluate(this.testNormal.GetSpreadsheet()[1, 1]);
            Assert.That(this.testNormal.GetCell(1, 1).Value, Is.EqualTo("!ERROR!"));
        }

        /// <summary>
        /// Exceptional testing if value of Evaluation() correctly updates cell value to error if incorrect input.
        /// </summary>
        [Test]
        public void ExceptionalEvaluation()
        {
            this.testNormal.GetSpreadsheet()[1, 1].Text = "=potato";
            this.testNormal.Evaluate(this.testNormal.GetSpreadsheet()[1, 1]);
            Assert.That(this.testNormal.GetCell(1, 1).Value, Is.EqualTo("!ERROR!"));
        }

        /// <summary>
        /// test to see if the spreadsheet will update cell correctly.
        /// </summary>
        [Test]
        public void DependentNormalTest1()
        {
            this.testNormal.GetSpreadsheet()[0, 0].Text = "3";
            this.testNormal.GetSpreadsheet()[0, 1].Text = "4";
            this.testNormal.GetSpreadsheet()[0, 2].Text = "=A1+B1";
            this.testNormal.GetSpreadsheet()[0, 1].Text = "5";
            Assert.That(this.testNormal.GetCell(0, 2).Value, Is.EqualTo("8"));
        }

        /// <summary>
        /// test to see if the spreadsheet will update cell correctly.
        /// </summary>
        [Test]
        public void DependentNormalTest2()
        {
            this.testNormal.GetSpreadsheet()[0, 0].Text = "3";
            this.testNormal.GetSpreadsheet()[0, 1].Text = "4";
            this.testNormal.GetSpreadsheet()[0, 2].Text = "=A1+B1";
            Console.WriteLine("here");
            this.testNormal.GetSpreadsheet()[1, 0].Text = "5";
            this.testNormal.GetSpreadsheet()[0, 2].Text = "=A1+A2";
            Assert.That(this.testNormal.GetCell(0, 2).Value, Is.EqualTo("8"));
        }

        /// <summary>
        /// test to see if the spreadsheet will update cell undo and redo.
        /// </summary>
        [Test]
        public void UndoNormalTest()
        {
            SpreadsheetEngine.EditInvoker testEditInvoker = new SpreadsheetEngine.EditInvoker();
            SpreadsheetEngine.BasicCell cell = new SpreadsheetEngine.BasicCell(0, 0);
            Cell[] cells = new Cell[1];
            cells[0] = cell;
            uint[] prevColor = new uint[1];
            prevColor[0] = 0;
            uint[] curColor = new uint[1];
            curColor[0] = 5;
            ColorCommand newColor = new ColorCommand(cells, prevColor, curColor);
            testEditInvoker.AddUndo(newColor);
            Assert.That(testEditInvoker.PeekUndo().Description, Is.EqualTo("changing cell background colour"));
        }

        /// <summary>
        /// test to see if the spreadsheet will update cell undo and redo.
        /// </summary>
        [Test]
        public void UndoNormalTest2()
        {
            SpreadsheetEngine.EditInvoker testEditInvoker = new SpreadsheetEngine.EditInvoker();
            SpreadsheetEngine.BasicCell cell = new SpreadsheetEngine.BasicCell(0, 0);
            Cell[] cells = new Cell[1];
            cells[0] = cell;
            uint[] prevColor = new uint[1];
            prevColor[0] = 0;
            uint[] curColor = new uint[1];
            curColor[0] = 5;
            ColorCommand newColor = new ColorCommand(cells, prevColor, curColor);
            testEditInvoker.AddUndo(newColor);
            testEditInvoker.UndoButtonPushed();
            Assert.That(testEditInvoker.PeekUndo(), Is.EqualTo(null));
        }

        /// <summary>
        /// test to see if the spreadsheet will update cell undo and redo.
        /// </summary>
        [Test]
        public void UndoBoandaryTest()
        {
            SpreadsheetEngine.EditInvoker testEditInvoker = new SpreadsheetEngine.EditInvoker();
            SpreadsheetEngine.BasicCell cell = new SpreadsheetEngine.BasicCell(0, 0);
            Cell[] cells = new Cell[1];
            cells[0] = cell;
            uint[] prevColor = new uint[1];
            prevColor[0] = 0;
            uint[] curColor = new uint[1];
            curColor[0] = 5;
            ColorCommand newColor = new ColorCommand(cells, prevColor, curColor);
            testEditInvoker.AddUndo(newColor);
            testEditInvoker.UndoButtonPushed();
            testEditInvoker.UndoButtonPushed();
            Assert.That(testEditInvoker.PeekUndo(), Is.EqualTo(null));
        }

        /// <summary>
        /// test to see if the spreadsheet will update cell redo.
        /// </summary>
        [Test]
        public void RedoExceptionalTest()
        {
            SpreadsheetEngine.EditInvoker testEditInvoker = new SpreadsheetEngine.EditInvoker();
            testEditInvoker.RedoButtonPushed();
            Assert.That(testEditInvoker.PeekRedo(), Is.EqualTo(null));
        }

        /// <summary>
        /// test load normal.
        /// </summary>
        [Test]
        public void NormalLoadTest()
        {
            this.testActual.Load("C:\\Users\\emily\\OneDrive\\Documents\\CPTS 321\\cpts321-emily-porter-hws\\SpreadsheetTests\\testLoad.xml");
            Assert.That(this.testActual.GetCell(0, 0).Text, Is.EqualTo("5"));
            Assert.That(this.testActual.GetCell(0, 0).BGColor, Is.EqualTo(4294934656));
            Assert.That(this.testActual.GetCell(2, 0).Text, Is.EqualTo("=A1+A2"));
            Assert.That(this.testActual.GetCell(2, 0).Value, Is.EqualTo("13"));
        }

        /// <summary>
        /// test load boundary, with file that has some extra elements.
        /// </summary>
        [Test]
        public void BoundaryLoadTest()
        {
            this.testActual.Load("C:\\Users\\emily\\OneDrive\\Documents\\CPTS 321\\cpts321-emily-porter-hws\\SpreadsheetTests\\testLoadBoundary.xml");
            Assert.That(this.testActual.GetCell(0, 0).Text, Is.EqualTo("5"));
            Assert.That(this.testActual.GetCell(0, 0).BGColor, Is.EqualTo(4294934656));
            Assert.That(this.testActual.GetCell(2, 0).Text, Is.EqualTo("=A1+A2"));
            Assert.That(this.testActual.GetCell(2, 0).Value, Is.EqualTo("13"));
        }

        /// <summary>
        /// test load exeception, with file that has nothing.
        /// </summary>
        [Test]
        public void ExceptionalLoadTest()
        {
            // this.testActual.Load("C:\\Users\\emily\\OneDrive\\Documents\\CPTS 321\\cpts321-emily-porter-hws\\SpreadsheetTests\\testExceptionalLoad.xml");;
            // Assert.That(this.testActual.Load("C:\\Users\\emily\\OneDrive\\Documents\\CPTS 321\\cpts321-emily-porter-hws\\SpreadsheetTests\\testExceptionalLoad.xml"), Throws.Exception.TypeOf);
        }

        /// <summary>
        /// This gives the right errror message if the cell name is bad. Already have test for this, but without updated error message.
        /// </summary>
        [Test]
        public void BadCellNameTest1()
        {
            this.testNormal.GetSpreadsheet()[1, 1].Text = "=potato";
            this.testNormal.Evaluate(this.testNormal.GetSpreadsheet()[1, 1]);
            Assert.That(this.testNormal.GetCell(1, 1).Value, Is.EqualTo("!DOES NOT EXIST!"));
        }

        /// <summary>
        /// this tests if an out of range cell gives the right error message.
        /// </summary>
        [Test]
        public void OutOfRangeCellTest1()
        {
            this.testNormal.GetSpreadsheet()[1, 1].Text = "=Z3214";
            this.testNormal.Evaluate(this.testNormal.GetSpreadsheet()[1, 1]);
            Assert.That(this.testNormal.GetCell(1, 1).Value, Is.EqualTo("!DOES NOT EXIST!"));
        }

        /// <summary>
        /// this tests a more complicated badly named cell equatiom, if the error message appears corrclty.
        /// </summary>
        [Test]
        public void BadCellNameTest2()
        {
            this.testNormal.GetSpreadsheet()[1, 1].Text = "=potato+30*4";
            this.testNormal.Evaluate(this.testNormal.GetSpreadsheet()[1, 1]);
            Assert.That(this.testNormal.GetCell(1, 1).Value, Is.EqualTo("!DOES NOT EXIST!"));
        }

        /// <summary>
        /// this tests a more complicated out of range cell, if the error message appears corrclty.
        /// </summary>
        [Test]
        public void OutOfRangeCellTest2()
        {
            this.testNormal.GetSpreadsheet()[0, 1].Text = "=(Z3214+4)/3";
            this.testNormal.Evaluate(this.testNormal.GetSpreadsheet()[0, 1]);
            Assert.That(this.testNormal.GetCell(0, 1).Value, Is.EqualTo("!DOES NOT EXIST!"));
        }
    }
}
