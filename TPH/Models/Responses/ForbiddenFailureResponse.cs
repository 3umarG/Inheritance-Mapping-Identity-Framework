using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TPH.Interfaces;

namespace TPH.Models.Responses
{
	public class ForbiddenFailureResponse : IResponse
    {
        public int StatusCode { get; private set; }

        public string? Message { get; set; }

        public bool Status { get; private set; }

        public ForbiddenFailureResponse()
        {
            StatusCode = 403;
            Message = "You are Forbidden from accessing this end point , this end point need certain Role";
            Status = false;
        }

        public override string ToString()
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            return JsonSerializer.Serialize(this, options);
        }
    }
}
