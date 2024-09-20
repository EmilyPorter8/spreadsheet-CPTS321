// <copyright file="NotepadTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HW3Test
{
    using System.ComponentModel;
    using Notepad;

    /// <summary>
    /// Testing Notepad methods.
    /// </summary>
    [TestFixture]
    public class NotepadTest
    {
        /// <summary>
        /// Do not need set up.
        /// </summary>
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// Trying to test method of LoadTest(). Unsure if this test is even necassary since it is part of interface.
        /// </summary>
        [Test]
        public void TestLoadText()
        {
            TextReader testReader = new StringReader("testing if LoadText() will read this");

            // Notepad testNotepad.
            Assert.Pass();
        }
    }
}