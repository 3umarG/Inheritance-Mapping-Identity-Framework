using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPH.Interfaces;

namespace TPH.Models.Responses
{
    public class SuccessResponse<T> : IResponse where T : class
    {
        public bool Status { get; private set; }

        public int StatusCode { get; private set; }

        public string? Message { get; set; }

        public T Data { get; set; }

        public SuccessResponse(int statusCode, T data, string? message = null)
        {
            Status = true;
            Message = message;
            StatusCode = statusCode;
            Data = data;
        }


    }
}
