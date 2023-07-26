using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planner
{
    internal class Income : Operation
    {
        public string? Description { get; set; }
        public Income(decimal operationDecimal, string? description): base(operationDecimal)
        {
            Description = description;
        }

        public Income()
        {

        }

        public override string ToString()
        {
            return $"Income Id: {Id}, Income amount: {OperationDecimal}, Income description: {Description}";
        }

        public static void AddIncome(Account? account, decimal operationDecimal, string? description)
        {
            var addedOperation = new Income(operationDecimal, description);

            account.Operations.Add(addedOperation);
            
            Console.WriteLine($"Operation {addedOperation} has been added.");
        }

        public static void RemoveIncome(Account? account)
        {
            Console.WriteLine("List of incomes for selected account: ");
            foreach (var operation in account.Operations)
            {
                var income = (Income)operation;
                Console.WriteLine(income);
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
