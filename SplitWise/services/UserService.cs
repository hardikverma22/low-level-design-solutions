namespace SplitWise;

public class UserService
{
    private readonly Dictionary<string, User> userMap;
    private readonly BalanceSheetService balanceSheetService;

    public UserService(BalanceSheetService balanceSheetService)
    {
        this.userMap = new();
        this.balanceSheetService = balanceSheetService;
    }

    public void AddUser(User user)
    {
        userMap.Add(user.Id, user);
        this.balanceSheetService.BuildBalanceSheetForAUser(user);
    }

    public User GetUser(string userId)
    {
        if (userMap.TryGetValue(userId, out User user))
        {
            return user;
        }
        return null;
    }

    public List<User> GetAllUsers()
    {
        return userMap.Values.ToList();
    }
}
