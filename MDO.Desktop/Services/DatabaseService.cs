using MDO.Desktop.Models;
using MDO.Desktop.Services.Factories;


namespace MDO.Desktop.Services
{
    public class DatabaseService
    {
        private readonly DatabaseCommandFactory _factory;

        public DatabaseService(IHttpClientWrapper client)
        {
            _factory = new DatabaseCommandFactory(client);
        }

        public async Task<ApiResponse<string>> ConnectAsync(DatabaseConnectionDto dto)
        {
            var cmd = _factory.Create(DatabaseOperation.Connect);
            return (ApiResponse<string>)await cmd.ExecuteAsync(dto);
        }

        public async Task<ApiResponse<string>> GetVersionAsync()
        {
            var cmd = _factory.Create(DatabaseOperation.GetVersion);
            return (ApiResponse<string>)await cmd.ExecuteAsync();
        }

        public async Task<ApiResponse<string>> DisconnectAsync()
        {
            var cmd = _factory.Create(DatabaseOperation.Disconnect);
            return (ApiResponse<string>)await cmd.ExecuteAsync();
        }
    }

}
