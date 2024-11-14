using ETicaretClient.Contracts.User;


namespace ETicaretClient.Contracts
{
    public interface IUserService
    {
        public Task<UserInfo> CreateUser(UserInfo user);
        public Task<UserLogin> UserLogin(UserLogin user);
    }
}
