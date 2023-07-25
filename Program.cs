using Planner;

class Program
{
    public static void Main()
    {
        Account account1 = new (6000);
        Account account2 = new (4800);
        Program.DisplayMenu();
    }

    static void DisplayMenu()
    {
        int operation;
        Account? currentAccount = null;

        do
        {
            if (currentAccount != null)
            {
                Console.WriteLine($"Currently selected account is {currentAccount} \n");
            }
            Console.WriteLine("1. Display accounts.");
            Console.WriteLine("2. Choose account.");
            Console.WriteLine("3. Add income to account.");
            Console.WriteLine("4. Add monthly payment to account.");
            Console.WriteLine("5. Display operations");
            Console.WriteLine("0. Exit.");
            Console.WriteLine("----------------------------------");

            var choice = Console.ReadLine();

            int.TryParse(choice, out operation);

            switch (operation)
            {
                case 1:
                    Console.Clear();
                    Account.ShowAccounts();
                    break;
                case 2:
                    Console.WriteLine("Please provide Id of an account you wish to change to.");
                    var accountChoice = Console.ReadLine();
                    int.TryParse(accountChoice, out int accountId);
                    currentAccount = Account.ChooseCurrentAccount(accountId);
                    Console.Clear();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("Please provide income amount");
                    var incomeAmount = Console.ReadLine();
                    decimal.TryParse(incomeAmount, out decimal incomeResult);

                    Console.WriteLine("Please provide income description");
                    var incomeDescription = Console.ReadLine();
                    Income.AddIncome(currentAccount, incomeResult, incomeDescription);
                    break;
                case 5:
                    Console.Clear();
                    currentAccount?.ShowAccountOperations();
                    break;
            }
        } while (operation != 0);

    }
}
