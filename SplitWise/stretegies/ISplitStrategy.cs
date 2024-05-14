namespace SplitWise;

public interface ISplitStrategy
{
    void SplitExpense(List<Split> splits, double amount);
}
