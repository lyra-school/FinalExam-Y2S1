/* ID: S00233718
 * Date: 6/1/2024
 * Desc: Final Exam
 * GH Link: https://github.com/lyra-school/FinalExam-Y2S1
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FinalExam
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // lists to hold items for either listbox
        private List<BudgetItem> income = new List<BudgetItem>();
        private List<BudgetItem> expenses = new List<BudgetItem>();
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Populates lists with data provided in exam paper
        /// </summary>
        private void DataCreator()
        {
            income.Add(new BudgetItem() { Name = "Grant", Amount = 300, Date = new DateTime(2024, 1, 5), ItemType = BudgetItemType.Income, Recurring = true});
            income.Add(new BudgetItem() { Name = "Bonus", Amount = 300, Date = new DateTime(2024, 1, 15), ItemType = BudgetItemType.Income, Recurring = false });
            income.Add(new BudgetItem() { Name = "Wages", Amount = 100, Date = new DateTime(2024, 1, 25), ItemType = BudgetItemType.Income, Recurring = true });

            expenses.Add(new BudgetItem() { Name = "Rent", Amount = 400, Date = new DateTime(2024, 1, 1), ItemType = BudgetItemType.Expense, Recurring = true });
            expenses.Add(new BudgetItem() { Name = "Flight", Amount = 100, Date = new DateTime(2024, 1, 5), ItemType = BudgetItemType.Expense, Recurring = false });
            expenses.Add(new BudgetItem() { Name = "Netflix", Amount = 10, Date = new DateTime(2024, 1, 15), ItemType = BudgetItemType.Expense, Recurring = true });
            expenses.Add(new BudgetItem() { Name = "Spotify", Amount = 8, Date = new DateTime(2024, 1, 20), ItemType = BudgetItemType.Expense, Recurring = true });
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
