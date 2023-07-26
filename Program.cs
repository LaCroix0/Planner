using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace Planner;

class Program
{
    private static Account? _currentAccount;
    public static void Main()
    {
        DeserializeFromJson();
        AccountMenu();
        SerializeToJson();
    }

    static void SerializeToJson()
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)

        };
        File.WriteAllText(@"..\..\..\Data\Data.json", JsonSerializer.Serialize(Account.Accounts, options));

        Console.WriteLine("----------------------------------");
        Console.WriteLine("Serialization completed");
        Console.WriteLine("----------------------------------");
    }

    static void DeserializeFromJson()
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
        };
        JsonSerializer.Deserialize<List<Account>>(File.ReadAllText(@"..\..\..\Data\Data.json"), options);
        
        Console.WriteLine("----------------------------------");
        Console.WriteLine("Deserialization completed");
        Console.WriteLine("---------------------------------- \n");
    }

    static void AccountMenu()
    {
        int operation;
        Console.WriteLine("1. Display accounts.");
        Console.WriteLine("2. Choose account.");
        Console.WriteLine("0. Exit.");
        Console.WriteLine("----------------------------------");

        var choice = Console.ReadLine();

        int.TryParse(choice, out operation);

        switch (operation)
        {
            case 1:
                Console.Clear();
                Account.ShowAccounts();
                AccountMenu();
                break;
            case 2:
                Console.WriteLine("Please provide Id of an account you wish to change to.");
                var accountChoice = Console.ReadLine();
                int.TryParse(accountChoice, out int accountId);
                _currentAccount = Account.ChooseCurrentAccount(accountId);
                Console.Clear();
                DisplayMenu();
                break;
            case 0: 
                break;
        }
    }

    static void DisplayMenu()
    {
        int operation;
        
        do
        {
            if (_currentAccount != null)
            {
                Console.WriteLine($"Currently selected account is {_currentAccount} \n");
            }
            Console.WriteLine("1. Add income to account.");
            Console.WriteLine("2. Remove income from account.");
            Console.WriteLine("3. Add monthly payment to account.");
            Console.WriteLine("4. Remove monthly payment from account.");
            Console.WriteLine("5. Display operations");
            Console.WriteLine("6. Back to previous menu");
            Console.WriteLine("0. Exit.");
            Console.WriteLine("----------------------------------");

            var choice = Console.ReadLine();

            int.TryParse(choice, out operation);

            switch (operation)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Please provide income amount.");
                    var incomeAmount = Console.ReadLine();
                    decimal.TryParse(incomeAmount, out decimal incomeResult);

                    Console.WriteLine("Please provide income description");
                    var incomeDescription = Console.ReadLine();

                    Console.Clear();
                    Income.AddIncome(_currentAccount, incomeResult, incomeDescription);
                    break;
                case 2:
                    Console.Clear();
                    Income.RemoveIncome(_currentAccount);
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("Please provide expense amount.");
                    var expenseAmount = Console.ReadLine();
                    decimal.TryParse(expenseAmount, out decimal expenseResult);

                    Console.WriteLine("Categories of expenses :");
                    Console.WriteLine($"Installments - 1");
                    Console.WriteLine($"OneTimePayment - 2");
                    Console.WriteLine("Please select category.");

                    var userInput = Console.ReadLine();
                    int.TryParse(userInput, out int categoryId);

                    Console.Clear();
                    Expense.AddExpense(_currentAccount, expenseResult, categoryId);
                    break;
                case 4:
                    Console.Clear();
                    Expense.RemoveExpense(_currentAccount);
                    break;
                case 5:
                    Console.Clear();
                    _currentAccount?.ShowAccountOperations();
                    break;
                case 6:
                    Console.Clear();
                    AccountMenu();
                    break;
                case 0:
                    break;
            }
        } while (operation != 0);

    }
}