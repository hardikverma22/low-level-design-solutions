namespace SplitWise;

public class BalanceSheetController
{
    private readonly BalanceSheetService balanceSheetService;

    public BalanceSheetController(BalanceSheetService balanceSheetService)
    {
        this.balanceSheetService = balanceSheetService;
    }

    public void BuildBalanceSheetForAUser(User user)
    {
        this.balanceSheetService.BuildBalanceSheetForAUser(user);
    }

    public void UpdateUserExpenseBalanceSheet(User paidByUser, List<Split> splits)
    {
        this.balanceSheetService.UpdateUserExpenseBalanceSheet(paidByUser, splits);
    }

    public void ShowBalances()
    {
        this.balanceSheetService.ShowBalances();
    }
}
