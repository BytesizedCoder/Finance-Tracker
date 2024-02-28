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
    public partial class Form3 : Form
    {
        private Form1 form1;  // Reference to Form1
        public Form3(Form1 form1, List<FinanceTracker> finances) // Constructor to ref to Form1 and finances list
        {
            InitializeComponent();
            this.form1 = form1;

            catSort2.DataSource = Enum.GetValues(typeof(TransCategory));
            catSort2.SelectedIndex = -1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            FinanceTracker newExpense = new FinanceTracker();  // creates object for new expense
            
            if (txtDescription2.Text != String.Empty && txtAmount.Text != String.Empty) // checks if fields are not empty
            {
                newExpense.Description = txtDescription2.Text;  //creating new expense
                newExpense.Amount = double.Parse(txtAmount.Text);
                newExpense.Date = DateTime.Now;
                newExpense.category = (TransCategory)catSort2.SelectedIndex;

                FinanceData.finances.Add(newExpense);  // add new expense

                form1.UpdateDataGridView(FinanceData.finances);  // updates financialtracker

                form1.DisplayFinance();

                this.Close();
            }
        }
    }
}
