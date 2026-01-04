using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MDO.Models
{
    // Универсальный класс ответа API
    public class ApiResponse<T>
    {
        /// <summary>
        /// HTTP код ответа
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Сообщение об успехе или ошибке
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Данные при успешном запросе
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// Детали ошибок валидации
        /// </summary>
        public object Errors { get; set; }
    }
}