using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPT.Interfaces;
using TPT.Models.Responses;

namespace TPT.Models.Factories
{
    public class FailureResponseFactory : IResponseFactory
    {
        public int StatusCode { get; private set; }

        public string? Message { get; private set; }

        public FailureResponseFactory(int statusCode, string? message = null)
        {
            StatusCode = statusCode;
            Message = message;
        }
        public IResponse CreateResponse()
        {
            return new FailureResponse(StatusCode, Message);
        }
    }
}
