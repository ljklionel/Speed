using Speed.Shared;

namespace Speed.Client.Services.UserService
{
    public interface IUserService
    {
        List<User> Users { get; set; }

        Task GetUsers();
    }
}
