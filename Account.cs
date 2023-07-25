using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planner
{
    internal class Account
    {
        public int Id { get; set; }
        public decimal Balance { get; set; }
        public static List<Account> Accounts = new ();
        public List<Income> Incomes { get; set; } = new ();
        public List<Expense> Expenses { get; set; } = new ();
        public Account(decimal balance)
        {
            if (Accounts.Count == 0) Id = 0;
            else Id = Accounts.Max(e => e.Id) + 1;
            Balance = balance;
            Accounts.Add(this);
        }

        public override string ToString()
        {
            return $"Account Id: {Id}, Account balance: {Balance} ";
        }

        public static void ShowAccounts()
        {

            foreach (Account account in Accounts)
            {
                Console.WriteLine(account);
            }
            Console.WriteLine("---------------------------------- \n");
        }

        public static Account ChooseCurrentAccount(int id)
        {
            Account account = Accounts.First(e => e.Id == id);
            return account;
        }

        public void ShowAccountOperations()
        {
            foreach (Income income in Incomes)
            {
                Console.WriteLine(income);
            }
            Console.WriteLine("---------------------------------- \n");
        }
    }
}
