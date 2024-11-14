using ETicaretClient.Contracts;
using ETicaretClient.Contracts.User;
using ETicaretClient.Services.Base;

namespace ETicaretClient.Services
{
    public class UserService : BaseHttpService, IUserService
    {
        public UserService(IClient httpClient) : base(httpClient)
        {

        }

        public Task<UserInfo> CreateUser(UserInfo user)
        {
            requestParams.Controller = "User";
            return _client.PostAsync(requestParams, user);
        }

        public Task<UserLogin> CreateUserLogin(UserLogin user)
        {
            requestParams.Controller = "User";
            requestParams.Action = "Login";
            return _client.PostAsync(requestParams, user);
        }



    }
}
