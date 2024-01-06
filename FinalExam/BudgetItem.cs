using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExam
{
    public enum BudgetItemType
    {
        Income,
        Expense
    }
    public class BudgetItem
    {
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
    }
}
