using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planner
{
    internal class Income : Operation
    {
        public string? Description { get; set; }
        public static List<Income> Incomes { get; set; } = new();

        public Income(decimal operationDecimal, string? description)
        {
            if (Incomes.Count == 0) Id = 0;
            else Id = Incomes.Max(e => e.Id) + 1;
            OperationDecimal = operationDecimal;
            Description = description;
            Incomes.Add(this);
        }

        public override string ToString()
        {
            return $"Income Id: {Id}, Income amount: {OperationDecimal}, Income description: {Description}";
        }

        public static void AddIncome(Account? account, decimal operationDecimal, string? description)
        {
            if(account == null) throw new ArgumentNullException("You can't add income without selected account.");
            account.Incomes.Add(new Income(operationDecimal, description));
        }

    }
}
