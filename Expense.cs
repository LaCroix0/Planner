using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Planner
{
    public enum Category
    {
        Installments = 1,
        OneTimePayment = 2
    }
    internal class Expense : Operation
    {
        public int? Category { get; set; }
        public Expense(decimal operationDecimal, int? categoryId) : base(operationDecimal)
        {
            Category = categoryId;
        }

        public Expense()
        {

        }
        
        public override string ToString()
        {
            return $"Expense Id: {Id}, Expense amount: {OperationDecimal}, Expense Category: {(Category)Category}";
        }

        public static void AddExpense(Account? account, decimal operationDecimal, int? categoryId)
        {
            var expense = new Expense(operationDecimal, categoryId);
            account.Operations.Add(expense);

            Console.WriteLine($"Operation {expense} has been added.");
        }

        public static void RemoveExpense(Account? account)
        {
            Console.WriteLine("List of expenses for selected account: ");
            foreach (var operation in account.Operations)
            {
                var expense = (Expense)operation;
                Console.WriteLine(expense);
            }
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Please provide Id of an operation you wish to delete.");

            var inputId = Console.ReadLine();
            int.TryParse(inputId, out var operationId);


            var removedOperation = account.Operations.First(e => e.Id == operationId);
            account.Operations.Remove(removedOperation);

            Console.Clear();

            Console.WriteLine($"Operation {removedOperation} has been deleted.");
        }
    }
}
