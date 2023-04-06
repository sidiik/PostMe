using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace API.Core
{
    public class AccountResult<T>
    {
        public bool IsSuccess { get; set; }
        public T Data { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string Details { get; set; }

        public static AccountResult<T> Success(T Data) => new AccountResult<T>
        {
            IsSuccess = true,
            StatusCode = HttpStatusCode.OK,
            Details = string.Empty,
            Data = Data

        };
        public static AccountResult<T> Failure(string details) => new AccountResult<T>
        {
            IsSuccess = false,
            StatusCode = HttpStatusCode.Unauthorized,
            Details = details

        };

    }
}