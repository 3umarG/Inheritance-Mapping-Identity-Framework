using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPH.Interfaces;
using TPH.Models.Responses;

namespace TPH.Models.Factories
{
    public class SuccessResponseFactory<T> : IResponseFactory where T : class
    {


        public SuccessResponseFactory(int statusCode, T data, string? message = null)
        {
            StatusCode = statusCode;
            Data = data;
            Message = message;
        }
        public int StatusCode { get; private set; }

        public T Data { get; private set; }

        public string? Message { get; private set; }


        public IResponse CreateResponse()
        {
            return new SuccessResponse<T>(StatusCode, Data, Message);
        }
    }
}
