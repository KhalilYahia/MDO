using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace MDO.Core.Dto
{
    /// <summary>
    /// DTO-класс, содержащий параметры подключения к базе данных.
    /// </summary>
    public class DatabaseConnectionDto
    {
        /// <summary>
        /// Имя или адрес сервера базы данных.
        /// </summary>
        [Required(ErrorMessage = "Server name is required")]
        [StringLength(200, ErrorMessage = "Server name must not exceed 200 characters")]
        public string ServerName { get; set; }

        /// <summary>
        /// Имя базы данных, к которой выполняется подключение.
        /// </summary>
        [Required(ErrorMessage = "Database name is required")]
        [StringLength(200, ErrorMessage = "Database name must not exceed 200 chars")]
        public string DatabaseName { get; set; }

        /// <summary>
        /// Имя пользователя для аутентификации в базе данных.
        /// </summary>
        [Required(ErrorMessage = "User name is required")]
        [StringLength(100, ErrorMessage = "User name must not exceed 100 characters")]
        public string UserName { get; set; }

        /// <summary>
        /// Пароль пользователя для подключения к базе данных.
        /// </summary>
        [Required(ErrorMessage = "Password is required")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 50 characters")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]+$",
         ErrorMessage = "Password must contain at least one letter and at least one digit")]
        public string Password { get; set; }
    }
}
