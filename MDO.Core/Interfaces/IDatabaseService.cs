
using MDO.Core.Dto;
using System.Threading.Tasks;

namespace MDO.Core.Interfaces
{
    public interface IDatabaseService
    {
        /// <summary>
        /// Открывает соединение с базой данных на основе переданных параметров подключения.
        /// </summary>
        /// <param name="dto">
        /// Объект, содержащий данные для подключения к базе данных
        /// (сервер, имя базы данных, имя пользователя и пароль).
        /// </param>
        /// <returns>
        /// <c>true</c>, если соединение было успешно открыто или уже открыто;
        /// <c>false</c> — если параметры подключения некорректны
        /// или соединение не удалось открыть.
        /// </returns>
        bool Open(DatabaseConnectionDto dto);

        /// <summary>
        /// Асинхронно получает версию SQL сервера.
        /// </summary>
        /// <returns></returns>
        Task<string> GetSqlVersion();

        /// <summary>
        /// Закрывает текущее соединение с базой данных.
        /// </summary>
        void Close();
    }
}
