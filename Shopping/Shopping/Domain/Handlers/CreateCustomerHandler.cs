using MediatR;
using Shopping.Domain.Commands.Request;
using Shopping.Domain.Commands.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shopping.Domain.Handlers
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerRequest, CreateCustomerResponse>
    {


        public Task<CreateCustomerResponse> Handle(CreateCustomerRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new CreateCustomerResponse
            {
                Id = Guid.NewGuid(),
                Nome = request.Nome,
                Email = request.Email,
                Cadastro = DateTime.Now
            });
        }
    }
}
