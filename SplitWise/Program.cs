using SplitWise;

public class Program
{
    public static void Main(string[] args)
    {
        var u1 = new User
        {
            Id = "u1",
            Name = "u1",
            Email = "u1@splitwise.com"
        };

        var u2 = new User
        {
            Id = "u2",
            Name = "u2",
            Email = "u2@splitwise.com"
        };

        var u3 = new User
        {
            Id = "u3",
            Name = "u3",
            Email = "u3@splitwise.com"
        };

        var u4 = new User
        {
            Id = "u4",
            Name = "u4",
            Email = "u4@splitwise.com"
        };

        var balanceSheetService = new BalanceSheetService();
        BalanceSheetController balanceSheetController = new(balanceSheetService);
        ExpenseController expenseController = new(new ExpenseService(balanceSheetService));
        UserController userController = new(new UserService(balanceSheetService));

        userController.AddUser(u1);
        userController.AddUser(u2);
        userController.AddUser(u3);
        userController.AddUser(u4);

        List<Split> list = new();
        var split1 = new EqualSplit(u1);
        var split2 = new EqualSplit(u2);
        var split3 = new EqualSplit(u3);
        var split4 = new EqualSplit(u4);
        list.Add(split1);
        list.Add(split2);
        list.Add(split3);
        list.Add(split4);

        expenseController.CreateExpense(u1, list, 1000, ExpenseType.EQUAL);
        // manager.AddExpense(ExpenseType.EQUAL, 1000, u1.Id, list);

        balanceSheetController.ShowBalances();
        Console.WriteLine("-------------------------------------");


        list.Clear();

        list.Add(new ExactSplit(u2, 370));
        list.Add(new ExactSplit(u3, 880));

        expenseController.CreateExpense(u1, list, 1250, ExpenseType.EXACT);
        // manager.AddExpense(ExpenseType.EXACT, 1250, u1.Id, list);

        balanceSheetController.ShowBalances();
        Console.WriteLine("-------------------------------------");

        list.Clear();

        list.Add(new PercenSplit(u1, 40));
        list.Add(new PercenSplit(u2, 20));
        list.Add(new PercenSplit(u3, 20));
        list.Add(new PercenSplit(u4, 20));

        expenseController.CreateExpense(u4, list, 1200, ExpenseType.PERCENT);

        // manager.AddExpense(ExpenseType.PERCENT, 1200, u4.Id, list);
        balanceSheetController.ShowBalances();
    }
}