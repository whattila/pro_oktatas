using pro_oktatas.async;
using pro_oktatas.bank;
using pro_oktatas.product;

Console.WriteLine("Első feladat\n");

string[] lines =
{
    "Id;Name;Category;Price",
    "1;Mouse;Peripherals;4990",
    "2;Keyboard;Peripherals;12990",
    "3;Monitor;Displays;69990",
    "4;USB Cable;Peripherals;1990",
    "5;Desk;Furniture;54990",
    "6;Chair;Furniture;0"
};

List<Product> products = ProductUtilities.ParseProducts(lines);
ProductUtilities.PrintProductCountAndAvgPriceByCategory(products);

Console.WriteLine("\nMásodik feladat\n");

var bankAccount = new BankAccount("0123456789", "John Smith", 10000);
try
{
	bankAccount.Deposit(2500, "First");
	bankAccount.Withdraw(5000, "Second");
	bankAccount.Withdraw(20000, "Third");
}
catch (InsufficientFundsException ife)
{
	Console.WriteLine(ife.Message);
}

Console.WriteLine(bankAccount.Balance);
foreach (Transaction transaction in bankAccount.Transactions)
    Console.WriteLine($"{transaction.Timestamp.ToString()} {transaction.Amount} {transaction.Note}");

Console.WriteLine("\nHarmadik feladat\n");

Task<int> task1 = AsyncFunctions.GetUsersCountAsync();
Task<int> task2 = AsyncFunctions.GetOrdersCountAsync();
Task<int> task3 = AsyncFunctions.GetProductsCountAsync();

await Task.WhenAll(task1, task2, task3);

Console.WriteLine($"Users: {task1.Result}\nOrders: {task2.Result}\nProducts: {task3.Result}\nTotal: {task1.Result + task2.Result + task3.Result}");
