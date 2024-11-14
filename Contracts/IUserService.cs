using ETicaretClient.Contracts.User;
using ETicaretClient.DTOs;


namespace ETicaretClient.Contracts
{
    public interface IUserService
    {
        public Task<UserLoginResponse> CreateUser(UserInfo user);
        public Task<UserLoginResponse> UserLogin(UserLogin user);
    }
}
