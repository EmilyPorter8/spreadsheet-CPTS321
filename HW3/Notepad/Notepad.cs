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
            // skeleton code
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


        private void saveToFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    // Code to write the stream goes here.
                    myStream.Close();
                }
            }
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void loadFibonacciNumbersfirst50ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void loadFromFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void loadFibonacciNumbersfirst100ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
