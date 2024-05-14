namespace SplitWise;

public class ExpenseController
{
    private readonly ExpenseService expenseService;

    public ExpenseController(ExpenseService expenseService)
    {
        this.expenseService = expenseService;
    }

    public Expense CreateExpense(User paidBy, List<Split> splits, double amount, ExpenseType expenseType)
    {
        return this.expenseService.CreateExpense(paidBy, splits, amount, expenseType);
    }
}
