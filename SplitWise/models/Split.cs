namespace SplitWise;

public abstract class Split
{
    public Split(User user)
    {
        this.User = user;
    }

    public User User { get; set; }
    public double Amount { get; set; }
}
