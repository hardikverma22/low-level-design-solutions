namespace SplitWise;

public class Expense
{

    public User PaidBy { get; set; }
    public List<Split> Splits { get; set; }
    public double Amount { get; set; }
}
