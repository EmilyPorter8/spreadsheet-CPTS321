
namespace Notepad
{
    partial class Notepad
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox1 = new TextBox();
            openFileDialog1 = new OpenFileDialog();
            saveFileDialog1 = new SaveFileDialog();
            fileToolStripMenuItem = new ToolStripMenuItem();
            loadFromFileToolStripMenuItem = new ToolStripMenuItem();
            loadFibonacciNumbersfirst50ToolStripMenuItem = new ToolStripMenuItem();
            loadFibonacciNumbersfirst100ToolStripMenuItem = new ToolStripMenuItem();
            saveToFileToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1 = new MenuStrip();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Dock = DockStyle.Right;
            textBox1.Location = new Point(156, 28);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ScrollBars = ScrollBars.Both;
            textBox1.Size = new Size(644, 422);
            textBox1.TabIndex = 0;
            textBox1.TextChanged += TextBox1_TextChanged;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.FileOk += openFileDialog1_FileOk;
            // 
            // saveFileDialog1
            // 
            saveFileDialog1.Filter = "text file|*.txt";
            saveFileDialog1.FileOk += saveFileDialog1_FileOk;
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { loadFromFileToolStripMenuItem, loadFibonacciNumbersfirst50ToolStripMenuItem, loadFibonacciNumbersfirst100ToolStripMenuItem, saveToFileToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(46, 24);
            fileToolStripMenuItem.Text = "File";
            fileToolStripMenuItem.Click += fileToolStripMenuItem_Click;
            // 
            // loadFromFileToolStripMenuItem
            // 
            loadFromFileToolStripMenuItem.Name = "loadFromFileToolStripMenuItem";
            loadFromFileToolStripMenuItem.Size = new Size(316, 26);
            loadFromFileToolStripMenuItem.Text = "Load from file...";
            loadFromFileToolStripMenuItem.Click += loadFromFileToolStripMenuItem_Click;
            // 
            // loadFibonacciNumbersfirst50ToolStripMenuItem
            // 
            loadFibonacciNumbersfirst50ToolStripMenuItem.Name = "loadFibonacciNumbersfirst50ToolStripMenuItem";
            loadFibonacciNumbersfirst50ToolStripMenuItem.Size = new Size(316, 26);
            loadFibonacciNumbersfirst50ToolStripMenuItem.Text = "Load Fibonacci numbers(first 50)";
            loadFibonacciNumbersfirst50ToolStripMenuItem.Click += loadFibonacciNumbersfirst50ToolStripMenuItem_Click;
            // 
            // loadFibonacciNumbersfirst100ToolStripMenuItem
            // 
            loadFibonacciNumbersfirst100ToolStripMenuItem.Name = "loadFibonacciNumbersfirst100ToolStripMenuItem";
            loadFibonacciNumbersfirst100ToolStripMenuItem.Size = new Size(316, 26);
            loadFibonacciNumbersfirst100ToolStripMenuItem.Text = "Load Fibonacci numbers(first 100)";
            loadFibonacciNumbersfirst100ToolStripMenuItem.Click += loadFibonacciNumbersfirst100ToolStripMenuItem_Click;
            // 
            // saveToFileToolStripMenuItem
            // 
            saveToFileToolStripMenuItem.Name = "saveToFileToolStripMenuItem";
            saveToFileToolStripMenuItem.Size = new Size(316, 26);
            saveToFileToolStripMenuItem.Text = "Save to file...";
            saveToFileToolStripMenuItem.Click += saveToFileToolStripMenuItem_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 28);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // Notepad
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textBox1);
            Controls.Add(menuStrip1);
            Name = "Notepad";
            Text = "321 Notepad";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem loadFromFileToolStripMenuItem;
        private ToolStripMenuItem loadFibonacciNumbersfirst50ToolStripMenuItem;
        private ToolStripMenuItem loadFibonacciNumbersfirst100ToolStripMenuItem;
        private ToolStripMenuItem saveToFileToolStripMenuItem;
        private MenuStrip menuStrip1;
    }
}
