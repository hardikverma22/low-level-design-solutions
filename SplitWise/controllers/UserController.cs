namespace SplitWise;

public class UserController
{
    private readonly UserService userService;

    public UserController(UserService userService)
    {
        this.userService = userService;
    }

    public void AddUser(User user)
    {
        this.userService.AddUser(user);
    }

    public User GetUser(string userId)
    {
        return this.userService.GetUser(userId);
    }

    public List<User> GetAllUsers()
    {
        return this.userService.GetAllUsers();
    }

}
