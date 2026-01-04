using MDO.Desktop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MDO.Desktop.Services.Commands
{

    public class DisconnectCommand : IDatabaseCommand
    {
        private readonly IHttpClientWrapper _client;

        public DisconnectCommand(IHttpClientWrapper client) => _client = client;

        public async Task<object> ExecuteAsync(DatabaseConnectionDto dto = null)
        {
            return await _client.SendRequestAsync<string>("disconnect", HttpMethod.Post);
        }
    }
}
