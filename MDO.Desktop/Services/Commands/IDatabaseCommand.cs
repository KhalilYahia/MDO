using MDO.Desktop.Models;

namespace MDO.Desktop.Services.Commands
{
    public interface IDatabaseCommand<TResult>
    {
        Task<TResult> ExecuteAsync();
    }
}
