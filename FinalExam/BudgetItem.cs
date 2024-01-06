using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExam
{
    /// <summary>
    /// Enum that stores possible budget type values
    /// </summary>
    public enum BudgetItemType
    {
        Income,
        Expense
    }

    /// <summary>
    /// Stores all data related to a budget item
    /// </summary>
    public class BudgetItem : IComparable<BudgetItem>
    {
        // Attributes & appropriate getters/setters
        private string _name;
        private decimal _amount;
        private BudgetItemType _itemType;
        private DateTime _date;
        private bool _recurring;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public decimal Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        public BudgetItemType ItemType
        {
            get { return _itemType; }
            set { _itemType = value; }
        }

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public bool Recurring
        {
            get { return _recurring; }
            set { _recurring = value; }
        }

        /// <summary>
        /// Sort by date where later date = closer to the end of the list, and otherwise alphabetically by name
        /// </summary>
        /// <param name="other">BudgetItem to compare against</param>
        /// <returns>Returns an integer (-1, 1, 0) used in list sorting</returns>
        public int CompareTo(BudgetItem other)
        {
            if(this.Date > other.Date)
            {
                return 1;
            } else if(this.Date < other.Date)
            {
                return -1;
            } else
            {
                return this.Name.CompareTo(other.Name);
            }
        }
    }
}
