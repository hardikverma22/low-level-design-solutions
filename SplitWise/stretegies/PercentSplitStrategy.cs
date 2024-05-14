namespace SplitWise;

public class PercentSplitStrategy : ISplitStrategy
{
    public void SplitExpense(List<Split> splits, double amount)
    {
        foreach (var split in splits)
        {
            split.Amount = amount * ((PercenSplit)split).percent / 100;
        }
    }
}