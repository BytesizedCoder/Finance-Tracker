using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TRACKERPROJECT
{
    public partial class Form2 : Form
    {
        private Form1 form1;  // Reference to Form1
        public List<FinanceTracker> FilteredData { get; private set; }  // property to store filtered data

        public Form2(Form1 form1, List<FinanceTracker> finances)  // Constructor to ref to Form1 and finances list
        {
            InitializeComponent();
            this.form1 = form1;
            //this.finances = finances;

            FilteredData = new List<FinanceTracker>(finances);  // Initialize filtereddata with original finances

            catSort1.DataSource = Enum.GetValues(typeof(TransCategory));
            catSort1.SelectedIndex = -1;
        }

        private void btnsearch2_Click(object sender, EventArgs e)
        {
            FinanceTracker selectsort = new FinanceTracker();
            if (catSort1.SelectedIndex != -1) 
            {
           
                selectsort.category = (TransCategory)catSort1.SelectedIndex;
                form1.SortByCategory(selectsort.category);  // Sorts by category
            }
            else
            {
                selectsort.Description = txtDescription.Text;  // sorts by Description
                form1.SortByDescription(txtDescription.Text);

            }
            //form1.UpdateDataGridView(finances);
            form1.DisplayFinance();
            
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
