namespace SplitWise;

public class ExpenseService
{
    private readonly List<Expense> expenses;
    private readonly BalanceSheetService balanceSheetService;
    private readonly Dictionary<ExpenseType, ISplitStrategy> expenseStrategies;
    public ExpenseService(BalanceSheetService balanceSheetService)
    {
        this.expenses = new();
        this.balanceSheetService = balanceSheetService;
        expenseStrategies = new Dictionary<ExpenseType, ISplitStrategy>
            {
                { ExpenseType.EQUAL, new EqualSplitStrategy() },
                { ExpenseType.EXACT, new ExactSplitStrategy() },
                { ExpenseType.PERCENT, new PercentSplitStrategy() }
            };
    }

    public Expense CreateExpense(User paidBy, List<Split> splits, double amount, ExpenseType expenseType)
    {
        var newExpense = new Expense()
        {
            PaidBy = paidBy,
            Amount = amount
        };

        var expenseStrategy = expenseStrategies[expenseType];
        expenseStrategy.SplitExpense(splits, amount);

        this.expenses.Add(newExpense);
        this.balanceSheetService.UpdateUserExpenseBalanceSheet(paidBy, splits);
        return newExpense;

    }
}
