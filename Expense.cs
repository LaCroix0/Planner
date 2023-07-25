using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planner
{
    public enum Category
    {

    }
    internal class Expense : Operation
    {
        public Category Category { get; set; }
        public static List<Expense> Expenses = new ();

        public Expense(decimal operationDecimal, Category category)
        {
            if (Expenses.Count == 0) Id = 0;
            else Id = Expenses.Max(e => e.Id) + 1;
            OperationDecimal = operationDecimal;
            Category = category;
            Expenses.Add(this);
        }
    }
}
