namespace SplitWise;

public class PercenSplit : Split
{
    public double percent { get; set; }

    public PercenSplit(User user, double percent) : base(user)
    {
        this.percent = percent;
    }
}
