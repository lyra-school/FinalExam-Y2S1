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
        private List<BudgetItem> _income = new List<BudgetItem>();
        private List<BudgetItem> _expenses = new List<BudgetItem>();
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Populates lists with data provided in exam paper
        /// </summary>
        private void DataCreator()
        {
            _income.Add(new BudgetItem() { Name = "Grant", Amount = 300, Date = new DateTime(2024, 1, 5), ItemType = BudgetItemType.Income, Recurring = true});
            _income.Add(new BudgetItem() { Name = "Bonus", Amount = 300, Date = new DateTime(2024, 1, 15), ItemType = BudgetItemType.Income, Recurring = false });
            _income.Add(new BudgetItem() { Name = "Wages", Amount = 100, Date = new DateTime(2024, 1, 25), ItemType = BudgetItemType.Income, Recurring = true });

            _expenses.Add(new BudgetItem() { Name = "Rent", Amount = 400, Date = new DateTime(2024, 1, 1), ItemType = BudgetItemType.Expense, Recurring = true });
            _expenses.Add(new BudgetItem() { Name = "Flight", Amount = 100, Date = new DateTime(2024, 1, 5), ItemType = BudgetItemType.Expense, Recurring = false });
            _expenses.Add(new BudgetItem() { Name = "Netflix", Amount = 10, Date = new DateTime(2024, 1, 15), ItemType = BudgetItemType.Expense, Recurring = true });
            _expenses.Add(new BudgetItem() { Name = "Spotify", Amount = 8, Date = new DateTime(2024, 1, 20), ItemType = BudgetItemType.Expense, Recurring = true });

            _income.Sort();
            _expenses.Sort();
        }

        /// <summary>
        /// Populates listboxes with relevant lists on window load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataCreator();
            incomeList.ItemsSource = _income;
            expenseList.ItemsSource = _expenses;
        }

        /// <summary>
        /// Creates a new budget item dependent on the user input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void add_Click(object sender, RoutedEventArgs e)
        {
            // Date, Name, Amount and at least one radio button must be selected/have input. Function returns if that's not the case
            if(date.SelectedDate == null || name.Text == null || amt.Text == null || (incRadio.IsChecked == false && expRadio.IsChecked == false))
            {
                return;
            }

            // if Amount can't be parsed to decimal, function returns
            decimal amtInDec = 0;
            if(!decimal.TryParse(amt.Text, out amtInDec))
            {
                return;
            }

            // create the new item
            BudgetItem newItem = new BudgetItem() { Name = name.Text, Amount = amtInDec, Date = (DateTime)date.SelectedDate};

            // assign recurrence status depending on checkbox
            if(recur.IsChecked == true)
            {
                newItem.Recurring = true;
            } else
            {
                newItem.Recurring = false;
            }

            // assign enum depending on radio button selected
            // finally, add item to an appropriate list, sort, and refresh display
            if(incRadio.IsChecked == true)
            {
                newItem.ItemType = BudgetItemType.Income;
                _income.Add(newItem);
                _income.Sort();
                incomeList.ItemsSource = null;
                incomeList.ItemsSource = _income;
            } else
            {
                newItem.ItemType = BudgetItemType.Expense;
                _expenses.Add(newItem);
                _expenses.Sort();
                expenseList.ItemsSource = null;
                expenseList.ItemsSource = _expenses;
            }
        }

        private void remove_Click(object sender, RoutedEventArgs e)
        {
            // if nothing is selected, function returns
            if(incomeList.SelectedItem == null && expenseList.SelectedItem == null)
            {
                return;
            }

            // get selected item, remove it from appropriate list, sort, and refresh display
            BudgetItem selection;
            if(incomeList.SelectedItem != null)
            {
                selection = incomeList.SelectedItem as BudgetItem;
                _income.Remove(selection);
                _income.Sort();
                incomeList.ItemsSource = null;
                incomeList.ItemsSource = _income;
            } else
            {
                selection = expenseList.SelectedItem as BudgetItem;
                _expenses.Remove(selection);
                _expenses.Sort();
                expenseList.ItemsSource = null;
                expenseList.ItemsSource = _expenses;
            }
        }
    }
}
