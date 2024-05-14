namespace SplitWise;

public class ExactSplit : Split
{
    public ExactSplit(User user, double amount) : base(user)
    {
        this.Amount = amount;
    }
}
