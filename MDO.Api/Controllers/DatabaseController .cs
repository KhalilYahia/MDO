using MDO.Core.Dto;
using MDO.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace MDO.Controllers
{
    [RoutePrefix("api/database")]
    public class DatabaseController : ApiResponseHelper
    {
        private readonly IDatabaseService _databaseService;

        public DatabaseController(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }


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
        [HttpPost]
        [Route("connect")]
        public HttpResponseMessage Connect(DatabaseConnectionDto dto)
        {
            if (dto == null)
                return Success(Request, "Connection opened successfully");


            if (!ModelState.IsValid)
                return FromModelState(Request, ModelState);


            try
            {
                _databaseService.Open(dto);
                return Success(Request, "Connection opened successfully");
            }
            catch (InvalidOperationException ex)
            {

                return Error(Request, HttpStatusCode.Conflict, ex.Message);
            }
            catch (SqlException ex)
            {
                return Error(Request, HttpStatusCode.ServiceUnavailable, "Database unavailable: " + ex.Message); 
            }
        }

        /// <summary>
        /// получает версию SQL сервера.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("version")]
        public async Task<HttpResponseMessage> GetVersion()
        {
            try
            {
                var result = await _databaseService.GetSqlVersion();
                return Success(Request, result);
            }
            catch (InvalidOperationException ex)
            {

                return Error(Request, HttpStatusCode.Conflict, ex.Message);
            }
            catch (SqlException ex)
            {
                return Error(Request, HttpStatusCode.ServiceUnavailable, "Database unavailable: " + ex.Message);
            }
          
        }

        /// <summary>
        /// Закрывает текущее соединение с базой данных.
        /// </summary>
        [HttpPost]
        [Route("disconnect")]
        public HttpResponseMessage Disconnect()
        {
            try
            {
                _databaseService.Close();
                return Success(Request, "Database is closed");
            }
            catch (Exception ex)
            {

                return Error(Request, HttpStatusCode.Conflict, ex.Message);
            }
           
        }
    }
}
