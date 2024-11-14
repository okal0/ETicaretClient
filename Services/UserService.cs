using ETicaretClient.Contracts;
using ETicaretClient.Contracts.User;
using ETicaretClient.DTOs;
using ETicaretClient.Services.Base;
using System;
using System.Threading.Tasks;

namespace ETicaretClient.Services
{
    public class UserService : BaseHttpService, IUserService
    {
        public UserService(IClient httpClient) : base(httpClient)
        {
        }

        public Task<UserLoginResponse> CreateUser(UserInfo user)
        {
            requestParams.Controller = "Users";
            var response = _client.PostAsync<UserInfo, UserLoginResponse>(requestParams, user);

            if (response != null && response.Result.IsSuccess)
            {
                return response;
            }
            else
            {
                // Handle error response
                throw new Exception($"API call failed with message: {response.Result.Message}");
            }
        }

        public async Task<UserLoginResponse> UserLogin(UserLogin user)
        {
            requestParams.Controller = "Users";
            requestParams.Action = "Login";
            var response = await _client.PostAsync<UserLogin, UserLoginResponse>(requestParams, user);

            if (response != null && response.IsSuccess)
            {
                return response;
            }
            else
            {
                // Handle error response
                throw new Exception($"API call failed with message: {response.Message}");
            }
        }

    }
}
