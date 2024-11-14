using ETicaretClient.Contracts.User;


namespace ETicaretClient.Contracts
{
    public interface IUserService
    {
        public Task<UserInfo> CreateUser(UserInfo user);
    }
}
