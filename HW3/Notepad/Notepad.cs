// <copyright file="Notepad.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Notepad
{
    /// <summary>
    /// Inherits from Form in Winforms.
    /// </summary>
    public partial class Notepad : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Notepad"/> class.
        /// Notepad class construction.
        /// </summary>
        public Notepad()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Generic Loading Function. Takes text from sr
        /// and puts into textbox in interface.
        /// </summary>
        /// <param name="sr">
        /// sr is the text that should be put into the
        /// text box.
        /// </param>
        /// <remarks>
        /// Should show updated textbox.
        /// </remarks>
        private void LoadText(TextReader sr)
        {
            this.textBox1.Text = sr.ReadToEnd();
        }

        /// <summary>
        /// I believe this is for when text is edited in the text box?.
        /// </summary>
        /// <param name="sender">
        /// unsure what this is, maybe what the text will be edited to.
        /// </param>
        /// <param name="e">
        /// Also unsure about this, probably when text will be edited.
        /// </param>
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            // leaving this empty. for now?
        }

        /// <summary>
        /// Saves contents of textbox to user selected file.
        /// </summary>
        /// <param name="sender">
        /// Not sure how this works.
        /// </param>
        /// <param name="e">
        /// When user selectes this from menu.
        /// </param>
        private void saveToFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.saveFileDialog1.ShowDialog();
            string path = this.saveFileDialog1.FileName;
            using (StreamWriter streamWriter = new StreamWriter(path))
            {
                streamWriter.Write(this.textBox1.Text);
            }

            // File.WriteAllText(path, this.textBox1.Text);
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // throw new NotImplementedException();
        }

        private void loadFibonacciNumbersfirst50ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FibonacciTextReader streamReader = new FibonacciTextReader(50))
            {
                this.LoadText(streamReader);
            }
        }

        /// <summary>
        /// This is from menu, used to load text from user selected existing file.
        /// </summary>
        /// <param name="sender">
        /// Not sure what this is.
        /// </param>
        /// <param name="e">
        /// When user clicks on menu option.
        /// </param>
        private void loadFromFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.ShowDialog();
            using (StreamReader streamReader = new StreamReader(this.openFileDialog1.FileName))
            {
                this.LoadText(streamReader);
            }
        }

        private void loadFibonacciNumbersfirst100ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FibonacciTextReader streamReader = new FibonacciTextReader(100))
            {
                this.LoadText(streamReader);
            }
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }

        private void saveFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }
    }
}
