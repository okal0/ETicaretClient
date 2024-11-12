using ETicaretClient.Contracts;
using ETicaretClient.Models.Product;
using ETicaretClient.Models.User;
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


    }
}
