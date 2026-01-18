using MDO.Desktop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDO.Desktop.Services.Commands
{
    public class ConnectCommand : IDatabaseCommand<ApiResponse<string>>
    {
        private readonly IHttpClientWrapper _client;
        private readonly DatabaseConnectionDto _dto;

        public ConnectCommand(IHttpClientWrapper client, DatabaseConnectionDto dto) 
        {
            _client = client;
            _dto = dto;
        }
            
            

        public async Task<ApiResponse<string>> ExecuteAsync()
        {
            var result = await _client.SendRequestAsync<string>("connect", HttpMethod.Post, _dto);
            return result;
        }
    }
}
