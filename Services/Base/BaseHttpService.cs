using ETicaretClient.Services.models;

namespace ETicaretClient.Services.Base
{
    public class BaseHttpService
    {
        protected IClient _client;
        protected RequestParameters requestParams = new RequestParameters();

        public BaseHttpService(IClient client)
        {
            _client = client;
        }
    }
}
