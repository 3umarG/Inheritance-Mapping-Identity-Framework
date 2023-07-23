using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPT.Interfaces;
using TPT.Models.Responses;

namespace TPT.Models.Factories
{
    public class UnAuthorizedFailureResponseFactory : IResponseFactory
    {
        private readonly UnAuthorizedFailureResponse _response;

        public UnAuthorizedFailureResponseFactory()
        {
            _response = new UnAuthorizedFailureResponse();
        }
        public IResponse CreateResponse()
        {
            return _response;
        }
    }
}
