using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace TRACKERPROJECT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            FinanceData.finances.Add(new FinanceTracker() { Description = "Restaurant", Amount = 40.20, Date = DateTime.Now.AddDays(-4), category = TransCategory.Food});
            FinanceData.finances.Add(new FinanceTracker() { Description = "Income", Amount = -2842.70, Date = DateTime.Now.AddDays(-5), category = TransCategory.Income});
            FinanceData.finances.Add(new FinanceTracker() { Description = "Groceries", Amount = 90.16, Date = DateTime.Now.AddDays(-15), category = TransCategory.Food });
            FinanceData.finances.Add(new FinanceTracker() { Description = "Bar", Amount = 40.51, Date = DateTime.Now.AddDays(-10), category = TransCategory.Entertainment });
            FinanceData.finances.Add(new FinanceTracker() { Description = "DoorDash", Amount = 30.50, Date = DateTime.Now.AddDays(-10), category = TransCategory.Food });
            FinanceData.finances.Add(new FinanceTracker() { Description = "Restaurant", Amount = 75.00, Date = DateTime.Now.AddDays(-17), category = TransCategory.Food });
            FinanceData.finances.Add(new FinanceTracker() { Description = "Parking", Amount = 15.00, Date = DateTime.Now.AddDays(-17), category = TransCategory.Transportation });
            FinanceData.finances.Add(new FinanceTracker() { Description = "Gas", Amount = 49.49, Date = DateTime.Now.AddDays(-17), category = TransCategory.Transportation });
            FinanceData.finances.Add(new FinanceTracker() { Description = "Fitness", Amount = 45.00, Date = DateTime.Now.AddDays(-17), category = TransCategory.Health });
            FinanceData.finances.Add(new FinanceTracker() { Description = "DoorDash", Amount = 60.50, Date = DateTime.Now.AddDays(-19), category = TransCategory.Food });
            FinanceData.finances.Add(new FinanceTracker() { Description = "CVS", Amount = 59.19, Date = DateTime.Now.AddDays(-18), category = TransCategory.Health });
            FinanceData.finances.Add(new FinanceTracker() { Description = "Amazon", Amount = 34.82, Date = DateTime.Now.AddDays(-18), category = TransCategory.Entertainment });
            FinanceData.finances.Add(new FinanceTracker() { Description = "Restaurant", Amount = 37.49, Date = DateTime.Now.AddDays(-17), category = TransCategory.Food });
            FinanceData.finances.Add(new FinanceTracker() { Description = "Capital One", Amount = 100.70, Date = DateTime.Now.AddDays(-20), category = TransCategory.Debt });
            FinanceData.finances.Add(new FinanceTracker() { Description = "Amex", Amount = 259.55, Date = DateTime.Now.AddDays(-20), category = TransCategory.Debt });
            FinanceData.finances.Add(new FinanceTracker() { Description = "student loan", Amount = 100.00, Date = DateTime.Now.AddDays(-20), category = TransCategory.Debt });
            FinanceData.finances.Add(new FinanceTracker() { Description = "Restaurant", Amount = 42.51, Date = DateTime.Now.AddDays(-10), category = TransCategory.Food });
            FinanceData.finances.Add(new FinanceTracker() { Description = "Car Insurance", Amount = 258.52, Date = DateTime.Now.AddDays(-20), category = TransCategory.Transportation });
            FinanceData.finances.Add(new FinanceTracker() { Description = "Home Insurance", Amount = 75.48, Date = DateTime.Now.AddDays(-20), category = TransCategory.Housing });
            FinanceData.finances.Add(new FinanceTracker() { Description = "Amazon", Amount = 23.82, Date = DateTime.Now.AddDays(-18), category = TransCategory.Entertainment });
            FinanceData.finances.Add(new FinanceTracker() { Description = "Wifi", Amount = 83.00, Date = DateTime.Now.AddDays(-20), category = TransCategory.Housing });
            FinanceData.finances.Add(new FinanceTracker() { Description = "Water", Amount = 56.34, Date = DateTime.Now.AddDays(-20), category = TransCategory.Housing });
            FinanceData.finances.Add(new FinanceTracker() { Description = "Electricity", Amount = 145.30, Date = DateTime.Now.AddDays(-20), category = TransCategory.Housing });
            FinanceData.finances.Add(new FinanceTracker() { Description = "Mortgage", Amount = 1942.70, Date = DateTime.Now.AddDays(-20), category = TransCategory.Housing });
            FinanceData.finances.Add(new FinanceTracker() { Description = "Income", Amount = -2842.70, Date = DateTime.Now.AddDays(-19), category = TransCategory.Income});

            dataGridView1.DataSource = FinanceData.finances.ToList();

            DisplayFinance();

        }

        private void btnExpense_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(this, FinanceData.finances);  // Opens to Form3 to add new expense
            form3.Show();
        }

        private double CalculateExpense()  // Calculates current Expenses
        {
            double expenses = 0.0;

            foreach (var finance in FinanceData.finances)
            {
                if (finance.Amount > 0)
                {
                    expenses += finance.Amount;
                }
            }
            return expenses;
        } 
        private double CalculateIncome()  // Calculates current Balance
        {
            double balance = 0.0;

            foreach (var finance in FinanceData.finances)
            {
                balance += finance.Amount;
            }
            return balance;
        } 
        public void DisplayFinance()  // Displays current balance and expenses
        {
            double totalExpense = CalculateExpense();
            txtExpense.Text = totalExpense.ToString("C");

            double totalIncome = CalculateIncome();
            txtIncome.Text = totalIncome.ToString("C");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(this, FinanceData.finances);  // Opens Form2 for searching and sorting data

            DialogResult result = form2.ShowDialog();  // show Form2 as dialog

        }
        public void SortByCategory(TransCategory selectedCategory)  // sorts by category
        {
            FinanceData.finances = FinanceData.finances.FindAll(finance => finance.category == selectedCategory).ToList();
                                     
            UpdateDataGridView(FinanceData.finances);
        }

        public void SortByDescription(string searchText)  // sorts by "description"
        {
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                FinanceData.finances = FinanceData.finances
                    .FindAll(finance => finance.Description.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0)
                    .ToList();
            }
            else
            {
                // If search text is empty, revert to the original list
                FinanceData.finances = FinanceData.finances.ToList();
            }

            UpdateDataGridView(FinanceData.finances);
        }

        public void UpdateDataGridView(List<FinanceTracker> finances)  //update DataGridView
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = finances;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure?", "Warning", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                FinanceData.finances.RemoveAt(dataGridView1.CurrentRow.Index);
                UpdateDataGridView(FinanceData.finances);
                DisplayFinance();

            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = FinanceData.finances.ToList();
            dataGridView1.Refresh();

        }
    }

}
