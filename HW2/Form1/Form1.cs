// Emily Porter
// 011741612
namespace Form1
{
    using System;

    /// <summary>
    /// Form1 inherits from Form base class.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// Winform window constructor.
        /// </summary>
        public Form1()
        {
            this.InitializeComponent();
            string text = RunDistinctIntegers();
            this.textBox1.Text = text;
        }

        /// <summary>
        /// Will call all Distinct methods here.
        /// </summary>
        private static string RunDistinctIntegers()
        {
            string text = "1. Hash set method: ";
            RandomList randomList = new RandomList();
            text += randomList.HashSetDistinct();
            text += " unique numbers";
            text += "\r\n    Time complexity for this is linear or O(n), since the " +
                "total cost of HashSetDistinct() = 1(for the initilization of hash set) + n(iterating through list) + 1(return)+ a couple other integer operations = O(n)";

            text += "\r\n2. O(1) storage method: ";
            text += randomList.OStorageDistinct();
            text += " unique numbers";
            text += "\r\n3. Sorted method: ";
            text += randomList.SortedDistinct();
            text += " unique methods";
            return text;
        }

        /// <summary>
        /// Not quite sure how this works, but the Form1.Designer.cs Load doesnt work without this.
        /// </summary>
        /// <param name="sender">
        /// I am not sure how this works.
        /// </param>
        /// <param name="e">
        /// when something happens?.
        /// </param>
        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
