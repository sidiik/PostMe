using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace API.Core
{
    public class Result<T>
    {
        public string href { get; set; }
        public bool IsSuccess { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string details { get; set; } = string.Empty;
        public T Data { get; set; }

        public static Result<T> Success(T result) => new Result<T>
        {
            IsSuccess = true,
            Data = result
        };

        public static Result<T> Failure(string message) => new Result<T>
        {
            IsSuccess = false,
            details = message
        };
    }

}