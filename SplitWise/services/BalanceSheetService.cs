namespace SplitWise;

public class BalanceSheetService
{
    private readonly Dictionary<string, Dictionary<string, double>> balanceSheets;

    public BalanceSheetService()
    {
        this.balanceSheets = new();
    }

    public void BuildBalanceSheetForAUser(User user)
    {
        balanceSheets[user.Id] = new Dictionary<string, double>();
    }

    public void UpdateUserExpenseBalanceSheet(User paidByUser, List<Split> splits)
    {
        var padiByUserBalanceSheet = balanceSheets[paidByUser.Id];
        foreach (var split in splits)
        {
            var paidTo = split.User.Id;
            var oweUserBalanceSheer = balanceSheets[split.User.Id];

            if (!padiByUserBalanceSheet.ContainsKey(paidTo))
            {
                padiByUserBalanceSheet.Add(paidTo, 0.0);
            }
            padiByUserBalanceSheet[paidTo] = padiByUserBalanceSheet[paidTo] + split.Amount;

            balanceSheets[paidByUser.Id] = padiByUserBalanceSheet;

            if (!oweUserBalanceSheer.ContainsKey(paidByUser.Id))
            {
                oweUserBalanceSheer.Add(paidByUser.Id, 0.0);
            }
            oweUserBalanceSheer[paidByUser.Id] = oweUserBalanceSheer[paidByUser.Id] - split.Amount;
            balanceSheets[split.User.Id] = oweUserBalanceSheer;
        }
    }

    public void ShowBalances()
    {
        bool isEmpty = true;
        foreach (KeyValuePair<string, Dictionary<string, double>> paidByUser in balanceSheets)
        {
            foreach (KeyValuePair<string, double> oweByUser in paidByUser.Value)
            {
                if (oweByUser.Value > 0)
                {
                    isEmpty = false;
                    PrintBalance(paidByUser.Key, oweByUser.Key, oweByUser.Value);
                }
            }
        }

        if (isEmpty)
        {
            Console.WriteLine("No balances");
        }
    }

    private void PrintBalance(string user1, string user2, double amount)
    {
        string user1Name = user1;//userMap[user1].Name;
        string user2Name = user2;//userMap[user2].Name;
        if (amount < 0)
        {
            Console.WriteLine(user1Name + " owes " + user2Name + ": " + Math.Abs(amount));
        }
        else if (amount > 0)
        {
            Console.WriteLine(user2Name + " owes " + user1Name + ": " + Math.Abs(amount));
        }
    }

}
