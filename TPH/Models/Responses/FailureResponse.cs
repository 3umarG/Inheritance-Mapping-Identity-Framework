using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPH.Interfaces;

namespace TPH.Models.Responses
{
    public class FailureResponse : IResponse
    {
        public bool Status { get; private set; }

        public int StatusCode { get; private set; }

        public string? Message { get; set; }

        public FailureResponse(int statusCode, string? message = null)
        {
            Status = false;
            StatusCode = statusCode;
            Message = message;
        }
    }
}
