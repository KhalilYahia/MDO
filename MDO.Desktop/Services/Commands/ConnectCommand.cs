using MDO.Desktop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDO.Desktop.Services.Commands
{
    public class ConnectCommand : IDatabaseCommand
    {
        private readonly IHttpClientWrapper _client;

        public ConnectCommand(IHttpClientWrapper client) => _client = client;

        public async Task<object> ExecuteAsync(DatabaseConnectionDto dto)
        {
            var result = await _client.SendRequestAsync<string>("connect", HttpMethod.Post, dto);
            return result;
        }
    }
}
