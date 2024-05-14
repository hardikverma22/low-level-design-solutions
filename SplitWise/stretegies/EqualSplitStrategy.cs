
namespace SplitWise;

public class EqualSplitStrategy : ISplitStrategy
{
    public void SplitExpense(List<Split> splits, double amount)
    {
        var noOfUsers = splits.Count;
        var splitAmount = ((double)Math.Round(amount * 100 / noOfUsers)) / 100.0; ;
        foreach (var split in splits)
        {
            split.Amount = splitAmount;
        }
    }
}
