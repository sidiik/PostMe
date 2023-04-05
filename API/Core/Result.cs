using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Core
{
    public class Result<T>
    {
        public bool IsSuccess { get; set; }
        public int code { get; set; }
        public T Data { get; set; }
        public string Detail { get; set; }

        public static Result<T> Success(T Value) => new Result<T>
        {
            IsSuccess = true,
            Detail = string.Empty,
            Data = Value

        };

        public static Result<T> Failure(string detail) => new Result<T>
        {
            Detail = detail,
            IsSuccess = false,
        };
    }
}