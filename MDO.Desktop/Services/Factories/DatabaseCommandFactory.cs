using MDO.Desktop.Models;
using MDO.Desktop.Services.Commands;


namespace MDO.Desktop.Services.Factories
{
    public class DatabaseCommandFactory
    {

        private readonly IHttpClientWrapper _client;

        public DatabaseCommandFactory(IHttpClientWrapper client)
        {
            _client = client;
        }

        public IDatabaseCommand<ApiResponse<string>> Create_ConnectCommand(DatabaseConnectionDto dto)
        {
            return new ConnectCommand(_client, dto);
        }

        public IDatabaseCommand<ApiResponse<string>> Create_GetVersionCommand()
        {
            return new GetVersionCommand(_client);
        }

        public IDatabaseCommand<ApiResponse<string>> Create_DisconnectCommand()
        {
            return new DisconnectCommand(_client);
        }
        
    }
}
