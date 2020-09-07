using MediatR;
using Shopping.Domain.Commands.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Domain.Commands.Request
{
    public class CreateCustomerRequest : IRequest<CreateCustomerResponse>
    {
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}
