using MDO.Desktop.Models;

namespace MDO.Desktop.Services.Commands
{
    public class GetVersionCommand : IDatabaseCommand<ApiResponse<string>>
    {
        private readonly IHttpClientWrapper _client;

        public GetVersionCommand(IHttpClientWrapper client) => _client = client;

        public async Task<ApiResponse<string>> ExecuteAsync()
        {
            return await _client.SendRequestAsync<string>("version", HttpMethod.Get);
        }
    }
}
