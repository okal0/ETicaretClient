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

        public async Task<UserLoginResponse> CreateUser(UserInfo user)
        {
            requestParams.Controller = "Users";
            var response = await _client.PostAsync<UserInfo, UserLoginResponse>(requestParams, user);

            if (response.IsSuccess)
            {
                return response.Data;
            }
            else
            {
                throw new Exception($"API call failed with message: {response.ErrorMessage}");
            }
        }

        public async Task<UserLoginResponse> UserLogin(UserLogin user)
        {
            requestParams.Controller = "Users/Login";
            var response = await _client.PostAsync<UserLogin, UserLoginResponse>(requestParams, user);

            if (response.IsSuccess)
            {
                return response.Data;
            }
            else
            {
                throw new Exception($"API call failed with message: {response.ErrorMessage}");
            }
        }
    }
}
