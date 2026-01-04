using MDO.Desktop.Models;

namespace MDO.Desktop.Services.Commands
{
    public interface IDatabaseCommand
    {
        Task<object> ExecuteAsync(DatabaseConnectionDto dto = null);
    }
}
