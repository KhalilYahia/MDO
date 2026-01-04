using MDO.Core.Dto;
using MDO.Core.Interfaces;
using MDO.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MDO.Controllers
{
  
    public class ApiResponseHelper : ApiController
    {
        /// <summary>
        /// // Метод для успешного ответа
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <param name="data"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static HttpResponseMessage Success<T>(HttpRequestMessage request, T data, string message = "Success")
        {
            var response = new ApiResponse<T>
            {
                Code = (int)HttpStatusCode.OK,
                Message = message,
                Data = data,
                Errors = null
            };
            return request.CreateResponse(HttpStatusCode.OK, response);
        }

        /// <summary>
        /// Метод для ответа с ошибкой
        /// </summary>
        /// <param name="request"></param>
        /// <param name="statusCode"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static HttpResponseMessage Error(HttpRequestMessage request, HttpStatusCode statusCode, string message, object errors = null)
        {
            var response = new ApiResponse<object>
            {
                Code = (int)statusCode,
                Message = message,
                Data = null,
                Errors = errors
            };
            return request.CreateResponse(statusCode, response);
        }


        /// <summary>
        /// для ModelState
        /// </summary>
        /// <param name="request"></param>
        /// <param name="modelState"></param>
        /// <returns></returns>
        public static HttpResponseMessage FromModelState(HttpRequestMessage request, System.Web.Http.ModelBinding.ModelStateDictionary modelState)
        {
            var errors = modelState
                .Where(ms => ms.Value.Errors.Count > 0)
                .ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                );

            return Error(request, HttpStatusCode.BadRequest, "Validation failed", errors);
        }
    }
}
