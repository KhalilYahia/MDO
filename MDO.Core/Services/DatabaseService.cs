using MDO.Core.Dto;
using MDO.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDO.Core.Services
{
    public class DatabaseService : IDatabaseService
    {
       
        private SqlConnection _connection;

        public bool Open(DatabaseConnectionDto dto)
        {
                        
            if (_connection != null && _connection.State == ConnectionState.Open)
                return true;

            if (!TryBuildConnectionString(dto, out var connectionString, out var error))
                throw new InvalidOperationException(error);

            _connection = new SqlConnection(connectionString);
            _connection.Open();
           
            return _connection.State == ConnectionState.Open;
        }

        public async Task<string> GetSqlVersion()
        {
            EnsureOpen();

            using (var cmd = new SqlCommand("SELECT @@VERSION", _connection))
            {
                return (await cmd.ExecuteScalarAsync()).ToString();
            }
        }

        public void Close()
        {
            
             if (_connection?.State == ConnectionState.Open)
                  _connection.Close();
        }

        private void EnsureOpen()
        {
            if (_connection == null || _connection.State != ConnectionState.Open)
                throw new InvalidOperationException("Connection is not open!");
        }


        /// <summary>
        /// Выполняет валидацию входных параметров подключения и формирует строку подключения
        /// к базе данных SQL Server.
        /// </summary>
        /// <param name="dto">
        /// Объект с параметрами подключения к базе данных
        /// (имя сервера, имя базы данных, имя пользователя и пароль).
        /// </param>
        /// <param name="connectionString">
        /// Сформированная строка подключения. 
        /// Значение устанавливается только при успешной валидации.
        /// </param>
        /// <param name="error">
        /// Сообщение об ошибке валидации или формирования строки подключения.
        /// При успешном выполнении содержит <c>null</c>.
        /// </param>
        /// <returns>
        /// <c>true</c>, если строка подключения успешно сформирована;
        /// <c>false</c> — если входные данные некорректны или произошла ошибка.
        /// </returns>
        private bool TryBuildConnectionString( DatabaseConnectionDto dto,
                                               out string connectionString,
                                               out string error)
            {
                connectionString = null;
                error = null;
                            
                try
                {
                    var builder = new SqlConnectionStringBuilder
                    {
                        DataSource = dto.ServerName,
                        InitialCatalog = dto.DatabaseName,
                        UserID = dto.UserName,
                        Password = dto.Password,
                        IntegratedSecurity = false,
                        PersistSecurityInfo = false
                    };

                    connectionString = builder.ConnectionString;
                    return true;
                }
                catch (ArgumentException ex)
                {
                    error = ex.Message;
                    return false;
                }
        }

    }

}
