using MDO.Desktop.Models;

namespace MDO.Desktop.Services.Commands
{
    public class GetVersionCommand : IDatabaseCommand
    {
        private readonly IHttpClientWrapper _client;

        public GetVersionCommand(IHttpClientWrapper client) => _client = client;

        public async Task<object> ExecuteAsync(DatabaseConnectionDto dto = null)
        {
            return await _client.SendRequestAsync<string>("version", HttpMethod.Get);
        }
    }
}
