using System;
using Shop.Domain.Commands.Request;
using Shop.Domain.Commands.Response;

namespace Shop.Domain.Handlers
{
    public class CreateCustomerHandler : ICreateCustomerHandler
    {
        public CreateCustomerResponse Handle(CreateCustomerRequest request){

            return new CreateCustomerResponse{
                Id = Guid.NewGuid(),
                Nome= "ricardo",
                Email= "ricardo@email.com",
                Cadastro = DateTime.Now               
            };
        }
    }
}