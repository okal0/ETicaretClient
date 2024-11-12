using ETicaretClient.Models.Product;
using ETicaretClient.Models.User;

namespace ETicaretClient.Contracts
{
    public interface IUserService
    {
        public Task<UserInfo> CreateUser(UserInfo user);
    }
}
