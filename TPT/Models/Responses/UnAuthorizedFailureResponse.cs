using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TPT.Interfaces;

namespace TPT.Models.Responses
{
	public class UnAuthorizedFailureResponse : IResponse
	{
		public int StatusCode { get; private set; }

		public string? Message { get; set; }

		public bool Status { get; private set; }


		public UnAuthorizedFailureResponse()
		{
			Status = false;
			StatusCode = 401;
			Message = "You are UnAuthorized , please provide correct token to your headers";
		}

		public UnAuthorizedFailureResponse(string message)
		{
			Status = false;
			StatusCode = 401;
			Message = message;
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
