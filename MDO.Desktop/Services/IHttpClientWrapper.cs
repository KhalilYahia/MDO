using MDO.Desktop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDO.Desktop.Services
{
    public interface IHttpClientWrapper
    {
        Task<ApiResponse<T>> SendRequestAsync<T>(string url, HttpMethod method, object payload = null);
    }
}
