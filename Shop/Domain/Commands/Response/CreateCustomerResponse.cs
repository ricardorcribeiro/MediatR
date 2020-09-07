using System;

namespace Shop.Domain.Commands.Response
{
    public class CreateCustomerResponse
    {
        public Guid Id { get; init; }
        public string Nome { get; init; }
        public string Email { get; init; }
        public DateTime Cadastro { get; init; }
    }
}