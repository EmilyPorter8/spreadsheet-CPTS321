namespace Spreadsheet_Emily_Porter
{
    /// <summary>
    /// winforms spreadsheet class definition.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// Winforms spreadsheet application constructor.
        /// </summary>
        public Form1()
        {
            this.InitializeComponent();
            this.InitilizeSpreadSheet();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        /// <summary>
        /// HW4 step 2 and 1: Initilizing the spreadsheet so it has alphabet columns and 50 rows.
        /// </summary>
        private void InitilizeSpreadSheet()
        {
            for (char c = 'A'; c <= 'Z'; c++) // iterate through alphabet, adding columns each time
            { 
                string newheader = c.ToString(); // newheader is.
                this.dataGridView1.Columns.Add(newheader,newheader); // add column with corresponding character to column name.
            }

            for (int i = 0; i < 50; i++) // add 50 rows to the dataGridView1
            {
                this.dataGridView1.Rows.Add(); // add new row to datagridview.
                this.dataGridView1.Rows[i].HeaderCell.Value = i.ToString(); // name row that we just added.
            }
        }
    }
}
