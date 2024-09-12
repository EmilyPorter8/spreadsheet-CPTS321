// Emily Porter
// 011741612
namespace Form1
{
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
            RunDistinctIntegers();
        }

        /// <summary>
        /// Will call all Distinct methods here.
        /// </summary>
        private static void RunDistinctIntegers()
        {
        }

        /// <summary>
        /// Not quite sure how this works, but the Form1.Designer.cs Load doesnt work without this.
        /// </summary>
        /// <param name="sender">
        /// I am not sure how this works.
        /// </param>
        /// <param name="e">
        /// when something happens.
        /// </param>
        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
