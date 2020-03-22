using System.Net.Http;

namespace Core
{
    public class Client
    {
        public HttpClient HttpClient { get; }

        private BotInfo Token { get; }

        public Client(string token, HttpClient httpClient = null)
        {
	        Token = new BotInfo(token);
	        HttpClient = httpClient ?? new HttpClient();
        }

        ~Client() => HttpClient.Dispose();
    }
}
