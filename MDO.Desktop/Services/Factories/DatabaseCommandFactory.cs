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

        public IDatabaseCommand Create(DatabaseOperation operation)
        {
            return operation switch
            {
                DatabaseOperation.Connect => new ConnectCommand(_client),
                DatabaseOperation.GetVersion => new GetVersionCommand(_client),
                DatabaseOperation.Disconnect => new DisconnectCommand(_client),
                _ => throw new InvalidOperationException("Unknown database operation")
            };
        }
    }
}
